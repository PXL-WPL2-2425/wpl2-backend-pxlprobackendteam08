using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ClassLibrary1.Business;
using ClassLibTeam08.Business;
using WebApiTeam08.ViewModels;


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

        [HttpPost("PostToDoList")]
        public ActionResult PostToDoList(int id, string taskName, string assignedTo, string noticeFor, int isRepeat, string recurEvery, string description, DateTime executeBefore, DateTime executedTime)
        {
            var result = ToDoList.PostToDoList(id, taskName, assignedTo, noticeFor, isRepeat, recurEvery, description, executeBefore,  executedTime);
            string JSONresult = JsonConvert.SerializeObject(result);
            return Ok(JSONresult);
        }
    }
}
