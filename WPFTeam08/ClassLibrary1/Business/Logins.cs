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

namespace ClassLibrary1.Business
{
    public static class Logins
    {
        
        public static SelectResult GetUser(int id)
        {
            UserData data = new UserData();
            SelectResult result = data.SelectByID(id);
            return result;
        }

        public static bool CheckIfEmailExists(string Email)
        {
            SelectResult selectResult = Users.SelectAllEmail();
            DataTable dataTable = selectResult.DataTable;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {

                if (dataTable.Rows[i][0].ToString() == Email)
                {
                    return false;
                }
            }
            

            return true;
        }


        public static InsertResult Add(string firstName, string lastName, string username, string email, string address, string password, string birthday, string phone)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(birthday))
            {
                return new InsertResult() {  Success = false, Message = "All fields are required" };
            }

            else if (password.Length <= 8)
                {
                    return new InsertResult() { Success = false, Message = "Password must be at least 8 characters" };
                }

                if(CheckIfEmailExists(email) == false)
                {
                    return new InsertResult() { Success = false, Message = "Dit emailadres bestaat al" };
                }

                else
                {
                    User user = new User();
                    user.FirstName = firstName;
                    user.LastName = lastName;
                    user.UserName = username;
                    user.Email = email;
                    user.Address = address;
                    user.Password = password;
                    user.BirthDay = birthday;
                    user.Phone = phone;
                    UserData userData = new UserData();
                    InsertResult result = userData.Insert(user);

                    return result;
                }
            }
        }

 



    }

