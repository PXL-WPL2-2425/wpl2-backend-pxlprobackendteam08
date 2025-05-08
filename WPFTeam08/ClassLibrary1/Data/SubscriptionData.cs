using ClassLibrary08.Data.Framework;
using ClassLibrary1.Business;
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
                selectQuery.Append($"SELECT u.userId, u.firstname, u.lastname, u.email, u.phone, s.statut, s.startdate, s.eindtime, s.rewendeDate, CASE  WHEN s.autoRenewal = 'true' THEN 'Ja' ELSE 'Nee' END AS autoRenewal FROM users u left JOIN groupmembers gm ON gm.userid = u.userid left JOIN groep g ON g.groupid = gm.groupid left JOIN subscription s ON s.groupid = g.groupid;");
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
                deleteQuery.Append($"DELETE from subscription WHERE groupID = {id};");
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
        public InsertResult AddSubscription(string email)
        {
            InsertResult result = new InsertResult();
            try
            {
                StringBuilder addQuery = new StringBuilder();
                addQuery.Append($"INSERT INTO subscription (groupid, startdate)\r\nSELECT g.groupid, CURRENT_DATE\r\nFROM users u\r\nJOIN groupmembers gm ON gm.userid = u.userid\r\nJOIN groep g ON g.groupid = gm.groupid WHERE email = {email};");
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
        public UpdateResult UpdateSubscription(DateTime startDate, DateTime endDate, DateTime renewDate, string status, string autoRenewal, string email)
        {
            UpdateResult result = new UpdateResult();
            try
            {
                StringBuilder updateQuery = new StringBuilder();
                updateQuery.Append($"UPDATE s\r\nSET \r\n  s.startDate = @startdate,\r\n  s.eindTime = @eindtime,\r\n  s.rewendeDate = @rewendedate,\r\n  s.statut = @statut,\r\n  s.autoRenewal = @autorenewal\r\nFROM subscription s\r\nJOIN groep g ON s.groupid = g.groupid\r\nJOIN groupmembers gm ON gm.groupid = g.groupid\r\nJOIN users u ON u.userid = gm.userid\r\nWHERE u.email = @email;");
                using (SqlCommand updateCmd = new SqlCommand(updateQuery.ToString()))
                {
                    updateCmd.Parameters.Add("@startdate", SqlDbType.DateTime).Value = startDate;
                    updateCmd.Parameters.Add("@eindtime", SqlDbType.DateTime).Value = endDate;
                    updateCmd.Parameters.Add("@rewendedate", SqlDbType.DateTime).Value = renewDate;
                    updateCmd.Parameters.Add("@statut", SqlDbType.VarChar).Value = status;
                    updateCmd.Parameters.Add("@autorenewal", SqlDbType.VarChar).Value = autoRenewal;
                    updateCmd.Parameters.AddWithValue("@email", email);


                    result = Update(updateCmd);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }
        public UpdateResult CancelSubscription(string email)
        {
            UpdateResult result = new UpdateResult();
            try
            {
                StringBuilder updateQuery = new StringBuilder();
                updateQuery.Append($"update s SET statut = 'Free', autorenewal = 'False', eindtime = EOMONTH(GETDATE()) \r\nFROM subscription s\r\nJOIN groep g ON s.groupid = g.groupid\r\nJOIN groupmembers gm ON gm.groupid = g.groupid\r\nJOIN users u ON u.userid = gm.userid\r\nWHERE u.email = @email;");
                using (SqlCommand updateCmd = new SqlCommand(updateQuery.ToString()))
                {
                    updateCmd.Parameters.AddWithValue("@email", email);


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
        public AggregateResult CountAllSubscriptions()
        {
            var result = new AggregateResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"SELECT COUNT(subscriptionId)\r\nFROM subscription\r\nWHERE statut = 'basic' OR statut = 'premium';");

                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    result = Count(insertCommand);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }

        public SelectResult CountSubscriptionByMonth()
        {
            var result = new SelectResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"SELECT \r\n    FORMAT(rewendeDate, 'yyyy-MM') AS maand,\r\n    COUNT(subscriptionID) AS aantal_subscripties\r\nFROM \r\n    subscription\r\nWHERE \r\n    statut = 'basic' OR statut = 'premium'\r\nGROUP BY \r\n    FORMAT(rewendeDate, 'yyyy-MM')\r\nORDER BY \r\n    maand;");

                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    result = Select(insertCommand);
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
