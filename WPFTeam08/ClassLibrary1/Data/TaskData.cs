using ClassLibrary08.Data.Framework;
using ClassLibTeam08.Data.Framework;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace ClassLibrary1.Data
{
    internal class TaskData : SqlServer
    {
        private readonly IConfiguration _configuration;

        public string TableName { get; set; }

        public TaskData(IConfiguration configuration)
        {
            TableName = "Tasks";
            _configuration = configuration;
        }

        public SelectResult SelectByGroupID(int groupId, string serviceName, string description)
        {
            var result = new SelectResult();
            try
            {
                StringBuilder selectQuery = new StringBuilder();
                selectQuery.Append($"SELECT * FROM Tasks WHERE GroupID = {groupId}");
                using (SqlCommand selectCommand = new SqlCommand(selectQuery.ToString()))
                {
                    result = Select(selectCommand);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }

        public DeleteResult DeleteTaskByID(int TaskID)
        {
            var result = new DeleteResult();
            try
            {
                StringBuilder selectQuery = new StringBuilder();
                selectQuery.Append($"Delete FROM Tasks WHERE TaskID = {TaskID}");
                using (SqlCommand command = new SqlCommand(selectQuery.ToString()))
                {
                    result = Delete(command);
                }
            }
            catch (Exception ex)
            {
                result.Succeeded = false;
                result.AddError(ex.Message);
                throw new Exception(ex.Message, ex);
            }

            return result;
        }

        public SelectResult SelectByGroupID(int groupId)
        {
            var result = new SelectResult();
            try
            {
                StringBuilder selectQuery = new StringBuilder();
                selectQuery.Append($"SELECT * FROM Tasks WHERE GroupID = {groupId}");
                using (SqlCommand selectCommand = new SqlCommand(selectQuery.ToString()))
                {
                    result = Select(selectCommand);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }

        public UpdateResult UpdateTask(string taskName, string taskDescription, int taskStatus, string Tasktype, string reminder, string assigned, int taskID, string deadLine)
        {
            var result = new UpdateResult();
            try
            {
                StringBuilder selectQuery = new StringBuilder();
                selectQuery.Append($"UPDATE {TableName} SET Taskname = @taskName, TaskDescription = @tasksdescription, TaskStatus = @taskStatus, TaskType = @taskType, DeadLine = @deadline, Reminder = @reminder, Assigned = @assigned" +
                                   $"  WHERE TaskID = @taskID;");

                using (SqlCommand selectCommand = new SqlCommand(selectQuery.ToString()))
                {
                    selectCommand.Parameters.AddWithValue("@taskName", taskName);
                    selectCommand.Parameters.AddWithValue("@taskStatus", taskStatus);
                    selectCommand.Parameters.AddWithValue("@taskType", Tasktype);
                    selectCommand.Parameters.AddWithValue("@reminder", reminder);
                    selectCommand.Parameters.AddWithValue("@assigned", assigned);
                    selectCommand.Parameters.AddWithValue("@taskID", taskID);
                    selectCommand.Parameters.AddWithValue("@tasksdescription", taskDescription);
                    selectCommand.Parameters.AddWithValue("@deadline", deadLine);
                    result = Update(selectCommand);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }

        public InsertResult AddTask(int groupID, string taskName, string taskDescription, int taskStatus, string taskType, string deadLine, string reminder, string assignedPerson)
        {
            var result = new InsertResult();

            result.Succeeded = true;

            SqlCommand cmd = new SqlCommand("insert into tasks (groupid, taskname, taskdescription, taskstatus, tasktype, DeadLine, Reminder, Assigned) " +
                "values (@groupid, @taskname, @taskdescription, @taskstatus, @tasktype, @deadline, @reminder, @assigned)");

            cmd.Parameters.AddWithValue("@groupid", groupID);
            cmd.Parameters.AddWithValue("@taskname", taskName);
            cmd.Parameters.AddWithValue("@taskdescription", taskDescription);
            cmd.Parameters.AddWithValue("@taskstatus", taskStatus);
            cmd.Parameters.AddWithValue("@tasktype", taskType);
            cmd.Parameters.AddWithValue("@deadline", deadLine);
            cmd.Parameters.AddWithValue("@reminder", reminder);
            cmd.Parameters.AddWithValue("@assigned", assignedPerson);

            try
            {
                using (cmd)
                {
                    result = Insert(cmd);
                }

            }

            catch (Exception ex)
            {
                result.Succeeded = false;
                result.AddError(ex.ToString());
            }

            return result;
        }
        public SelectResult SelectAll()
        {
            var result = new SelectResult();
            try
            {
                StringBuilder selectQuery = new StringBuilder();
                selectQuery.Append($"SELECT * FROM {TableName}");
                using (SqlCommand selectCommand = new SqlCommand(selectQuery.ToString()))
                {
                    result = Select(selectCommand);
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
