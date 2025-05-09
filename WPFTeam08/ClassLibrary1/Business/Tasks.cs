using ClassLibTeam08.Data.Framework;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ClassLibrary1.Data;

using System.Data;






namespace ClassLibTeam08.Business
{
    public static class Tasks
    {
        private static IConfiguration _configuration;

        public static void SetConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public static InsertResult AddTask(int groupID, string taskName, string taskDescription, int taskStatus, string taskType, string deadLine, string reminder, string assignedPerson)
        {
            var data = new TaskData(_configuration);
            InsertResult result = data.AddTask(groupID, taskName, taskDescription, taskStatus, taskType, deadLine, reminder, assignedPerson);
            return result;
        }
        
        public static SelectResult GetTasksByGroup(int TaskId)
        {
            var data = new TaskData(_configuration);
            SelectResult result = data.SelectByGroupID(TaskId);
            return result;
        }

        public static SelectResult GetAllTasks()
        {
            var data = new TaskData(_configuration);
            SelectResult result = data.SelectAll();
            return result;
        }

        public static DeleteResult DeleteTask(int taskID)
        {
            var data = new TaskData(_configuration);
            DeleteResult result = data.DeleteTaskByID(taskID);
            return result;
        }
        public static UpdateResult UpdateTask(string taskName, string taskDscription, int taskStatus, string Tasktype, string reminder, string assigned, int taskID, string deadLine)
        {
            var data = new TaskData(_configuration);
            UpdateResult result = data.UpdateTask(taskName, taskDscription, taskStatus, Tasktype, reminder, assigned, taskID, deadLine);
            return result;
        }

    }
}



