using ClassLibTeam08.Data.Framework;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Data
{
    internal class ToDoListData : SqlServer
    {
        public SelectResult SelectByID(int id)
        {
            SelectResult result = new SelectResult();
            try
            {
                StringBuilder selectQuery = new StringBuilder();
                selectQuery.Append($"SELECT * FROM ToDoList WHERE id = {id}");
                using (SqlCommand selectCmd = new SqlCommand(selectQuery.ToString()))
                {
                    result = Select(selectCmd);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }
    }
}
