using ClassLibrary1.Data;
using ClassLibTeam08.Data.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Business
{
    public static class ToDoList
    {
        public static SelectResult GetToDoList(int id)
        {
            ToDoListData data = new ToDoListData();
            SelectResult result = data.SelectByID(id);
            return result;
        }
        public static InsertResult PostToDoList(int id, string taskName, string assignedTo, string noticeFor, int isRepeat, string recurEvery, string description, DateTime executeBefore, DateTime executedTime)
        {
            ToDoListData data = new ToDoListData();
            InsertResult result = data.InsertToDoList(id, taskName, assignedTo, noticeFor, isRepeat, description, recurEvery, executeBefore, executedTime);
            return result;
        }
    }
}
