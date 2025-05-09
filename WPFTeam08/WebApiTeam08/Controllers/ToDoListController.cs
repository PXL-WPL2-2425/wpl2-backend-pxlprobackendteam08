using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ClassLibrary1.Business;


namespace WebApiTeam08.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        [HttpGet("GetToDoList")]
        public ActionResult GetToDoList(int id)
        {
            var result = ToDoList.GetToDoList(id);
            string JSONresult = JsonConvert.SerializeObject(result);
            return Ok(JSONresult);
        }
    }
}
