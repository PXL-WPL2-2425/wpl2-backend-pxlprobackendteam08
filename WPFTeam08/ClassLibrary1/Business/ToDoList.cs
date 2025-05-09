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
    }
}
