using ClassLibTeam08.Business;
using ClassLibTeam08.Business.Entities;
using ClassLibTeam08.Data.Framework;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApiTeam08.ViewModels;
using WebApiTeam08.DTOs;

namespace WebApiTeam08.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        [HttpPost("PostTask")]
        public ActionResult AddTask([FromBody] TaskRequest dto) // Use the alias to specify the correct type
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return validation errors
            }

            var result = Tasks.AddTask(dto);


            if (!result.Success)
                return StatusCode(500, result.Message);

            return Ok(result);
        }

        [HttpDelete("DeleteTask")]
        public ActionResult DeleteTask(int TaskId)
        {
            SelectResult tasks = Tasks.DeleteTask(TaskId);
            string JSONresult = JsonConvert.SerializeObject(tasks);
            return Ok(JSONresult);
        }

        [HttpPut("UpdateTask")]
        public ActionResult UpdateTask(int TaskId, int SupplierId, string ServiceName, string Description)
        {
            SelectResult tasks = Tasks.UpdateTask(SupplierId, ServiceName, Description);
            string JSONresult = JsonConvert.SerializeObject(tasks);
            return Ok(JSONresult);
        }

        [HttpGet("GetTasks")]
        public ActionResult SelectTasksByGroup(int TaskId)
        {
            SelectResult tasks = Tasks.GetTasksByGroup(TaskId);
            return Ok(tasks);
        }
    }
}
