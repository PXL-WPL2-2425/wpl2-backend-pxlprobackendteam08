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

namespace ClassLibrary1.Data
{
    internal class InvoiceData : SqlServer
    {
        private readonly IConfiguration _configuration;

        public string TableName { get; set; }

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
    }
}
