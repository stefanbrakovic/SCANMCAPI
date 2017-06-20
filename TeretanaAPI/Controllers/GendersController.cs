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
    [Route("api/Genders")]
    public class GendersController : Controller
    {
        private readonly TeretanaContext _context;

        public GendersController(TeretanaContext context)
        {
            _context = context;
        }

        // GET: api/Genders
        [HttpGet]
        public IEnumerable<Genders> GetGenders()
        {
            return _context.Genders;
        }

        // GET: api/Genders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenders([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var genders = await _context.Genders.SingleOrDefaultAsync(m => m.GenderId == id);

            if (genders == null)
                return NotFound();

            return Ok(genders);
        }

        // PUT: api/Genders/5
        [HttpPut("{id}")]
        public IActionResult PutGenders([FromRoute] int id, [FromBody] Genders genders)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != genders.GenderId)
                return BadRequest();

            //_context.Entry(genders).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!GendersExists(id))
            //        return NotFound();
            //    throw;
            //}
            string[] inputParamNames =
            {
                "GenderId", "Gender"
            };
            object[] inputParamValues =
            {
                genders.GenderId, genders.Gender
            };
            string[] outputParamNames = {"ErrorCode", "ErrorMessage"};
            object[] outputParamValues = {0, ""};

            var outParams = DataReaderExtensions.ExecuteStoredProcedure(_context,
                StoredProcedureNames.UpdateGenderByDenderId, inputParamNames, inputParamValues, outputParamNames,
                outputParamValues);
            var re = new JsonResult(outParams);
            return Ok(re);
            //return NoContent();
        }

        // POST: api/Genders
        [HttpPost]
        public IActionResult PostGenders([FromBody] Genders genders)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var spName = "sp_create_Gender";
            string[] inputParamNames = {"GenderName"};
            object[] inputParamValues = {genders.Gender};
            string[] outputParamNames = {"ErrorCode", "ErrorMessage"};
            object[] outputParamValues = {0, ""};

            var outParams = DataReaderExtensions.ExecuteStoredProcedure(_context, spName, inputParamNames,
                inputParamValues, outputParamNames, outputParamValues);
            var re = new JsonResult(outputParamValues);
            return Ok(re);
        }

        // DELETE: api/Genders/5
        [HttpDelete("{GenderName}")]
        public IActionResult DeleteGenders([FromRoute] string GenderName)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string[] inputParamNames = {"GenderName"};
            object[] inputParamValues = {GenderName};
            string[] outputParamNames = {"ErrorCode", "ErrorMessage"};
            object[] outputParamValues = {0, ""};

            var outParams = DataReaderExtensions.ExecuteStoredProcedure(_context, StoredProcedureNames.DeleteGenderById,
                inputParamNames,
                inputParamValues, outputParamNames, outputParamValues);
            var re = new JsonResult(outputParamValues);
            return Ok(re);
        }

        private bool GendersExists(int id)
        {
            return _context.Genders.Any(e => e.GenderId == id);
        }
    }
}