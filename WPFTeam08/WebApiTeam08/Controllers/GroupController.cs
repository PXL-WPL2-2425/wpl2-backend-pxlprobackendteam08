using ClassLibTeam08.Business.Entities;
using ClassLibTeam08.Data.Framework;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using WebApiTeam08.ViewModels;
using ClassLibrary1.Business;
using ClassLibTeam08.Business;


namespace WebApiTeam08.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        [HttpGet("GetGroupMembers")]
        public ActionResult SelectGroupMembersByID(int ID)
        {
            var result = GroupMembers.GetGroupMembers(ID);
            string JSONresult = JsonConvert.SerializeObject(result);
            return Ok(JSONresult);
        }

        [HttpGet("GetMemberByID")]
        public ActionResult GetMemberByID(int ID)
        {
            var result = GroupMembers.GetUserIDOfMember(ID);
            string JSONresult = JsonConvert.SerializeObject(result);
            return Ok(JSONresult);
        }
        [HttpGet("GetAllMembers")]
        public ActionResult GetAllMembers()
        {
            var members = GroupMembers.GetAllMembers();
            string JSONresult = JsonConvert.SerializeObject(members);
            return Ok(JSONresult);
        }
    }
}
