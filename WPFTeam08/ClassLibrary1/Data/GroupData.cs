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

        public InsertResult InsertGroup(Group group)
        {
            var result = new InsertResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"Insert INTO groep");
                insertQuery.Append($"(groupname, groupid ) VALUES");
                insertQuery.Append($"(@groupname, @groupid);");
                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    insertCommand.Parameters.Add("@groupname", SqlDbType.VarChar).Value =
                    group.GroupName;
                    insertCommand.Parameters.Add("@groupid", SqlDbType.Int).Value =
                    group.GroupId;


                    result = Insert(insertCommand);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }

        public DeleteResult DeleteGroup(int id)
        {
            var result = new DeleteResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"DELETE FROM groep WHERE groupid = {id};");
                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    result = Delete(insertCommand);
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
