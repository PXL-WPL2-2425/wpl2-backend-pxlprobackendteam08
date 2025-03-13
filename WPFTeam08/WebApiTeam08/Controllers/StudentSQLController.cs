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
        

        [HttpGet]
        public ActionResult GetAllStudents()
        {

            var result = Users.GetUser(2);



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
