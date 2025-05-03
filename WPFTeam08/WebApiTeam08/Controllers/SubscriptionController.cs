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
        public ActionResult AddSubsriptions(SubscriptionViewModel subscription)
        {
            InsertResult subs = Subscriptions.AddSubscription(subscription.Email);
            string JSONresult = JsonConvert.SerializeObject(subs);
            return Ok(JSONresult);
        }
        [HttpDelete("DeleteSubscription")]
        public ActionResult DeleteSubscriptions(SubscriptionViewModel subscription)
        {
            DeleteResult subs = Subscriptions.DeleteSubscription(subscription.GroupID);
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
        public ActionResult UpdateSubscriptions(SubscriptionViewModel subscription)
        {
            UpdateResult subs = Subscriptions.UpdateSubscription(subscription.StartDate, subscription.EndDate, subscription.RenewDate, subscription.Status, subscription.AutoRenewal, subscription.Email);
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
        [HttpGet("CountAllSubscriptions")]
        public ActionResult GetAllSubscriptions()
        {
            AggregateResult result = Subscriptions.CountAll();
            string JSONresult = JsonConvert.SerializeObject(result);
            return Ok(JSONresult);
        }
        [HttpGet("GetSubscriptionByMonth")]
        public ActionResult GetSubscriptionByMonth()
        {
            SelectResult result = Subscriptions.GetSubscriptionsMonthly();
            string JSONresult = JsonConvert.SerializeObject(result);
            return Ok(JSONresult);
        }
    }

}
