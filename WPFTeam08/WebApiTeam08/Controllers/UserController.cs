using ClassLibTeam08.Business.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiTeam08.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult Students(int ID)
        {
            var students = Users.GetUser(ID);
            return Ok(students);
        }
    }
}
