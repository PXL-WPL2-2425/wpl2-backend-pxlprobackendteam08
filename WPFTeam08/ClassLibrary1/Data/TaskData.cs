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
    internal class TaskData : SqlServer
    {
        private readonly IConfiguration _configuration;

        public string TableName { get; set; }

        public TaskData(IConfiguration configuration)
        {
            TableName = "Tasks";
            _configuration = configuration;
        }

        public SelectResult SelectByGroupID(int groupId, string serviceName, string description)
        {
            var result = new SelectResult();
            try
            {
                StringBuilder selectQuery = new StringBuilder();
                selectQuery.Append($"SELECT * FROM Tasks WHERE GroupID = {groupId}");
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

        public SelectResult SelectByGroupID(int groupId)
        {
            var result = new SelectResult();
            try
            {
                StringBuilder selectQuery = new StringBuilder();
                selectQuery.Append($"SELECT * FROM Tasks WHERE GroupID = {groupId}");
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
