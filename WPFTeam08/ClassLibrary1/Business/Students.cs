using ClassLibrary1.Data;
using ClassLibTeam08.Data.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Business
{
    public static class Students
    {
        public static SelectResult GetStudents()
        {
            StudentData studentData = new StudentData();
            SelectResult result = studentData.Select();
            return result;
        }
        public static void Add(string firstName, string lastName)
        {
            //TODO -> InsertResult

        }
    }
}