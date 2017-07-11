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
    [Route("api/Subscribeds")]
    public class SubscribedsController : Controller
    {
        private readonly TeretanaContext _context;

        public SubscribedsController(TeretanaContext context)
        {
            _context = context;
        }

        // GET: api/Subscribeds
        [HttpGet]
        public IEnumerable<Subscribed> GetSubscribed()
        {
            return _context.Subscribed;
        }

        // GET: api/Subscribeds/5
        [HttpGet("{id}")]
        public IEnumerable<Subscribed> GetSubscribed([FromRoute] int id)
        {
            var subs = _context.Subscribed.Where(m => m.UserId == id);
            if (subs == null)
                return null;

            //var paketi = _context.Packages;
            //foreach (var sub in subs)
            //foreach (var pak in paketi)
            //    if (pak.PackageId == sub.PackageId)
            //    {
            //        sub.Package = pak;
            //        break;
            //    }

            return subs;
            // var subscribed = await _context.Subscribed.SingleOrDefaultAsync(m => m.UserId == id);

            /* string[] inputParamNames =
                 {
                 "UserId"
             };
             object[] inputParamValues =
             {
                 id
             };
             string[] outputParamNames = { "ErrorCode", "ErrorMessage" };
             object[] outputParamValues = { 0, "" };
 
             var outParams = DataReaderExtensions.ExecuteStoredProcedure(_context, StoredProcedureNames.GetAllSubByUserId, inputParamNames,
                 inputParamValues, outputParamNames, outputParamValues);
             var re = new JsonResult(outputParamValues);
             return Ok(re);*/
        }

        // PUT: api/Subscribeds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscribed([FromRoute] int id, [FromBody] Subscribed subscribed)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != subscribed.SubscribedId)
                return BadRequest();

            _context.Entry(subscribed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubscribedExists(id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // POST: api/Subscribeds
        [HttpPost]
        public async Task<IActionResult> PostSubscribed([FromBody] Subscribed subscribed)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            string[] inputParamNames =
            {
                "UserId", "PackageId", "DateFrom", "DateTo"
            };
            object[] inputParamValues =
            {
                subscribed.UserId, subscribed.PackageId, subscribed.DateFrom, subscribed.DateTo
            };
            string[] outputParamNames = {"ErrorCode", "ErrorMessage"};
            object[] outputParamValues = {0, ""};

            var outParams = DataReaderExtensions.ExecuteStoredProcedure(_context,
                StoredProcedureNames.CreateNewSubscription, inputParamNames,
                inputParamValues, outputParamNames, outputParamValues);
            var re = new JsonResult(outputParamValues);
            return Ok(re);


            //_context.Subscribed.Add(subscribed);
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateException)
            //{
            //    if (SubscribedExists(subscribed.SubscribedId))
            //    {
            //        return new StatusCodeResult(StatusCodes.Status409Conflict);
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return CreatedAtAction("GetSubscribed", new { id = subscribed.SubscribedId }, subscribed);
        }

        // DELETE: api/Subscribeds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscribed([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var subscribed = await _context.Subscribed.SingleOrDefaultAsync(m => m.SubscribedId == id);
            if (subscribed == null)
                return NotFound();

            _context.Subscribed.Remove(subscribed);
            await _context.SaveChangesAsync();

            return Ok(subscribed);
        }

        private bool SubscribedExists(int id)
        {
            return _context.Subscribed.Any(e => e.SubscribedId == id);
        }
    }
}