using ClassLibTeam08.Data.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam08.Business
{
    
        public static class Tasks
        {
            public static SelectResult GetTasks()
            {
                ManualData manualData = new ManualData();
                SelectResult result = manualData.Select();
                return result;
            }
            public static void Add(string firstName, string lastName)
            {
                //TODO -> InsertResult
                //InsertResult result=server.Insert(data ...);
            }
        }
    
}
