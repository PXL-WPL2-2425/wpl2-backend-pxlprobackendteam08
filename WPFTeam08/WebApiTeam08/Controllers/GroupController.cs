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
    public class GroupMemberController : ControllerBase
    {
        [HttpGet("GetGroupMembers")]
        public ActionResult SelectGroupMembersByID(int ID)
        {
            var result = GroupMembers.GetGroupMembers(ID);
            string JSONresult = JsonConvert.SerializeObject(result);
            return Ok(JSONresult);
        }
    }
}
