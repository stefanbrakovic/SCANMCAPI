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
    [Route("api/UserTypes")]
    public class UserTypesController : Controller
    {
        private readonly TeretanaContext _context;

        public UserTypesController(TeretanaContext context)
        {
            _context = context;
        }

        // GET: api/UserTypes
        [HttpGet]
        public IEnumerable<UserTypes> GetUserTypes()
        {
            //Both ways are ok
            //int ErrorCode = 0;
            //string ErrorMessage = "";
            //var userTypes = _context.Set<UserTypes>().FromSql("dbo.sp_get_all_UserTypes @ErrorCode = {0} OUTPUT, @ErrorMessage = {1} OUTPUT", 0, 
            //return userTypes;
            return _context.UserTypes;
        }

        // GET: api/UserTypes/5
        [HttpGet("{TypeName}")]
        public async Task<IActionResult> GetUserTypes([FromRoute] string TypeName)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //var userTypes = _context.Set<UserTypes>().FromSql(@"EXEC [dbo].[sp_get_UserTypeDescription_by_TypeName] @TypeName = {0}, @ErrorCode = {1} OUTPUT, @ErrorMessage = {2} OUTPUT",TypeName,0,"");//"dbo.sp_get_UserTypeDescription_by_TypeName @TypeName = {0}, @TypeDescription = {1} OUTPUT, @ErrorCode = {2} OUTPUT, @ErrorMessage = {3} OUTPUT", TypeName, TypeDescription, 0, "");

            //string userDescription = userTypes.FirstOrDefault().TypeDescription;
            var userTypes = await _context.UserTypes.SingleOrDefaultAsync(m => m.TypeName == TypeName);

            if (userTypes == null)
                return NotFound();
            return Ok(userTypes);
        }


        // PUT: api/UserTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserTypes([FromRoute] int id, [FromBody] UserTypes userTypes)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != userTypes.UserTypeId)
                return BadRequest("User id does not match");


            string[] inputParamNames =
            {
                "TypeId", "TypeName", "TypeDescription"
            };
            object[] inputParamValues =
            {
                id, userTypes.TypeName, userTypes.TypeDescription
            };
            string[] outputParamNames = {"ErrorCode", "ErrorMessage"};
            object[] outputParamValues = {0, ""};

            var outParams = DataReaderExtensions.ExecuteStoredProcedure(_context,
                StoredProcedureNames.UpdateUserTypeById, inputParamNames,
                inputParamValues, outputParamNames, outputParamValues);
            var re = new JsonResult(outputParamValues);
            return Ok(re);


            //_context.Entry(userTypes).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!UserTypesExists(id))
            //        return NotFound();
            //    throw;
            //}

            //return NoContent();
        }

        // POST: api/UserTypes
        [HttpPost]
        public IActionResult PostUserTypes([FromBody] UserTypes userTypes)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            #region old code

            //string ErrorMessage = "";
            //string action = string.Format("sp_create_new_UserType @TypeName = {0}, @TypeDescription = {1}, @ErrorCode = {2} output, @ErrorMessage = {3} output", userTypes.TypeName, userTypes.TypeDescription,0, "");
            //await _context.Database.ExecuteSqlCommandAsync("sp_create_new_UserType @TypeName = {0}, @TypeDescription = {1}, @ErrorCode = {2} output, @ErrorMessage = {3} output",parameters: new object[] {userTypes.TypeName,userTypes.TypeDescription,ErrorCode,ErrorMessage } );
            //_context.UserTypes.Add(userTypes);
            //await _context.SaveChangesAsync();
            //string ErrorMessage = "";
            //int ErrorCode = 0;


            //string[] inputParamNames = new string[] { };
            //object[] inputParamValues = new object[] { };
            //string[] outputParamNames = new string[] { };
            //object[] outputParamValues = new object[] { };

            //using (_context)
            //{
            //    //Had to go this route since EF Code First doesn't support output parameters 
            //    //returned from sprocs very well at this point
            //    using (_context.Database.GetDbConnection())
            //    {
            //        _context.Database.OpenConnection();
            //        DbCommand cmd = _context.Database.GetDbConnection().CreateCommand();
            //        cmd.CommandText = "sp_create_new_UserType";
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.Add(new SqlParameter("TypeName", userTypes.TypeName));
            //        cmd.Parameters.Add(new SqlParameter("TypeDescription", userTypes.TypeDescription));
            //        var ErrorCodeParam = new SqlParameter("ErrorCode", 0) { Direction = ParameterDirection.Output };
            //        var ErrorMessageParam = new SqlParameter("ErrorMessage", "") { Direction = ParameterDirection.Output };
            //        cmd.Parameters.Add(ErrorCodeParam);
            //        cmd.Parameters.Add(ErrorMessageParam);

            //        List<UserTypes> tasks;
            //        using (var reader = cmd.ExecuteReader())
            //        {
            //            tasks = DataBaseManipulation.DataReaderExtensions.MapToList<UserTypes>(reader);
            //        }
            //        //Access output variable after reader is closed
            //        ErrorMessage = (ErrorMessageParam.Value == null) ? "" : ErrorMessageParam.Value.ToString();
            //        ErrorCode = (string.IsNullOrEmpty(ErrorCodeParam.Value.ToString())) ? ErrorCode : Int32.Parse(ErrorCodeParam.Value.ToString());
            //        return Ok(ErrorCode);
            //    }
            //}

            #endregion

            var spName = "sp_create_new_UserType";
            string[] inputParamNames = {"TypeName", "TypeDescription"};
            object[] inputParamValues = {userTypes.TypeName, userTypes.TypeDescription};
            string[] outputParamNames = {"ErrorCode", "ErrorMessage"};
            object[] outputParamValues = {0, ""};

            var outParams = DataReaderExtensions.ExecuteStoredProcedure(_context, spName, inputParamNames,
                inputParamValues, outputParamNames, outputParamValues);
            var re = new JsonResult(outputParamValues);
            return Ok(re);
            // return CreatedAtAction("GetUserTypes", new { id = userTypes.UserTypeId }, userTypes);
        }

        // DELETE: api/UserTypes/TypeName
        [HttpDelete("{TypeName}")]
        public IActionResult DeleteUserTypes([FromRoute] string TypeName)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            #region old code

            //var userTypes = await _context.UserTypes.All<UserTypes>(m => m.TypeName.Equals(TypeName));// SingleOrDefaultAsync(m => m.TypeName.Equals(TypeName));
            //if (userTypes == null)
            //{
            //    return NotFound();
            //}

            //_context.UserTypes.Remove(userTypes);
            //await _context.SaveChangesAsync();

            //return Ok(userTypes);
            //using (_context)
            //{
            //    //Had to go this route since EF Code First doesn't support output parameters 
            //    //returned from sprocs very well at this point
            //    using (_context.Database.GetDbConnection())
            //    {
            //        _context.Database.OpenConnection();
            //        DbCommand cmd = _context.Database.GetDbConnection().CreateCommand();
            //        cmd.CommandText = "sp_delete_UserType_by_TypeName";
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.Parameters.Add(new SqlParameter("TypeName", TypeName));
            //        var ErrorCodeParam = new SqlParameter("ErrorCode", 0) { Direction = ParameterDirection.Output };
            //        var ErrorMessageParam = new SqlParameter("ErrorMessage", "") { Direction = ParameterDirection.Output };
            //        cmd.Parameters.Add(ErrorCodeParam);
            //        cmd.Parameters.Add(ErrorMessageParam);

            //        List<UserTypes> tasks;
            //        using (var reader = cmd.ExecuteReader())
            //        {
            //            tasks = DataBaseManipulation.DataReaderExtensions.MapToList<UserTypes>(reader);
            //        }
            //        //Access output variable after reader is closed
            //        ErrorMessage = (ErrorMessageParam.Value == null) ? "" : ErrorMessageParam.Value.ToString();
            //        ErrorCode = (string.IsNullOrEmpty(ErrorCodeParam.Value.ToString())) ? 0 : Int32.Parse(ErrorCodeParam.Value.ToString());

            //    }
            //}

            #endregion

            var spName = "sp_delete_UserType_by_TypeName";
            string[] inputParamNames = {"TypeName"};
            object[] inputParamValues = {TypeName};
            string[] outputParamNames = {"ErrorCode", "ErrorMessage"};
            object[] outputParamValues = {0, ""};
            outputParamValues = DataReaderExtensions.ExecuteStoredProcedure(_context, spName, inputParamNames,
                inputParamValues, outputParamNames, outputParamValues);

            var re = new JsonResult(outputParamValues);

            return Ok(re);
        }


        private bool UserTypesExists(int id)
        {
            return _context.UserTypes.Any(e => e.UserTypeId == id);
        }
    }
}