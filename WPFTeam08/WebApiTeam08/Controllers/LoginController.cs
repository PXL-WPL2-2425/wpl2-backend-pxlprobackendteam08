using ClassLibrary1.Business;
using ClassLibTeam08.Business.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiTeam08.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        public ActionResult Students(string firstName, string lastName, string username, string email, string address, string password, string birthday, string phone)
        {
            var students = Logins.Add(firstName, lastName, username, email, address, password, birthday, phone);
            return Ok(students);
        }
    }
}