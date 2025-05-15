using ClassLibrary08.Data.Framework;
using ClassLibrary1.Business.Entities;
using ClassLibrary1.Data;
using ClassLibTeam08.Data;
using ClassLibTeam08.Data.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Business
{
    public static class Subscriptions
    {
        public static SelectResult GetSubscription()
        {
            SubscriptionData data = new SubscriptionData();
            SelectResult result = data.SelectByID();
            return result;
        }

        public static DeleteResult DeleteSubscription(int id)
        {
            SubscriptionData data = new SubscriptionData();
            DeleteResult result = data.DeleteByGroupID(id);
            return result;
        }
        public static InsertResult AddSubscription(string email)
        {

            SubscriptionData data = new SubscriptionData();
            InsertResult result = data.AddSubscription(email);
            return result;
        }

        public static UpdateResult UpdateSubscription(DateTime startDate, DateTime endDate, DateTime renewDate, string status, string autoRenewal, string email)
        {
            SubscriptionData data = new SubscriptionData();
            UpdateResult result = data.UpdateSubscription(startDate, endDate, renewDate, status, autoRenewal, email);

            SelectResult selectResult = data.SelectSubscriptionByEmail(email);

            if (status != "free")
            {
                InvoiceData invoiceData = new InvoiceData();
                Invoice invoice = new Invoice();
                invoice.SubscriptionID = int.Parse(selectResult.DataTable.Rows[0][0].ToString());
                invoice.Statut = status;
                invoice.CreateDate = startDate;
                invoice.DeleteDate = endDate;
                invoice.InvoiceDate = renewDate;
                invoice.GroupID = int.Parse(selectResult.DataTable.Rows[0][1].ToString());

                invoiceData.Insert(invoice);

            }

            return result;
        }
        public static UpdateResult CancelSubscription(string email)
        {
            SubscriptionData data = new SubscriptionData();
            UpdateResult result = data.CancelSubscription(email);
            return result;
        }
        public static AggregateResult CountAll()
        {
            SubscriptionData subscriptionData = new SubscriptionData();
            AggregateResult aggregateResult = subscriptionData.CountAllSubscriptions();


            return aggregateResult;
        }
        public static SelectResult GetSubscriptionsMonthly()
        {
            SubscriptionData subscriptionData = new SubscriptionData();
            SelectResult aggregateResult = subscriptionData.CountSubscriptionByMonth();


            return aggregateResult;
        }

        public static SelectResult TEST(string email)
        {
            SubscriptionData subscriptionData = new SubscriptionData();
            SelectResult aggregateResult = subscriptionData.SelectSubscriptionByEmail(email);


            return aggregateResult;
        }
    }
}
