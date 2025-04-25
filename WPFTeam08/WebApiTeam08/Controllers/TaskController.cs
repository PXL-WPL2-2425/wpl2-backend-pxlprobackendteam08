using ClassLibTeam08.Business;
using ClassLibTeam08.Business.Entities;
using ClassLibTeam08.Data.Framework;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApiTeam08.ViewModels;
using WebApiTeam08.DTOs;
using ClassLibrary1.DTOs;

namespace WebApiTeam08.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        [HttpPost("PostTask")]
        public ActionResult AddTask(TaskViewModel taskViewModel) 
        {
            var result = Tasks.AddTask(taskViewModel.Groupid, taskViewModel.Taskname, taskViewModel.Taskdescription, taskViewModel.Taskstatus, taskViewModel.Tasktype);

            return Ok(result);
        }

        [HttpDelete("DeleteTask")]
        public ActionResult DeleteTask(TaskViewModel taskViewModel)
        {
         
            var result = Tasks.DeleteTask(taskViewModel.Groupid);
            return Ok(result);

        }

        [HttpPut("UpdateTask")]
        public ActionResult UpdateTask(TaskViewModel taskViewModel)
        {
            SelectResult result = Tasks.UpdateTask(taskViewModel.Groupid, taskViewModel.Taskname, taskViewModel.Taskdescription, taskViewModel.Taskstatus, taskViewModel.Tasktype);
            return Ok(result);  
            //SelectResult tasks = Tasks.UpdateTask(SupplierId, ServiceName, Description);
            //string JSONresult = JsonConvert.SerializeObject(tasks);
            //return Ok(JSONresult);
        }

        [HttpGet("GetTasks")]
        public ActionResult SelectTasksByGroup(int groupId)
        {
            SelectResult tasks = Tasks.GetTasksByGroup(groupId);
            string JSONresult = JsonConvert.SerializeObject(tasks);
            return Ok(JSONresult);
        }
    }
}
