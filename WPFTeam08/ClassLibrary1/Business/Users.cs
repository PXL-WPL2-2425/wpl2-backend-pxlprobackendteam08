﻿using ClassLibrary08.Data.Framework;
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
        private static IConfiguration _configuration; // Add this field

        // Add this method to set the configuration
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

        public static DeleteResult DeleteUser(int id)
        {
            var data = new UserData(_configuration); // Pass the configuration
            DeleteResult result = data.DeleteByID(id);
            return result;
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
            SelectResult result = data.SelectByEmailAndPasswords(email, password);
            return result;
        }

        public static UpdateResult ChangePassWord(int userID, string newPassword)
        {
            var userData = new UserData(_configuration); // Pass the configuration
            return userData.ChangePassword(userID, newPassword);
        }

        public static UpdateResult UpdateUserData(int id, string firstName, string lastName, string userName, string email, string adres, string wachtwoord, string Birhday, string phone)
        {
            var userData = new UserData(_configuration); // Pass the configuration
            return userData.UpdateAllUserData(id, firstName, lastName, userName, email, adres, wachtwoord, Birhday, phone);
        }

        public static UpdateResult AddRoles(string rol, string email)
        {
            var userData = new UserData(_configuration); // Pass the configuration
            return userData.AddRoles(rol, email);
        }
        public static SelectResult CheckRoles( string email)
        {
            var userData = new UserData(_configuration); // Pass the configuration
            return userData.CheckRoles(email);
        }

    }
}