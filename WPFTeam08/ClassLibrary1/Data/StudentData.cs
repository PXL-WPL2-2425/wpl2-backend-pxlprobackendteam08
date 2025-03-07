using ClassLibTeam08.Data.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Data
{
    internal class StudentData : SqlServer
    {
        public StudentData()
        {
            TableName = "students";
        }
        public string TableName { get; set; }
        public SelectResult Select()
        {
            return base.Select(TableName);
        }
    }
}
