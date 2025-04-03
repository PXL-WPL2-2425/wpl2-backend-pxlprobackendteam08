using ClassLibTeam08.Business;
using ClassLibTeam08.Data.Framework;
using Microsoft.AspNetCore.Mvc;

namespace WebApiTeam08.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        [HttpGet("GetTasks")]
        public ActionResult SelectTasksByGroup(int groupId)
        {
            SelectResult tasks = Tasks.GetTasksByGroup(groupId);
            return Ok(tasks);
        }
    }
}
