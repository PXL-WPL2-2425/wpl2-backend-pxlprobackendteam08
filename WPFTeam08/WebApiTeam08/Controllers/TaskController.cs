using ClassLibTeam08.Business;
using ClassLibTeam08.Business.Entities;
using ClassLibTeam08.Data.Framework;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApiTeam08.ViewModels;

namespace WebApiTeam08.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        [HttpPost("PostTask")]
        public ActionResult AddTask(int SupplierId, string ServiceName, string Description)
        {
            SelectResult tasks = Tasks.AddTask(SupplierId, ServiceName, Description);
            string JSONresult = JsonConvert.SerializeObject(tasks);
            return Ok(JSONresult);
        }

        [HttpGet("GetTasks")]
        public ActionResult SelectTasksByGroup(int groupId)
        {
            SelectResult tasks = Tasks.GetTasksByGroup(groupId);
            return Ok(tasks);
        }
    }
}
