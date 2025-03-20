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
    public class LoginController : ControllerBase
    {
        [HttpGet("AddUser")]
        public ActionResult UsersAdd(string firstName, string lastName, string username, string email, string address, string password, string birthday, string phone)
        {
            InsertResult users = Logins.Add(firstName, lastName, username, email, address, password, birthday, phone);
            string JSONresult = JsonConvert.SerializeObject(users);
            return Ok(users);
        }

        [HttpGet("CheckLogin")]
        public ActionResult LoginUser(string email, string password)
        {
            SelectResult users = Logins.CheckLogin(email, password);
            string JSONresult = JsonConvert.SerializeObject(users);
            return Ok(JSONresult);
        }
    }
}