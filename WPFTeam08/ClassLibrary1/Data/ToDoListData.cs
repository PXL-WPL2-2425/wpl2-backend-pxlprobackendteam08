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
        public InsertResult InsertToDoList(int id, string taskName, string assignedTo, string noticeFor, int isRepeat, string recurEvery, string description, DateTime executeBefore, DateTime executedTime) 
        {
            InsertResult result = new InsertResult();
            try
            {
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"INSERT INTO ToDoList (taskName, assignedTo, noticeFor, isRepeat, recurEvery, description, executeBefore, executedTime) VALUES ( @taskName, @assignedTo, @noticeFor, @isRepeat, @recurEvery, @description, @executeBefore, @executedTime)");
                using (SqlCommand insertCmd = new SqlCommand(insertQuery.ToString()))
                {
                    insertCmd.Parameters.AddWithValue("@taskName", taskName);
                    insertCmd.Parameters.AddWithValue("@assignedTo", assignedTo);
                    insertCmd.Parameters.AddWithValue("@noticeFor", noticeFor);
                    insertCmd.Parameters.AddWithValue("@isRepeat", isRepeat);
                    insertCmd.Parameters.AddWithValue("@recurEvery", recurEvery);
                    insertCmd.Parameters.AddWithValue("@description", description);
                    insertCmd.Parameters.AddWithValue("@executeBefore", executeBefore);
                    insertCmd.Parameters.AddWithValue("@executedTime", executedTime);
                    result = Insert(insertCmd);
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
