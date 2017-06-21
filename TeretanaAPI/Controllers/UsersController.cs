using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using TeretanaAPI.Constants;
using TeretanaAPI.DataBaseManipulation;
using TeretanaAPI.Models;

namespace TeretanaAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly TeretanaContext _context;

        public UsersController(TeretanaContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<Users> GetUsers()
        {
            return _context.Users;
        }

        // GET: api/Users/5
        [HttpGet("{cardNumber}")]
        public async Task<IActionResult> GetUsers([FromRoute] string cardNumber)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var users = await _context.Users.SingleOrDefaultAsync(m => m.CardNumber == cardNumber);
            var userProfile = await _context.UserProfile.SingleOrDefaultAsync(m => m.CardNumber == cardNumber);
            if (userProfile == null)
                return Ok(Json("User has no profile"));
            if (users == null)
                return NotFound();

            var email = userProfile.Mail;
            var numberOfUsedTermins = userProfile.NumberOfUsedTermins;
            var dateTo = userProfile.DateTo;
            var numberOfPaidTermins = 12; //OVOCE SE VEROVATNO ISTO CITATI IZ BAZE

            if (numberOfUsedTermins < numberOfPaidTermins)
            {
                if ((dateTo - DateTime.Now).TotalDays < 20) //SAMO DRUGI DEO IF-a CE BTI USLOV KASNIJE
                    try
                    {
                        SendEmail(email);
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }

                return Ok(true);
            }
            return Ok(false); //OVAJ DEO NISAM SIGURNA
        }

        // PUT: api/Users/5
        [HttpPut("{userMail}")]
        public IActionResult PutUsers([FromRoute] string userMail, [FromBody] Users users)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (userMail != users.Mail)
                return BadRequest();


            string[] inputParamNames =
            {
                "FirstName", "LastName", "Telephone", "Mail", "UserTypeId", "GenderId", "DateOfBirth", "Street", "City",
                "StreetNumber"
            };
            object[] inputParamValues =
            {
                users.FirstName, users.LastName, users.Telephone, users.Mail, users.UserTypeId, users.GenderId,
                users.DateOfBirth, users.Street, users.City, users.StreetNumber
            };
            string[] outputParamNames = {"ErrorCode", "ErrorMessage"};
            object[] outputParamValues = {0, ""};

            var outParams = DataReaderExtensions.ExecuteStoredProcedure(_context, StoredProcedureNames.UpdateUserByMail,
                inputParamNames,
                inputParamValues, outputParamNames, outputParamValues);
            var re = new JsonResult(outputParamValues);
            return Ok(re);


            //_context.Entry(users).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!UsersExists(id))
            //        return NotFound();
            //    throw;
            //}

            //return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public IActionResult PostUsers([FromBody] Users users)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var spName = "sp_create_new_User";
            string[] inputParamNames =
            {
                "FirstName", "LastName", "Telephone", "Mail", "UserPassword", "UserTypeId", "GenderId", "DateOfBirth",
                "Street", "City", "StreetNumber"
            };
            object[] inputParamValues =
            {
                users.FirstName, users.LastName, users.Telephone, users.Mail, users.UserPassword, users.UserTypeId,
                users.GenderId, users.DateOfBirth, users.Street, users.City, users.StreetNumber
            };
            string[] outputParamNames = {"ErrorCode", "ErrorMessage"};
            object[] outputParamValues = {0, ""};

            var outParams = DataReaderExtensions.ExecuteStoredProcedure(_context, spName, inputParamNames,
                inputParamValues, outputParamNames, outputParamValues);
            var re = new JsonResult(outputParamValues);
            return Ok(re);

            //_context.Users.Add(users);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetUsers", new { id = users.UserId }, users);
        }

        // DELETE: api/Users/123456a789s
        [HttpDelete("{cardNumber}")]
        public async Task<IActionResult> DeleteUsers([FromRoute] string cardNumber)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var users = await _context.Users.SingleOrDefaultAsync(m => m.CardNumber == cardNumber);
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


        private void SendEmail(string email)
        {
            try
            {
                var emailMessage = new MimeMessage();

                emailMessage.From.Add(new MailboxAddress("Vas TIM TERETANA NFC", "teretananfc@gmail.com"));
                emailMessage.To.Add(new MailboxAddress(email));
                emailMessage.Subject = "Vasa kartica uskoro istice";
                emailMessage.Body = new TextPart("plain") {Text = "Dragi nasi korisnici, produzite svoju karticu!"};

                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    client.Connect("smtp.gmail.com", 587, false);

                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate("teretananfc", "test123456");

                    client.Send(emailMessage);
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}