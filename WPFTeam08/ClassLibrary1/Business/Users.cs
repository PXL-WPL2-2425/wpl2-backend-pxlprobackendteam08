using ClassLibrary08.Data.Framework;
using ClassLibTeam08.Data;
using ClassLibTeam08.Data.Framework;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Net.Mail;
using System.Net;

namespace ClassLibTeam08.Business.Entities
{
    public static class Users
    {
        private static IConfiguration _configuration;

        public static void SetConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static SelectResult GetUser(int id)
        {
            var data = new UserData(_configuration); // Pass the configuration
            SelectResult result = data.SelectByID(id);
            return result;
        }

        public static SelectResult CheckIfUserExists(string email)
        {
            var data = new UserData(_configuration); // Pass the configuration
            SelectResult result = data.SelectAllEmail();

            foreach (DataRow row in result.DataTable.Rows)
            {
                if ((string)row[0] == email)
                {
                    result.Succeeded = false;
                    return result;
                }
            }

            result.Succeeded = true;
            return result;
        }
        public static User GetUserById(int userId)
        {
            UserData userData = new UserData(_configuration);
            SelectResult result = userData.SelectUserById(userId);

            if (result.DataTable != null && result.DataTable.Rows.Count > 0)
            {
                var row = result.DataTable.Rows[0];
                return new User
                {
                    UserID = row.Field<int>("userID"),
                    FirstName = row.Field<string>("firstName"),
                    LastName = row.Field<string>("lastName"),
                    UserName = row.Field<string>("userName"),
                    Email = row.Field<string>("email"),
                    Password = row.Field<string>("wachtWord"),
                    Phone = row.Field<string>("phone"),
                    Address = row.Field<string>("adres"),
                    Roles = row.Field<string>("Rol"),
                    BirthDay = row.Field<DateTime>("birthday"),
                };
            }

            return null;
        }
        public static SelectResult CheckRoles(string email)
        {
            var userData = new UserData(_configuration); // Pass the configuration
            return userData.CheckRoles(email);
        }

        public static SelectResult SelectAllEmailAndPasswords()
        {
            var data = new UserData(_configuration); // Pass the configuration
            SelectResult result = data.SelectAllEmail();
            return result;
        }

        public static SelectResult SelectByEmailAndPasswords(string email, string password)
        {
            var data = new UserData(_configuration); // Pass the configuration
            SelectResult result = data.SelectByEmailAndPassword(email, password);
            return result;
        }

        public static SelectResult SendConfirmationEmail(string Email)
        {
            var userData = new UserData(_configuration); // Pass the configuration
            return userData.SendNewPasswordEmail(Email);
        }

        public static UpdateResult UpdateUserData(int id, string firstName, string lastName, string userName, string email, string adres, string wachtwoord, DateTime Birhday, string phone)
        {
            var userData = new UserData(_configuration); // Pass the configuration
            return userData.UpdateAllUserData(id, firstName, lastName, userName, email, adres, wachtwoord, Birhday, phone);
        }

        public static UpdateResult AddRoles(string rol, string email)
        {
            var userData = new UserData(_configuration); // Pass the configuration
            return userData.AddRoles(rol, email);
        }

        public static DeleteResult DeleteUser(int id)
        {
            var data = new UserData(_configuration); // Pass the configuration
            DeleteResult result = data.DeleteByID(id);
            return result;
        }

        public static UpdateResult ChangePassword(string email, string password)
        {
            var data = new UserData(_configuration); // Pass the configuration
            UpdateResult result = data.ChangePassword(email, password);
            return result;
        }

        public static SelectResult CheckLogin(string email, string password)
        {
            var data = new UserData(_configuration); // Pass the configuration
            SelectResult result = data.SelectByEmailAndPassword(email, password);
            return result;
        }
    }
}