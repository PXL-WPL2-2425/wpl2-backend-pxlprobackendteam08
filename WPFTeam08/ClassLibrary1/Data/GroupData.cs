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
    internal class GroupData : SqlServer
    {
        public string TableName { get; set; }

        private readonly IConfiguration _configuration;
        public GroupData(IConfiguration configuration)
        {
            TableName = "Groep";
            _configuration = configuration;
        }

        public SelectResult SelectByGroupID(int ID)
        {
            var result = new SelectResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"SELECT * FROM Groep WHERE groupID = @ID");
                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    insertCommand.Parameters.AddWithValue("@ID", ID);
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
