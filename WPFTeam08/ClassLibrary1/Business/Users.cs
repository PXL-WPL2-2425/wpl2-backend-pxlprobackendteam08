using ClassLibTeam08.Data.Framework;
using ClassLibTeam08.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam08.Business.Entities
{
    public static class Users
    {
        public static SelectResult GetStudents()
        {
            UserData studentData = new UserData();
            SelectResult result = studentData.Select();
            return result;
        }

        public static InsertResult Add(string firstName, string lastName, string username, string email, string address, string password, string birthday, string phone)
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