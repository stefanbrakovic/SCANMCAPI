using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeretanaAPI.Models;
using TeretanaAPI.DataBaseManipulation;

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
            {
                return BadRequest(ModelState);
            }

            var genders = await _context.Genders.SingleOrDefaultAsync(m => m.GenderId == id);

            if (genders == null)
            {
                return NotFound();
            }

            return Ok(genders);
        }

        // PUT: api/Genders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenders([FromRoute] int id, [FromBody] Genders genders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != genders.GenderId)
            {
                return BadRequest();
            }

            _context.Entry(genders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GendersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Genders
        [HttpPost]
        public IActionResult PostGenders([FromBody] Genders genders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string spName = "sp_create_Gender";
            string[] inputParamNames = new string[] { "GenderName" };
            object[] inputParamValues = new object[] { genders.Gender };
            string[] outputParamNames = new string[] { "ErrorCode", "ErrorMessage" };
            object[] outputParamValues = new object[] { 0, "" };

            object[] outParams = DataBaseManipulation.DataReaderExtensions.executeStoredProcedure(_context, spName, inputParamNames, inputParamValues, outputParamNames, outputParamValues);
            JsonResult re = new JsonResult(outputParamValues);
            return Ok(re);
        }

        // DELETE: api/Genders/5
        [HttpDelete("{GenderName}")]
        public IActionResult DeleteGenders([FromRoute] string GenderName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string spName = "sp_delete_Gender";
            string[] inputParamNames = new string[] { "GenderName" };
            object[] inputParamValues = new object[] { GenderName };
            string[] outputParamNames = new string[] { "ErrorCode", "ErrorMessage" };
            object[] outputParamValues = new object[] { 0, "" };

            object[] outParams = DataBaseManipulation.DataReaderExtensions.executeStoredProcedure(_context, spName, inputParamNames, inputParamValues, outputParamNames, outputParamValues);
            JsonResult re = new JsonResult(outputParamValues);
            return Ok(re);
        }

        private bool GendersExists(int id)
        {
            return _context.Genders.Any(e => e.GenderId == id);
        }
    }
}