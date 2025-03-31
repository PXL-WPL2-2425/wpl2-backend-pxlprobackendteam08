using ClassLibrary1.Business;
using ClassLibTeam08.Business.Entities;
using ClassLibTeam08.Data.Framework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApiTeam08.ViewModels;

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
        [HttpGet("AddRole")]
        public ActionResult AddRole(string rol, string email)
        {
            UpdateResult users = Users.AddRoles(rol, email);
            return Ok(users);
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

        [HttpGet("{userId}")]
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
