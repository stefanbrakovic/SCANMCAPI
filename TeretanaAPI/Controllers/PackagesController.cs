using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeretanaAPI.DataBaseManipulation;
using TeretanaAPI.Models;

namespace TeretanaAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Packages")]
    public class PackagesController : Controller
    {
        private readonly TeretanaContext _context;

        public PackagesController(TeretanaContext context)
        {
            _context = context;
        }

        // GET: api/Packages
        [HttpGet]
        public IEnumerable<Packages> GetPackages()
        {
            return _context.Packages;
        }

        // GET: api/Packages/5
        [HttpGet("{id}")]
        public IActionResult GetPackages([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            string[] inputParamNames =
            {
                "PackageId"
            };
            object[] inputParamValues =
            {
                id
            };
            string[] outputParamNames = {"ErrorCode", "ErrorMessage"};
            object[] outputParamValues = {0, ""};
            var spName = "sp_get_Package_by_Id";
            var packages = DataReaderExtensions.ExecuteStoredProcedure(_context, spName, inputParamNames,
                inputParamValues, outputParamNames, outputParamValues);

            //var packages = await _context.Packages.SingleOrDefaultAsync(m => m.PackageId == id);

            if (packages == null)
                return NotFound();

            return Ok(packages);
        }

        // PUT: api/Packages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPackages([FromRoute] int id, [FromBody] Packages packages)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != packages.PackageId)
                return BadRequest();

            _context.Entry(packages).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackagesExists(id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // POST: api/Packages
        [HttpPost]
        public IActionResult PostPackages([FromBody] Packages packages)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //_context.Packages.Add(packages);
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateException)
            //{
            //    if (PackagesExists(packages.PackageId))
            //        return new StatusCodeResult(StatusCodes.Status409Conflict);
            //    throw;
            //}

            string[] inputParamNames =
            {
                "PackageName", "PackageDescription", "IsActive"
            };
            object[] inputParamValues =
            {
                packages.PackageName, packages.PackageDescription, packages.IsActive, packages.DateCreated
            };
            string[] outputParamNames = {"ErrorCode", "ErrorMessage"};
            object[] outputParamValues = {0, ""};
            var spName = "sp_insert_new_Package";
            var outParams = DataReaderExtensions.ExecuteStoredProcedure(_context, spName, inputParamNames,
                inputParamValues, outputParamNames, outputParamValues);
            var re = new JsonResult(outputParamValues);
            return Ok(re);
            //return CreatedAtAction("GetPackages", new {id = packages.PackageId}, packages);
        }

        // DELETE: api/Packages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackages([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var packages = await _context.Packages.SingleOrDefaultAsync(m => m.PackageId == id);
            if (packages == null)
                return NotFound();

            _context.Packages.Remove(packages);
            await _context.SaveChangesAsync();

            return Ok(packages);
        }

        private bool PackagesExists(int id)
        {
            return _context.Packages.Any(e => e.PackageId == id);
        }
    }
}