﻿using ClassLibTeam08.Data.Framework;
using ClassLibTeam08.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam08.Business.Entities
{
    public static class Students
    {
        public static SelectResult GetStudents()
        {
            StudentData studentData = new StudentData();
            SelectResult result = studentData.Select();
            return result;
        }

        public static InsertResult Add(string firstName, string lastName)
        {
            Student student = new Student();
            student.FirstName = firstName;
            student.LastName = lastName;
            StudentData studentData = new StudentData();
            InsertResult result = studentData.Insert(student);
            return result;
        }
    }
}