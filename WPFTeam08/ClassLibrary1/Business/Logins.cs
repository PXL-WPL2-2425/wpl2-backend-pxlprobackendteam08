using ClassLibrary08.Data.Framework;
using ClassLibTeam08.Business.Entities;
using ClassLibTeam08.Data.Framework;
using ClassLibTeam08.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using ClassLibrary1.Data;
using ClassLibrary1.Business.Entities;

namespace ClassLibrary1.Business
{
    public static class Logins
    {
        private static IConfiguration _configuration;

        public static void Initialize(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static SelectResult LoginData(int id)
        {
            LoginData data = new LoginData(_configuration);
            SelectResult result = data.SelectByUserID(id);
            return result;
        }

        public static InsertResult AddLogin(int UserID, DateTime loginTime, string IPadress)
        {
            LoginData data = new LoginData(_configuration); 
            Login login = new Login();
            login.loginTime = loginTime;
            login.ipAdresss = IPadress;

            InsertResult result = data.Insert(login, UserID);
            result.Succeeded = true;
            return result; 
        }

        public static SelectResult CheckLogin(string Email, string password)
        {
            SelectResult selectResult = Users.SelectByEmailAndPasswords(Email, password);

            if (selectResult.DataTable == null)
            {
                return new SelectResult() { Succeeded = true, message = "" };
            }

            return selectResult;

        }

        public static SelectResult SelectAll()
        {
            LoginData loginData = new LoginData(_configuration);
            SelectResult selectResult = loginData.selectAllLogins();

            if (selectResult.DataTable == null)
            {
                return new SelectResult() { Succeeded = true, message = "" };
            }

            return selectResult;
        }

        public static AggregateResult CountAll()
        {
            LoginData loginData = new LoginData(_configuration);
            AggregateResult aggregateResult = loginData.CountAllLogins();
            

            return aggregateResult;
        }

        public static SelectResult GeLoginsByDate()
        {
            LoginData loginData = new LoginData(_configuration);
            SelectResult aggregateResult = loginData.CountLoginsByDate();


            return aggregateResult;
        }

        public static InsertResult Add(string firstName, string lastName, string userName, string email, string address, string password, DateTime birthday, string phone)
        {
            InsertResult insertResult = new InsertResult();

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(password) || birthday == DateTime.MinValue)
            {

                return new InsertResult() { Success = false, Message = "All fields are required" };
            }

            else if (password.Length <= 8)
            {
                return new InsertResult() { Success = false, Message = "Password must be at least 8 characters" };
            }

            insertResult = PasswordChecker.CheckPasswordInsertResult(password, insertResult);

            if(insertResult.Succeeded == false)
            {
                insertResult.Success = false;
                return insertResult;
            }


            //if(user.Email == true)
            //{
            //    return new InsertResult() { Success = false, Message = "Dit emailadres bestaat al" };
            //}
            else
            {
                //pasword ghets ncrypted in the User constructor
                User user = new User(firstName, lastName, userName, email, address, password, birthday, phone, "client");


                UserData userData = new UserData(_configuration);
                InsertResult result = userData.Insert(user);

                result.Success = true;

                return result;
            }
        }
   }
}

    

