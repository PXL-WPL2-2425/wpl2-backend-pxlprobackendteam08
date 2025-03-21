using ClassLibrary1.Business;
using ClassLibrary1.Business.Entities;
using ClassLibTeam08.Business.Entities;
using ClassLibTeam08.Data.Framework;
using ClassLibrary08.Data.Framework;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam08.Data
{

    internal class LoginData : SqlServer
    {
        private readonly IConfiguration _configuration;
        public string TableName { get; set; }

        public LoginData(IConfiguration configuration)
        {
            _configuration = configuration;
            TableName = "Logins";
        }


        public SelectResult selectAllLogins()
        {
            var result = new SelectResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"Select * from {TableName}");

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

        public AggregateResult CountAllLogins()
        {
            var result = new AggregateResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"select count(loginID) from logins");

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
        public InsertResult Insert(Login login, int userID)
        {
            var result = new InsertResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"Insert INTO {TableName} ");
                insertQuery.Append($"values(@UserID, @loginDate, @IPadress)");
                
                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    insertCommand.Parameters.Add("@UserID", SqlDbType.Int).Value =
                    userID;
                    insertCommand.Parameters.Add("@loginDate", SqlDbType.DateTime).Value =
                    login.loginTime;
                    insertCommand.Parameters.Add("@IPadress", SqlDbType.VarChar).Value =
                    login.ipAdresss;

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
