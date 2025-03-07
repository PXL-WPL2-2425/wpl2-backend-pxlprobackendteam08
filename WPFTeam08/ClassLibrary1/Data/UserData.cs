using ClassLibTeam08.Business.Entities;
using ClassLibTeam08.Data.Framework;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;

namespace ClassLibTeam08.Data
{

    internal class UserData : SqlServer
    {
        public UserData()
        {
            TableName = "Users";
        }
        public string TableName { get; set; }
        public SelectResult Select()
        {
            return base.Select(TableName);
        }

        public InsertResult Insert(User user)
        {
            var result = new InsertResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"Insert INTO {TableName}");
                insertQuery.Append($"(firstname, lastname, username, email, adres, wachtWord, birthday, phone) VALUES");
                insertQuery.Append($"(@firstname, @lastname, @username, @email, @adres, @wachtWord, @birthday, @phone);");
                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    insertCommand.Parameters.Add("@firstname", SqlDbType.VarChar).Value =
                    user.FirstName;
                    insertCommand.Parameters.Add("@lastname", SqlDbType.VarChar).Value =
                    user.LastName;
                    insertCommand.Parameters.Add("@username", SqlDbType.VarChar).Value =
                    user.UserName;
                    insertCommand.Parameters.Add("@email", SqlDbType.VarChar).Value =
                    user.Email;
                    insertCommand.Parameters.Add("@adres", SqlDbType.VarChar).Value =
                    user.Address;
                    insertCommand.Parameters.Add("@wachtWord", SqlDbType.VarChar).Value =
                    user.Password;
                    insertCommand.Parameters.Add("@birthday", SqlDbType.Date).Value =
                    user.BirthDay;
                    insertCommand.Parameters.Add("@phone", SqlDbType.VarChar).Value =
                    user.Phone;
                    result = InsertRecord(insertCommand);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }

        public void ChangePassword(int ID, string newPassword)
        {
            var result = new InsertResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append(@"UPDATE Users ");
                insertQuery.Append(@"SET wachtWord = 'defefv' ");
                insertQuery.Append(@"WHERE UserID = 1");
                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    InsertRecord(insertCommand);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}

