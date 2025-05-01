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
        [HttpPost("AddSubsription")]
        public ActionResult AddSubsriptions(string email)
        {
            InsertResult subs = Subscriptions.AddSubscription(email);
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
        [HttpGet("CancelSubscription")]
        public ActionResult CancelSubscription(string email)
        {
            UpdateResult subs = Subscriptions.CancelSubscription(email);
            string JSONresult = JsonConvert.SerializeObject(subs);
            return Ok(JSONresult);
        }
        [HttpPost("UpdateSubscription")]
        public ActionResult UpdateSubscriptions(DateTime startDate, DateTime endDate, DateTime renewDate, string status, string autoRenewal, string email)
        {
            UpdateResult subs = Subscriptions.UpdateSubscription(startDate, endDate, renewDate, status, autoRenewal, email);
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
