using ClassLibrary08.Data.Framework;
using ClassLibrary1.Data;
using ClassLibTeam08.Data.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Business
{
    public static class Subscriptions
    {
        public static SelectResult GetSubscription(int id)
        {
            SubscriptionData data = new SubscriptionData();
            SelectResult result = data.SelectByID(id);
            return result;
        }

        public static DeleteResult DeleteSubscription(int id)
        {
            SubscriptionData data = new SubscriptionData();
            DeleteResult result = data.DeleteByID(id);
            return result;
        }

        public static InsertResult AddSubscription(int id)
        {
            SubscriptionData data = new SubscriptionData();
            InsertResult result = data.AddSubscription(id);
            return result;
        }

        public static UpdateResult UpdateSubscription(int id)
        {
            SubscriptionData data = new SubscriptionData();
            UpdateResult result = data.UpdateSubscription(id);
            return result;
        }
    }
}
