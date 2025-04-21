using ClassLibrary1.Business;
using ClassLibTeam08.Business.Entities;
using ClassLibTeam08.Data.Framework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApiTeam08.ViewModels;
using Isopoh;


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
            EmailResult users = Users.SendConfirmationEmail(email);
            string JSONresult = JsonConvert.SerializeObject(users);
            return Ok(JSONresult);
        }

        [HttpPost("ChangePassword")]
        public ActionResult ChangePasswordOfUser(LoginViewmodel loginViewmodel)
        {
            UpdateResult users = Users.ChangePassword(loginViewmodel.Email, loginViewmodel.Wachtwoord);
            string JSONresult = JsonConvert.SerializeObject(users);
            return Ok(JSONresult);
        }


        [HttpPost("LoginUser")]
        public ActionResult LoginUser(LoginViewmodel loginViewmodel)
        {
          
            SelectResult users = Users.CheckLogin(loginViewmodel.Email, loginViewmodel.Wachtwoord);

            string JSONresult = JsonConvert.SerializeObject(users);
            return Ok(JSONresult);
        }

        [HttpGet("userId")]
        public ActionResult GetUserById(int userId)
        {
            var user = Users.GetUserById(userId); 
            if (user == null)
            {
                return NotFound($"Gebruiker met ID {userId} niet gevonden.");
            }

            string JSONresult = JsonConvert.SerializeObject(user);
            return Ok(JSONresult);
        }

        [HttpGet("Admin")]
        public ActionResult SelectAdmins()
        {
            SelectResult result = Users.Admins();
            string JSONresult = JsonConvert.SerializeObject(result);
            return Ok(JSONresult);
        }

        [HttpGet("SendConfirmEmail")]
        public ActionResult SendConfirmEmail(string toEmail, string subject, string body)
        {
            EmailResult result = Users.SendOrderConfirmation(toEmail, subject, body);
            string JSONresult = JsonConvert.SerializeObject(result);
            return Ok(JSONresult);
        }
    }
}
