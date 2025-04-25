using ClassLibrary08.Data.Framework;
using ClassLibrary1.Business;
using ClassLibTeam08.Business.Entities;
using ClassLibTeam08.Data.Framework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApiTeam08.ViewModels;

namespace WebApiTeam08.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        [HttpGet("AddSubsription")]
        public ActionResult AddSubsriptions(int groupId)
        {
            InsertResult subs = Subscriptions.AddSubscription(groupId);
            string JSONresult = JsonConvert.SerializeObject(subs);
            return Ok(JSONresult);
        }
        [HttpGet("DeleteSubscription")]
        public ActionResult DeleteSubscriptions(int groupId)
        {
            DeleteResult subs = Subscriptions.DeleteSubscription(groupId);
            string JSONresult = JsonConvert.SerializeObject(subs);
            return Ok(JSONresult);
        }
        [HttpGet("UpdateSubscription")]
        public ActionResult UpdateSubscriptions(int groupId)
        {
            UpdateResult subs = Subscriptions.UpdateSubscription(groupId);
            string JSONresult = JsonConvert.SerializeObject(subs);
            return Ok(JSONresult);
        }
        [HttpGet("GetSubscriptions")]
        public ActionResult GetSubscriptions()
        {
            SelectResult subs = Subscriptions.GetSubscription();
            string JSONresult = JsonConvert.SerializeObject(subs);
            return Ok(JSONresult);
        }

    }

}
