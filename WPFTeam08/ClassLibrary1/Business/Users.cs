﻿using ClassLibrary08.Data.Framework;
using ClassLibTeam08.Data;
using ClassLibTeam08.Data.Framework;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Net.Mail;
using System.Net;

using Isopoh.Cryptography.Argon2;
using ClassLibrary1.Data;

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
        static User GetUserById(int userId)
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
                    Rol = row.Field<string>("rol"),
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

        public static EmailResult SendConfirmationEmail(string Email)
        {
            var userData = new UserData(_configuration); // Pass the configuration

            EmailResult emailResult = userData.SendNewPasswordEmail(Email);

            return emailResult;
        }

        public static EmailResult SendOrderConfirmation(string toEmail, string subject, string body)
        {
            var userData = new UserData(_configuration); // Pass the configuration

            EmailResult emailResult = userData.SendConfirmEmail(toEmail, subject, body);

            return emailResult;
        }

        public static UpdateResult UpdateUserData(int id, string firstName, string lastName, string userName, string email, string adres, string wachtwoord, DateTime Birhday, string phone)
        {
            var userData = new UserData(_configuration); // Pass the configuration
            return userData.UpdateAllUserData(id, firstName, lastName, userName, email, adres, wachtwoord, Birhday, phone);
        }

        public static UpdateResult ChangeRole(string rol, string email)
        {
            var userData = new UserData(_configuration); // Pass the configuration
            UpdateResult updateResult = userData.ChangeRole(rol, email);

            SelectResult selectResult = GetToken(email);

            if(selectResult.DataTable != null)
            updateResult.Token = (string)selectResult.DataTable.Rows[0][0];

            return updateResult;
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
            UpdateResult result = new UpdateResult();

            result = (UpdateResult)PasswordChecker.CheckPassword(password, result);

            if (result.Succeeded == false)
                return result;


            string encryptedPassword = Argon2.Hash(password);

            result = data.ChangePassword(email, encryptedPassword);

            return result;
        }

        public static SelectResult CheckLogin(string email, string password)
        {
            var data = new UserData(_configuration); // Pass the configuration
            SelectResult result = data.SelectByEmail(email); 

            if(result.DataTable.Rows.Count != 0)
            {
                if (Argon2.Verify((string)result.DataTable.Rows[0][6], password))
                {
                    result.Succeeded = true;
                }

                else
                {
                    result.AddError("wrong password");
                    result.Succeeded = false;
                }
            }
             
            //AddToken((int)result.DataTable.Rows[0][0], result.GenerateToken());

            return result;
        }

        public static UpdateResult AddToken(int id, string token)
        {
            var data = new UserData(_configuration); // Pass the configuration
            UpdateResult result = data.UpdateToken(id, token);
            return result;
        }

        public static SelectResult GetToken(string email)
        {
            var data = new UserData(_configuration); // Pass the configuration
            SelectResult result = data.GetToken(email);
            return result;
        }
        public static SelectResult Admins()
        {
            var data = new UserData(_configuration); 
            return data.SelectAdmins();
        }
    }
}