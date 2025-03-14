﻿using ClassLibrary08.Data.Framework;
using ClassLibTeam08.Business.Entities;
using ClassLibTeam08.Data.Framework;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;
using System.Net;
using System.Net.Mail;
using ClassLibrary1.Data;
using Microsoft.Extensions.Configuration;

namespace ClassLibTeam08.Data
{
    internal class UserData : SqlServer
    {
        public UserData()
        {
            TableName = "Users";
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

        public UpdateResult ChangePassword(int ID, string newPassword)
        {
            var result = new UpdateResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"UPDATE Users ");
                insertQuery.Append($"SET wachtWord = '{newPassword}' ");
                insertQuery.Append($"WHERE UserID = {ID}");
                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    result = Update(insertCommand);
                }

                SendNewPasswordEmail(ID, newPassword);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

            return result;
        }

        public SelectResult SelectByID()
        {
            var result = new SelectResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"Insert INTO {TableName}");
                insertQuery.Append($"(firstname, lastname, username, email, adres, wachtWord, birthday, phone) VALUES");
                insertQuery.Append($"(@firstname, @lastname, @username, @email, @adres, @wachtWord, @birthday, @phone);");
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
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }

        private void SendNewPasswordEmail(int ID, string newPassword)
        {
            //string connectionString = Settings.GetConnectionString();
           
            var userResult = SelectByID(ID);
            if (!userResult.Succeeded || userResult.DataTable.Rows.Count == 0)
            {
                throw new Exception("User not found.");
            }

            var userEmail = userResult.DataTable.Rows[0]["email"].ToString();

            // Genereer de bevestigingslink
            string confirmationLink = GeneratePasswordResetToken(userEmail);

            // Stel de e-mail op
            var fromAddress = new MailAddress("your-email@example.com", "Your Name");
            var toAddress = new MailAddress(userEmail);
            const string fromPassword = "your-email-password";
            const string subject = "Bevestig uw wachtwoordwijziging";
            string body = $"Beste gebruiker, \n\nBevestig je wachtwoordwijziging door op de volgende link te klikken: {confirmationLink}";

            var smtp = new SmtpClient
            {
                Host = "smtp.example.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }

        private string GeneratePasswordResetToken(string email)
        {
            var token = Guid.NewGuid().ToString();
            var encodedToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(token));
            string confirmationLink = $"https://monohome.be/confirm-password-change?token={encodedToken}&email={email}";

            return confirmationLink;

        }
    }
}

