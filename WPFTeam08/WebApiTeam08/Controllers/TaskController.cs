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
        public ActionResult DeleteTask([FromBody] DeleteTaskRequest dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return validation errors
            }
            var result = Tasks.DeleteTask(dto.ServiceID);
            return Ok(result);

        }

        [HttpPut("UpdateTask")]
        public ActionResult UpdateTask([FromBody] UpdateTaskRequest dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return validation errors
            }

            SelectResult result = Tasks.UpdateTask(dto.ServiceID, dto.ServiceName, dto.Description);
            return Ok(result);  
            //SelectResult tasks = Tasks.UpdateTask(SupplierId, ServiceName, Description);
            //string JSONresult = JsonConvert.SerializeObject(tasks);
            //return Ok(JSONresult);
        }

        [HttpGet("GetTasks")]
        public ActionResult SelectTasksByGroup(int TaskId)
        {
            SelectResult tasks = Tasks.GetTasksByGroup(groupId);
            string JSONresult = JsonConvert.SerializeObject(tasks);
            return Ok(JSONresult);
        }
    }
}
