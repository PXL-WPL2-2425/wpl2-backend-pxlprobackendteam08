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
        [HttpGet("ChangeUser")]
        public ActionResult UpdateAllUserData(int id, string firstName, string lastName, string userName, string email, string adres, string wachtwoord, DateTime Birhday, string phone)
        {
            UpdateResult users = Users.UpdateUserData(id, firstName, lastName, userName, email, adres, wachtwoord, Birhday, phone);
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
            SelectResult users = Users.CheckLogin(loginViewmodel.Email, loginViewmodel.Wachtwoord);
            string JSONresult = JsonConvert.SerializeObject(users);
            return Ok(JSONresult);

        }
        [HttpGet("UserId")]
        public ActionResult<User> GetUserById(int userId)
        {
            var user = Users.GetUserById(userId);

            if (user == null)
            {
                return NotFound($"User with ID {userId} not found.");
            }

            return Ok(user);
        }
    }
}
