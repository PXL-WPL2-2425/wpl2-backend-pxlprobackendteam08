using ClassLibrary08.Data.Framework;
using ClassLibTeam08.Business.Entities;
using ClassLibTeam08.Data.Framework;
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
        [HttpGet("ChangeRole")]
        public ActionResult ChangeRole(string rol, string email, string emailAdmin, string token)
        {

            UpdateResult result = Users.ChangeRole(rol, emailAdmin, email, token);
            string JSONresult = JsonConvert.SerializeObject(result);
            return Ok(result);

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
            UpdateResult users = Users.ChangePassword(loginViewmodel.Email, loginViewmodel.Wachtwoord, loginViewmodel.token);
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

        [HttpPost("UpdateUser")]
        public ActionResult UpdateUser(UserViewModel user)
        {
            UpdateResult result = Users.UpdateUserData(user.ID, user.FirstName, user.LastName, user.UserName, user.Email, user.Address, user.Password, user.BirthDay, user.Phone, user.token);
            return Ok(result);
        }
        [HttpGet("Admin")]
        public ActionResult SelectAdmins()
        {
            SelectResult result = Users.Admins();
            string JSONresult = JsonConvert.SerializeObject(result);
            return Ok(JSONresult);
        }

        [HttpGet("SendMailToUser")]
        public ActionResult SendMailToUser(string toEmail, string subject, string body, string name)
        {
            EmailResult result = Users.SendMailTouser(toEmail, subject, body, name);
            string JSONresult = JsonConvert.SerializeObject(result);
            return Ok(JSONresult);
        }

        [HttpDelete("DeleteUser")]
        public ActionResult DeleteUser(UserViewModel user)
        {
            DeleteResult result = Users.DeleteUser(user.ID);
            string JSONresult = JsonConvert.SerializeObject(result);
            return Ok(JSONresult);
        }
        [HttpGet("UpdateUserAsAdmin")]
        public ActionResult UpdateUserAsAdmin(int id, string firstName, string lastName,  string email, string adres, DateTime Birhday, string phone, string rol)
        {
            UpdateResult result = Users.UpdateUserDataAsAdmin(id, firstName, lastName, email, adres, Birhday, phone, rol);
            string JSONresult = JsonConvert.SerializeObject(result);
            return Ok(JSONresult);
        }
    }
}
