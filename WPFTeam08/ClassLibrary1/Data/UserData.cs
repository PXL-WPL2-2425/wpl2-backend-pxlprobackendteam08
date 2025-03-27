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

namespace ClassLibTeam08.Data
{
    internal class UserData : SqlServer
    {
        private readonly IConfiguration _configuration;
        public UserData(IConfiguration configuration)
        {
            TableName = "Users";
            _configuration = configuration;
        }

        public string TableName { get; set; }

        public SelectResult SelectByID(int ID)
        {
            var result = new SelectResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"select * from Users WHERE UserID = {ID}");
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

        public SelectResult SelectByEmail(string Email)
        {
            var result = new SelectResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"select * from Users WHERE email = '{Email}' ");
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

        public SelectResult SelectAllEmail()
        {
            var result = new SelectResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"select email from Users");
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

        public SelectResult SelectAllEmailAndPasswords()
        {
            var result = new SelectResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"select email, wachtword from Users");
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

        public SelectResult SelectByEmailAndPasswords(string email, string password)
        {
            var result = new SelectResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"select * from Users where email = @email and wachtword = @password");

                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    insertCommand.Parameters.Add("@email", SqlDbType.VarChar);
                    insertCommand.Parameters.Add("@password", SqlDbType.VarChar);
                    insertCommand.Parameters["@email"].Value = email;
                    insertCommand.Parameters["@password"].Value = password;
                    result = Select(insertCommand);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return result;
        }

        public SelectResult SelectByRole(string role)
        {
            var result = new SelectResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"SELECT * FROM Users WHERE rol = @role");

                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    insertCommand.Parameters.AddWithValue("@role", role);
                    result = Select(insertCommand);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return result;
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
                    result = Insert(insertCommand);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }

        public UpdateResult ChangePassword(string Email, string newPassword)
        {
            SendNewPasswordEmail(Email);

            var result = new UpdateResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"UPDATE Users ");
                insertQuery.Append($"SET wachtWord = @newPassword ");
                insertQuery.Append($"WHERE email = @Email ");
                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    insertCommand.Parameters.Add("@newPassword", SqlDbType.VarChar).Value = newPassword;
                    insertCommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = Email;
                    string debug = insertCommand.CommandText;
                    result = Update(insertCommand);
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
            var result = new DeleteResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"DELETE FROM Users WHERE userID = {id};");
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

        public UpdateResult AddRoles(string rol, string email)
        {
            var result = new UpdateResult();
            try
            {
                StringBuilder insertquery = new StringBuilder();
                insertquery.Append($"UPDATE users SET rol = '{rol}' WHERE email = '{email}';");
                SqlCommand insertCommand = new SqlCommand(insertquery.ToString());
                result = Update(insertCommand);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }

        public SelectResult CheckRoles(string email)
        {
            var result = new SelectResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"select rol from Users where email = @email ");

                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    insertCommand.Parameters.AddWithValue("@email", "email");
                    result = Select(insertCommand);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;

        }

        public UpdateResult UpdateAllUserData(int id, string firstName, string lastName, string userName, string email, string adres, string wachtwoord, string Birhday, string phone)
        {
            var result = new UpdateResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"UPDATE {TableName} ");
                insertQuery.Append($"SET firstname = '{firstName}', lastname = '{lastName}', username = '{userName}', email = '{email}', adres = '{adres}', wachtWord = '{wachtwoord}', birthday = '{Birhday}', phone = '{phone}' ");
                insertQuery.Append($"where userID = '{id}'");
                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    result = Update(insertCommand);

                }
                //SendNewPasswordEmail(id, wachtwoord);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="newPassword"></param>
        /// <exception cref="Exception"></exception>
        public SelectResult SendNewPasswordEmail(string email)
        {
            var userResult = SelectByEmail(email);
            if (!userResult.Succeeded || userResult.DataTable.Rows.Count == 0)
            {
                throw new Exception("User not found.");
            }

            var userEmail = userResult.DataTable.Rows[0]["email"]?.ToString();
            if (string.IsNullOrEmpty(userEmail))
            {
                throw new Exception("User email does not exist.");
            }

            //incapsuleren!!!
            string smtpServer = "smtp.gmail.com"; // SMTP-server 
            int port = 587;
            string fromEmail = "monohomepass@gmail.com";
            string fromPassword = "dndz vqer tfcm ierc"; // monohome app-wachtwoord!
            string toEmail = userEmail.ToString();

            // Genereer de bevestigingslink
            string confirmationLink = GeneratePasswordResetToken(email: userEmail);

            try
            {
                using (SmtpClient smtp = new SmtpClient(smtpServer, port))
                {
                    smtp.Credentials = new NetworkCredential(fromEmail, fromPassword);
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;

                    MailMessage mail = new MailMessage(fromEmail, toEmail)
                    {
                        Subject = "Bevestig uw wachtwoordwijziging",
                        Body = $"Beste gebruiker, \n\nBevestig je wachtwoordwijziging door op de volgende link te klikken: {confirmationLink}",
                        IsBodyHtml = false
                    };

                    smtp.Send(mail);
                    return new SelectResult(true);
                    //throw new Exception("E-mail verzonden!");                  
                }
            }
            catch (SmtpException smtpEx)
            {
                Debug.WriteLine($"SMTP Fout bij verzenden van e-mail: {smtpEx.Message}");
                return new SelectResult(false);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Fout bij verzenden van e-mail: {ex.Message}");
                return new SelectResult(false);
            }
        }

        private string GeneratePasswordResetToken(string email)
        {
            var token = Guid.NewGuid().ToString();//unike token maken
            var encodedToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(token));
            string confirmationLink = $"http://localhost:5173/login/?token={encodedToken}&email={email}";

            return confirmationLink;
        }
    }
}

