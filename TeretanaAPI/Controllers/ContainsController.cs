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
    [Route("api/Contains")]
    public class ContainsController : Controller
    {
        private readonly TeretanaContext _context;

        public ContainsController(TeretanaContext context)
        {
            _context = context;
        }

        // GET: api/Contains
        [HttpGet]
        public IEnumerable<Contains> GetContains()
        {
            return _context.Contains;
        }

        // GET: api/Contains/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContains([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var contains = await _context.Contains.SingleOrDefaultAsync(m => m.ContainsId == id);

            if (contains == null)
                return NotFound();

            return Ok(contains);
        }

        // PUT: api/Contains/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContains([FromRoute] int id, [FromBody] Contains contains)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != contains.ContainsId)
                return BadRequest();

            _context.Entry(contains).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContainsExists(id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // POST: api/Contains
        [HttpPost]
        public async Task<IActionResult> PostContains([FromBody] Contains contains)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            string[] inputParamNames =
            {
                "ServiceId", "PackageId", "Discount", "Count"
            };
            object[] inputParamValues =
            {
                contains.ServiceId, contains.PackageId, contains.Discount, contains.Count
            };
            string[] outputParamNames = {"ErrorCode", "ErrorMessage"};
            object[] outputParamValues = {0, ""};

            var outParams = DataReaderExtensions.ExecuteStoredProcedure(_context,
                StoredProcedureNames.CreateNewContains, inputParamNames,
                inputParamValues, outputParamNames, outputParamValues);
            var re = new JsonResult(outputParamValues);
            return Ok(re);


            //_context.Contains.Add(contains);
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateException)
            //{
            //    if (ContainsExists(contains.ContainsId))
            //        return new StatusCodeResult(StatusCodes.Status409Conflict);
            //    throw;
            //}

            //return CreatedAtAction("GetContains", new {id = contains.ContainsId}, contains);
        }

        // DELETE: api/Contains/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContains([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var contains = await _context.Contains.SingleOrDefaultAsync(m => m.ContainsId == id);
            if (contains == null)
                return NotFound();

            _context.Contains.Remove(contains);
            await _context.SaveChangesAsync();

            return Ok(contains);
        }

        private bool ContainsExists(int id)
        {
            return _context.Contains.Any(e => e.ContainsId == id);
        }
    }
}