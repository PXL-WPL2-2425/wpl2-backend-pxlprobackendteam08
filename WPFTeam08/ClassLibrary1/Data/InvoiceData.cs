using ClassLibrary08.Data.Framework;
using ClassLibTeam08.Business.Entities;
using ClassLibTeam08.Data.Framework;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;
using System.Net;
using System.Net.Mail;
using ClassLibrary1.Data;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Linq.Expressions;
using ClassLibrary1.Business.Entities;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace ClassLibrary1.Data
{
    internal class InvoiceData : SqlServer
    {
        private readonly IConfiguration _configuration;

        public string TableName { get; set; }
        public InvoiceData()
        {
            
        }
        public InvoiceData(IConfiguration configuration)
        {
            TableName = "Tasks";
            _configuration = configuration;
        }

        public SelectResult SelectByGroupID(int groupId)
        {
            var result = new SelectResult();
            try
            {
                StringBuilder selectQuery = new StringBuilder();
                selectQuery.Append($"SELECT * FROM Invoices WHERE GroupID = {groupId}");
                using (SqlCommand selectCommand = new SqlCommand(selectQuery.ToString()))
                {
                    result = Select(selectCommand);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }

        public SelectResult SelectAll()
        {
            var result = new SelectResult();
            try
            {
                StringBuilder selectQuery = new StringBuilder();
                selectQuery.Append($"select i.invoiseID, g.groupName, i.createDate, s.statut, i.invoiceDate FROM Invoices i JOIN Subscription s ON i.subscriptionID = s.subscriptionID JOIN Groep g ON s.groupID = g.groupID");
                using (SqlCommand selectCommand = new SqlCommand(selectQuery.ToString()))
                {
                    result = Select(selectCommand);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }
        public InsertResult Insert(Invoice invoice)
        {
            var result = new InsertResult();
            try
            {
                StringBuilder insertquery = new StringBuilder();
                insertquery.Append($"Insert into invoices (subscriptionid, createdate, statut,  invoicedate, deleteddate, groupid)");
                insertquery.Append($"values (@subscriptionid, @createdate, @statut,  @invoicedate, @deletedate, @groupid)");
                using (SqlCommand insertCommand = new SqlCommand(insertquery.ToString()))
                {
                    insertCommand.Parameters.Add("@subscriptionid", SqlDbType.VarChar).Value = invoice.SubscriptionID;
                    insertCommand.Parameters.Add("@createdate", SqlDbType.DateTime).Value = invoice.CreateDate;
                    insertCommand.Parameters.Add("@statut", SqlDbType.VarChar).Value = invoice.Statut;
                    insertCommand.Parameters.Add("@invoicedate", SqlDbType.DateTime).Value = invoice.InvoiceDate;
                    insertCommand.Parameters.Add("@deletedate", SqlDbType.DateTime).Value = invoice.DeleteDate;
                    insertCommand.Parameters.Add("@groupid", SqlDbType.VarChar).Value = invoice.GroupID;
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
