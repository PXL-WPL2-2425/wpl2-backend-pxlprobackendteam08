using ClassLibrary08.Data.Framework;
using ClassLibTeam08.Business.Entities;
using ClassLibTeam08.Data.Framework;
using ClassLibrary1.Business;
using ClassLibrary1.Business.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Data
{

    internal class LoginData : SqlServer
    {
        private readonly IConfiguration _configuration;
        public string TableName { get; set; }

        public LoginData(IConfiguration configuration)
        {
            _configuration = configuration;
            TableName = "Login";
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
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }

        public SelectResult SelectByUserID(int ID)
        {
            var result = new SelectResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"SELECT * FROM Logins WHERE userID = {ID}");
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

        public SelectResult SelectByLoginID(int ID)
        {
            var result = new SelectResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"SELECT * FROM Logins WHERE loginID = {ID}");
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
