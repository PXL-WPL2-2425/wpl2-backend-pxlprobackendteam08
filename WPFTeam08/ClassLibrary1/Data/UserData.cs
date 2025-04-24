using ClassLibrary08.Data.Framework;
using ClassLibrary1.Data;
using ClassLibTeam08.Business.Entities;
using ClassLibTeam08.Data.Framework;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Org.BouncyCastle.Utilities.Net;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Text;

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
                insertQuery.Append($"select * from Users WHERE userID = {ID}");
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

        public SelectResult SelectByPassword(string email)
        {
            var result = new SelectResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"select * from Users where email = @email");

                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    insertCommand.Parameters.Add("@email", SqlDbType.VarChar);
                    insertCommand.Parameters["@email"].Value = email;
                    result = Select(insertCommand);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return result;
        }

        public SelectResult SelectByEmailAndPassword(string email, string password)
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
                    insertCommand.Parameters["@email"].Value = email;
                    insertCommand.Parameters.Add("@password", SqlDbType.VarChar);
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
                insertQuery.Append($"(firstname, lastname, username, email, adres, wachtWord, birthday, phone, rol) VALUES");
                insertQuery.Append($"(@firstname, @lastname, @username, @email, @adres, @wachtWord, @birthday, @phone, @rol);");
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
                    insertCommand.Parameters.Add("@rol", SqlDbType.VarChar).Value = user.Rol;
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
                result.AddError(ex.Message);
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

        public UpdateResult UpdateToken(int id, string token)
        {
            var result = new UpdateResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"update Users set token = '{token}' where userID = {id}");
                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    result = Update(insertCommand);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }

        public SelectResult GetToken(string email)
        {
            var result = new SelectResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"select token from users where email = '{email}'");
                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    result = Select(insertCommand);
                    result.Succeeded = true;
                }
            }
            catch (Exception ex)
            {
                result.Succeeded = false;
                throw new Exception(ex.Message, ex);
            }
            return result;
        }
        public SelectResult SelectUserById(int userId)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = $"SELECT * FROM {TableName} WHERE UserId = {userId}";
            return base.Select(command);
        }
        public UpdateResult ChangeRole(string rol, string email)
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
        public UpdateResult UpdateAllUserData(int id, string firstName, string lastName, string userName, string email, string adres, string wachtwoord, DateTime Birhday, string phone)
        {
            var result = new UpdateResult();

            string test = Birhday.ToString("yyyy/MM/dd");

            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"UPDATE {TableName} ");
                insertQuery.Append($"SET firstname = '{firstName}', lastname = '{lastName}', username = '{userName}', email = '{email}', adres = '{adres}', wachtWord = '{wachtwoord}', birthday = '{Birhday.ToString("yyyy/MM/dd")}', phone = '{phone}' ");
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
        public EmailResult SendNewPasswordEmail(string email)
        {
            // Get user data
            SelectResult userResult = SelectByEmail(email);
            EmailResult emailResult = new EmailResult();


            if (!userResult.Succeeded || userResult.DataTable.Rows.Count == 0)
            {
                emailResult.Succeeded = false;
                return emailResult;
            }

            // Get user email
            var userEmail = userResult.DataTable.Rows[0]["email"]?.ToString();
            if (string.IsNullOrEmpty(userEmail))
            {
                emailResult.AddError("Gebruiker heeft geen Email");
                emailResult.Succeeded = false;
                return emailResult;
            }

            //SelectResult has succeeded, copy EMail from selectresult to Emailresult
            emailResult.Email = userEmail;

            // Prepare SMTP settings
            string smtpServer = "smtp.gmail.com"; // SMTP-server
            int port = 587;
            string fromEmail = "monohomepass@gmail.com";
            string fromPassword = "dndz vqer tfcm ierc"; // monohome app-wachtwoord
            string toEmail = userEmail.ToString();

            // Generate confirmation link
            string confirmationLink = GeneratePasswordResetToken(email: userEmail);

            // SMTP Setup + send email
            try
            {
                using (System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(smtpServer, port))
                {
                    // Login for authentication
                    smtp.Credentials = new NetworkCredential(fromEmail, fromPassword);
                    // Encrypt connection to Gmail
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
                    emailResult.Succeeded = true;
                    return emailResult;
                }
            }
            catch (SmtpException smtpEx)
            {
                Debug.WriteLine($"SMTP Fout bij verzenden van e-mail: {smtpEx.Message}");
                return emailResult;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Fout bij verzenden van e-mail: {ex.Message}");
                return emailResult;
            }
        }
        private string GeneratePasswordResetToken(string email)
        {
            var token = Guid.NewGuid().ToString();//unike token maken
            var encodedToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(token));
            string confirmationLink = $"http://localhost:5173/NewWachtWoordView/?token={encodedToken}&email={email}";

            return confirmationLink;
        }

        public EmailResult SendConfirmEmail(string toEmail, string subject, string body)
        {
            EmailResult emailResult = new EmailResult();
            MimeMailWrapper mimeMailWrapper = new MimeMailWrapper();

            BodyBuilder bodyBuilder = new BodyBuilder();

            bodyBuilder.TextBody = "Test body";

            bodyBuilder.HtmlBody += @"<p>Hallo gebruiker,<br>
<h1>Order bevestigd!<br>
<h3>bye<br>
<p>-- MonoHome<br>";

         
            try
            {
                mimeMailWrapper.SendEmail(toEmail, subject, bodyBuilder);
            }

            catch (SmtpException smtpEx)
            {
                Debug.WriteLine($"SMTP Fout bij verzenden van e-mail: {smtpEx.Message}");
                emailResult.AddError(smtpEx.Message);
                emailResult.Succeeded = false;
            }

            catch (Exception ex)
            {
                Debug.WriteLine($"Fout bij verzenden van e-mail: {ex.Message}");
                emailResult.AddError(ex.Message);
                emailResult.Succeeded = false;
            }


            emailResult.Succeeded = true;
            return emailResult;
        }

        public SelectResult SelectAdmins()
        {
            var result = new SelectResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"SELECT u.firstName, u.lastName, u.adres, u.phone, u.email, u.rol,  CASE \r\n WHEN MAX(l.loginTime) IS NULL THEN 'niet ingelogd' \r\n  ELSE CONVERT(varchar, MAX(l.loginTime), 120) \r\n  END AS lastLoginTime FROM users u left JOIN logins l ON u.userID = l.userID GROUP BY  u.userID, u.firstName, u.lastName, u.adres,u.phone, u.email, u.rol ORDER BY lastLoginTime DESC;");
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

        public SelectResult selectCurrentUser(string email)
        {
            var result = new SelectResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"SELECT token from users where email = @email");

                

                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    insertCommand.Parameters.AddWithValue("@email", email);
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

