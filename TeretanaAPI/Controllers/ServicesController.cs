using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeretanaAPI.Constants;
using TeretanaAPI.DataBaseManipulation;
using TeretanaAPI.Models;

namespace TeretanaAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Services")]
    public class ServicesController : Controller
    {
        private readonly TeretanaContext _context;

        public ServicesController(TeretanaContext context)
        {
            _context = context;
        }

        // GET: api/Services
        [HttpGet]
        public IEnumerable<Services> GetServices()
        {
            return _context.Services;
        }

        // GET: api/Services/5
        [HttpGet("{id}")]
        public IActionResult GetServices([FromRoute] string serviceName)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //var services = await _context.Services.SingleOrDefaultAsync(m => m.ServiceId == id);

            //if (services == null)
            //{
            //    return NotFound();
            //}
            string[] inputParamNames =
            {
                "ServiceName"
            };
            object[] inputParamValues =
            {
                serviceName
            };
            string[] outputParamNames = {"ErrorCode", "ErrorMessage"};
            object[] outputParamValues = {0, ""};

            var outParams = DataReaderExtensions.ExecuteStoredProcedure(_context, StoredProcedureNames.GetServiceByName,
                inputParamNames,
                inputParamValues, outputParamNames, outputParamValues);
            var re = new JsonResult(outputParamValues);
            return Ok(re);
        }

        // PUT: api/Services/5
        [HttpPut("{id}")]
        public IActionResult PutServices([FromRoute] int id, [FromBody] Services services)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != services.ServiceId)
                return BadRequest();

            string[] inputParamNames =
            {
                "ServiceId", "ServiceName", "ServiceDescription", "IsActive"
            };
            object[] inputParamValues =
            {
                services.ServiceId, services.ServiceName, services.ServiceDescription, services.IsActive
            };
            string[] outputParamNames = {"ErrorCode", "ErrorMessage"};
            object[] outputParamValues = {0, ""};

            var outParams = DataReaderExtensions.ExecuteStoredProcedure(_context,
                StoredProcedureNames.UpdateServiceById, inputParamNames,
                inputParamValues, outputParamNames, outputParamValues);
            var re = new JsonResult(outParams); //outputParamValues
            return Ok(re);
            //_context.Entry(services).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!ServicesExists(id))
            //        return NotFound();
            //    throw;
            //}

            //return NoContent();
        }

        // POST: api/Services
        [HttpPost]
        public IActionResult PostServices([FromBody] Services services)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            string[] inputParamNames =
            {
                "ServiceName", "ServiceDescription", "IsActive", "ServicePrice"
            };
            object[] inputParamValues =
            {
                services.ServiceName, services.ServiceDescription, services.IsActive,
                services.ServicePrice.FirstOrDefault(x => x.Price >= 0)
            };
            string[] outputParamNames = {"ErrorCode", "ErrorMessage"};
            object[] outputParamValues = {0, ""};

            var outParams = DataReaderExtensions.ExecuteStoredProcedure(_context, StoredProcedureNames.CreateNewService,
                inputParamNames,
                inputParamValues, outputParamNames, outputParamValues);
            var re = new JsonResult(outputParamValues);
            return Ok(re);
            //_context.Services.Add(services);
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateException)
            //{
            //    if (ServicesExists(services.ServiceId))
            //        return new StatusCodeResult(StatusCodes.Status409Conflict);
            //    throw;
            //}

            //return CreatedAtAction("GetServices", new {id = services.ServiceId}, services);
        }

        // DELETE: api/Services/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServices([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var services = await _context.Services.SingleOrDefaultAsync(m => m.ServiceId == id);
            if (services == null)
                return NotFound();

            _context.Services.Remove(services);
            await _context.SaveChangesAsync();

            return Ok(services);
        }

        private bool ServicesExists(int id)
        {
            return _context.Services.Any(e => e.ServiceId == id);
        }
    }
}