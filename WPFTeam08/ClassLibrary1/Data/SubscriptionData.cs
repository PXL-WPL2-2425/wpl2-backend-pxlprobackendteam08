using ClassLibrary08.Data.Framework;
using ClassLibrary1.Business.Entities;
using ClassLibTeam08.Business.Entities;
using ClassLibTeam08.Data.Framework;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Data
{
    internal class SubscriptionData : SqlServer
    {
        public SelectResult SelectByID()
        {
            SelectResult result = new SelectResult();
            try
            {
                StringBuilder selectQuery = new StringBuilder();
                selectQuery.Append($"select * from Subscription");
                using (SqlCommand selectCmd = new SqlCommand(selectQuery.ToString()))
                {
                    result = Select(selectCmd);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }

        public DeleteResult DeleteByID(int id)
        {
            DeleteResult result = new DeleteResult();
            try
            {
                StringBuilder deleteQuery = new StringBuilder();
                deleteQuery.Append($"DELETE FROM Subscription WHERE SubscriptionID = {id};");
                using (SqlCommand deleteCmd = new SqlCommand(deleteQuery.ToString()))
                {
                    result = Delete(deleteCmd);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }
        public InsertResult AddSubscription(int id)
        {
            InsertResult result = new InsertResult();
            try
            {
                StringBuilder addQuery = new StringBuilder();
                addQuery.Append($"Insert into FROM Subscriptions WHERE SubscriptionID = {id};");
                using (SqlCommand addCmd = new SqlCommand(addQuery.ToString()))
                {
                    result = Insert(addCmd);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }
        public UpdateResult UpdateSubscription(int id)
        {
            UpdateResult result = new UpdateResult();
            try
            {
                StringBuilder updateQuery = new StringBuilder();
                updateQuery.Append($"update FROM Subscriptions WHERE SubscriptionID = {id};");
                using (SqlCommand updateCmd = new SqlCommand(updateQuery.ToString()))
                {
                    result = Update(updateCmd);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }

        public InsertResult InsertSubscription(Subscription subscription)
        {
            var result = new InsertResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"Insert INTO subscription");
                insertQuery.Append($"(groupid, startdate, eindtime, rewendedate, statut, autorenewal) VALUES");
                insertQuery.Append($"(@groupid, @startdate, @eindtime, @rewendedate, @statut, @autorenewal);");
                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    insertCommand.Parameters.Add("@groupid", SqlDbType.VarChar).Value =
                    subscription.GroupID;
                    insertCommand.Parameters.Add("@startdate", SqlDbType.DateTime).Value =
                    subscription.StartDate;
                    insertCommand.Parameters.Add("@eindtime", SqlDbType.DateTime).Value =
                    subscription.EndDate;
                    insertCommand.Parameters.Add("@rewendedate", SqlDbType.DateTime).Value =
                    subscription.Renewdate;
                    insertCommand.Parameters.Add("@statut", SqlDbType.VarChar).Value =
                    subscription.Status;
                    insertCommand.Parameters.Add("@autorenewal", SqlDbType.VarChar).Value =
                    subscription.AutoRenewal;

                    result = Insert(insertCommand);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }
    }
}
