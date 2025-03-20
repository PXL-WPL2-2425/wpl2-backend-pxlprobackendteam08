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
    }
}
