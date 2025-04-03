using ClassLibrary1.Business;
using ClassLibTeam08.Business.Entities;
using ClassLibTeam08.Data.Framework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApiTeam08.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult SelectUserByID_DEBUG(int ID)
        {
            var students = Users.GetUser(ID);
            return Ok(students);
        }
        [HttpGet("ChangeRole")]
        public ActionResult ChangeRole(string rol, string email, string token)
        {
            
            UpdateResult result = Users.ChangeRole(rol, email);

            if (token == result.Token)
            {
                return Ok(result);
            }
            

            return BadRequest("token is not valid");


        }

        [HttpGet("CheckRole")]
        public ActionResult CheckRole(string email)
        {
            SelectResult users = Users.CheckRoles(email);
            string JSONresult = JsonConvert.SerializeObject(users);
            return Ok(JSONresult);
        }

        [HttpGet("SendPasswordChangeEmail")]
        public ActionResult SendPasswordChangeEmail(string email)
        {
            SelectResult users = Users.SendConfirmationEmail(email);
            string JSONresult = JsonConvert.SerializeObject(users);
            return Ok(JSONresult);
        }

        [HttpGet("ChangePassword")]
        public ActionResult ChangePasswordOfUser(string email, string password)
        {
            UpdateResult users = Users.ChangePassword(email, password);
            string JSONresult = JsonConvert.SerializeObject(users);
            return Ok(JSONresult);
        }


        [HttpPost("LoginUser")]
        public ActionResult LoginUser(LoginViewmodel loginViewmodel)
        {
            SelectResult select = Users.CheckLogin(loginViewmodel.Email, loginViewmodel.Wachtwoord);
            string JSONresult = JsonConvert.SerializeObject(select);
            return Ok(JSONresult);
        }

        [HttpGet("userId")]
        public ActionResult<User> GetUserById(int userId)
        {
            var user = Users.GetUserById(userId);

            if (user == null)
            {
                return NotFound($"Role with ID {userId} not found.");
            }

            return Ok(user);

        }
    }
}
