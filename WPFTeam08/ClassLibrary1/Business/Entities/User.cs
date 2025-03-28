﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam08.Business.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName {get; set; }
        public string UserName {get; set; }
        public string Email { get; set; }
        //{
        //    get { return Email; }
        //    set 
        //    { 
        //        if (value.Contains("@"))
        //        {
        //            Email = value;
        //        }
        //    }
        //}
        public string Address {get; set; }
        public string Password {get; set; }
        public DateTime BirthDay {get; set; }
        public string Phone {get; set; }
        public string Roles { get; set; }
        //{
        //    get { return Roles; }
        //    set
        //    {
        //        if (value == "admin" || value == "guest" || value == "client")
        //        {
        //            Roles = value;
        //        }
        //    }
        //}

        // Constructor
        public User(int userId, string firstName, string lastName, string userName, string email, string address, string password, DateTime birthday, string phone, string roles)
        {
            UserID = userId;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
            Address = address;
            Password = password;
            BirthDay = birthday;
            Phone = phone;
            Roles = roles;
        }

        // Constructor met default role
        public User(int userId, string firstName, string lastName, string userName, string email, string address, string password, DateTime birthday, string phone) : this(userId, firstName, lastName, userName, email, address, password, birthday, phone, "guest")
        {

        }
        public User()
        {

        }
    }
}
