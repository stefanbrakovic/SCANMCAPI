using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeretanaAPI.Constants;
using TeretanaAPI.DataBaseManipulation;
using TeretanaAPI.Models;

namespace TeretanaAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/ServicePrices")]
    public class ServicePricesController : Controller
    {
        private readonly TeretanaContext _context;

        public ServicePricesController(TeretanaContext context)
        {
            _context = context;
        }

        // GET: api/ServicePrices
        [HttpGet]
        public IEnumerable<ServicePrice> GetServicePrice()
        {
            return _context.ServicePrice;
        }

        // GET: api/ServicePrices/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServicePrice([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var servicePrice = await _context.ServicePrice.SingleOrDefaultAsync(m => m.ServiceId == id);

            if (servicePrice == null)
                return NotFound();

            return Ok(servicePrice);
        }

        // PUT: api/ServicePrices/5
        [HttpPut("{id}")]
        public IActionResult PutServicePrice([FromRoute] int id, [FromBody] ServicePrice servicePrice)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != servicePrice.ServiceId)
                return BadRequest();


            string[] inputParamNames =
            {
                "ServiceId", "Price"
            };
            object[] inputParamValues =
            {
                id, servicePrice.Price
            };
            string[] outputParamNames = {"ErrorCode", "ErrorMessage"};
            object[] outputParamValues = {0, ""};

            var outParams = DataReaderExtensions.ExecuteStoredProcedure(_context,
                StoredProcedureNames.UpdateServicePrice, inputParamNames,
                inputParamValues, outputParamNames, outputParamValues);
            var re = new JsonResult(outputParamValues);
            return Ok(re);


            //_context.Entry(servicePrice).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!ServicePriceExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
        }

        // POST: api/ServicePrices
        [HttpPost]
        public async Task<IActionResult> PostServicePrice([FromBody] ServicePrice servicePrice)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.ServicePrice.Add(servicePrice);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ServicePriceExists(servicePrice.ServiceId))
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                throw;
            }

            return CreatedAtAction("GetServicePrice", new {id = servicePrice.ServiceId}, servicePrice);
        }

        // DELETE: api/ServicePrices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServicePrice([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var servicePrice = await _context.ServicePrice.SingleOrDefaultAsync(m => m.ServiceId == id);
            if (servicePrice == null)
                return NotFound();

            _context.ServicePrice.Remove(servicePrice);
            await _context.SaveChangesAsync();

            return Ok(servicePrice);
        }

        private bool ServicePriceExists(int id)
        {
            return _context.ServicePrice.Any(e => e.ServiceId == id);
        }
    }
}