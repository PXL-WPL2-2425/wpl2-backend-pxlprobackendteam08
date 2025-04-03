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
        public ActionResult UsersAdd(string firstName, string lastName, string username, string email, string address, string password, DateTime birthday, string phone)
        {
            InsertResult users = Logins.Add(firstName, lastName, username, email, address, password, birthday, phone);
            string JSONresult = JsonConvert.SerializeObject(users);
            return Ok(users);
        }


       [HttpGet("AddLogin")]
        public ActionResult AddLogin(int UserID, DateTime loginTime)
        {
            string ipAdress = HttpContext.Connection.RemoteIpAddress.ToString();

            InsertResult users = Logins.AddLogin(UserID, loginTime, ipAdress);
            string JSONresult = JsonConvert.SerializeObject(users);
            return Ok(JSONresult);
        }

        [HttpGet("CountAllLogins")]
        public ActionResult GetAllLogins()
        {
            AggregateResult result = Logins.CountAll();
            string JSONresult = JsonConvert.SerializeObject(result);
            return Ok(JSONresult);
        }

        [HttpGet("GetAllLoginsByDate")]
        public ActionResult GetAllLoginsByDate()
        {
            SelectResult result = Logins.GeLoginsByDate();
            string JSONresult = JsonConvert.SerializeObject(result);
            return Ok(JSONresult);
        }


    }
}