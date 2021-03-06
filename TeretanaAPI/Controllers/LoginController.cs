using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeretanaAPI.Models;

namespace TeretanaAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Login")]
    public class LoginController : Controller
    {
        private readonly TeretanaContext _context;

        public LoginController(TeretanaContext context)
        {
            _context = context;
        }

        // GET: api/Login
        [HttpGet]
        public IEnumerable<Users> GetUsers()
        {
            return _context.Users;
        }

        // GET: api/Login/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var users = await _context.Users.SingleOrDefaultAsync(m => m.UserId == id);

            if (users == null)
                return NotFound();


            return Ok(users);
        }

        // PUT: api/Login/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers([FromRoute] int id, [FromBody] Users users)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != users.UserId)
                return BadRequest();

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // POST: api/Login
        [HttpPost]
        public IEnumerable<Users> PostUsers([FromBody] Users users)
        {
            if (!ModelState.IsValid)
                return null;
            string[] inputParamNames =
            {
                "Mail", "Password"
            };
            object[] inputParamValues =
            {
                users.Mail, users.UserPassword
            };
            //string[] outputParamNames = { "UserType", "ErrorCode", "ErrorMessage" };
            //object[] outputParamValues = { -1, 0, "" };

            //var outParams = DataReaderExtensions.ExecuteStoredProcedure(_context, StoredProcedureNames.LogIn, inputParamNames,
            //    inputParamValues, outputParamNames, outputParamValues);
            //var re = new JsonResult(outputParamValues);

            var user = _context.Set<Users>().FromSql("sp_login_select @Mail = {0}, @Password = {1}", users.Mail,
                users.UserPassword);

            //try
            //{
            //    if ((Int32.Parse(outParams[0].ToString()) < 0))
            //    {
            //        return Ok(out)//  BadRequest("Invalid email or password!");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //    throw;
            //}


            return user;
            //_context.Users.Add(users);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetUsers", new { id = users.UserId }, users);
        }

        // DELETE: api/Login/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var users = await _context.Users.SingleOrDefaultAsync(m => m.UserId == id);
            if (users == null)
                return NotFound();

            _context.Users.Remove(users);
            await _context.SaveChangesAsync();

            return Ok(users);
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}