using ClassLibTeam08.Business;
using ClassLibTeam08.Business.Entities;
using ClassLibTeam08.Data.Framework;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using System.Data;

using System.Threading.Tasks;

using WebApiTeam08.ViewModels;


namespace WebApiTeam08.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        [HttpPost("PostTask")]
        public ActionResult AddTask(TaskViewModel taskViewModel) 
        {
            var result = Tasks.AddTask(taskViewModel.GroupID, taskViewModel.TaskName, taskViewModel.TaskDescription, taskViewModel.TaskStatus, taskViewModel.TaskType, taskViewModel.DeadLine, taskViewModel.Reminder, taskViewModel.Assigned);
            string JSONresult = JsonConvert.SerializeObject(result);
            return Ok(JSONresult);
        }

        [HttpDelete("DeleteTask")]
        public ActionResult DeleteTask(int taskID)
        {        
            var result = Tasks.DeleteTask(taskID);
            string JSONresult = JsonConvert.SerializeObject(result);
            return Ok(JSONresult);
        }

        [HttpPut("UpdateTask")]
        public ActionResult UpdateTask(TaskViewModel taskViewModel)
        {
            UpdateResult result = Tasks.UpdateTask(taskViewModel.TaskName, taskViewModel.TaskDescription, taskViewModel.TaskStatus, taskViewModel.TaskType, taskViewModel.Reminder, taskViewModel.Assigned, taskViewModel.TaskId, taskViewModel.DeadLine);
            string JSONresult = JsonConvert.SerializeObject(result);
            return Ok(JSONresult);  
        }

        [HttpGet("GetTasks")]
        public ActionResult SelectTasksByGroup(int groupId)
        {
            SelectResult tasks = Tasks.GetTasksByGroup(groupId);
            string JSONresult = JsonConvert.SerializeObject(tasks);
            return Ok(JSONresult);
        }

        [HttpGet("GetAllTasks")]

        public ActionResult GetAllTasks()
        {
            var tasks = Tasks.GetAllTasks();
            string JSONresult = JsonConvert.SerializeObject(tasks);
            return Ok(JSONresult);
        }
    }
}
