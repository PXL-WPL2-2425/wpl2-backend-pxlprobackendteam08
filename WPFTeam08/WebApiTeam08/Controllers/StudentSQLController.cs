using ClassLibTeam08.Business.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApiTeam08.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentSQLController : ControllerBase
    {      
        [HttpGet("id")]
        public ActionResult GetByID(int ID)
        {
            var result = Users.GetUser(ID);
            if (result.Succeeded)
            {
                var students = result.DataTable;
                string JSONresult = JsonConvert.SerializeObject(students);
                return Ok(JSONresult);
            }

            return NotFound();
        }

        [HttpGet("ChangeEmail")]
        public ActionResult GetByID(int id, string password)
        {
            var result = Users.ChangePassWord(id, password);
            if (result.Succeeded)
            {
                var students = result.DataTable;
                string JSONresult = JsonConvert.SerializeObject(students);
                return Ok(JSONresult);
            }

            return NotFound();
        }

    }
}
