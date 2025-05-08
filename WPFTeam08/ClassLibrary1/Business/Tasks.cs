using ClassLibTeam08.Data.Framework;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ClassLibrary1.Data;



namespace ClassLibTeam08.Business
{
    public static class Tasks
    {
        private static IConfiguration _configuration;

        public static void SetConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public static InsertResult AddTask(int groupID, string taskName, string taskDescription, int taskStatus, string taskType)
        {
            var data = new TaskData(_configuration);
            InsertResult result = data.AddTask(groupID, taskName, taskDescription, taskStatus, taskType);
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

        public static SelectResult DeleteTask(int ServiceID)
        {
            var result = new SelectResult();

            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
                {
                    conn.Open();

                    string deleteServiceQuery = "DELETE FROM Services WHERE ServiceID = @ServiceID";
                    SqlCommand cmd = new SqlCommand(deleteServiceQuery, conn);
                    cmd.Parameters.AddWithValue("@ServiceID", ServiceID);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    result.Succeeded = rowsAffected > 0;
                    result.message = rowsAffected > 0 ? "Service succesvol verwijderd." : "Service met deze ID niet gevonden.";
                }
            }
            catch(Exception ex)
            {
                result.Succeeded = false;
                result.message = $"Error: {ex.Message}";
            }

            return result;
            
        }
        public static SelectResult UpdateTask(int groupID, string taskName, string taskDescription, int taskStatus, string taskType)
        {
            var result = new SelectResult();

            try
            {
                using(SqlConnection conn = new SqlConnection(Settings.GetConnectionString()))
                {
                    conn.Open();

                    string updateServiceQuery = "UPDATE Services SET TaskName = @TaskName, TaskDescription = @TaskDescription, TaskStatus = @TaskStatus, TaskType = @TaskType WHERE GroupID = @GroupID";

                    SqlCommand cmd = new SqlCommand(updateServiceQuery, conn);
                    cmd.Parameters.AddWithValue("@GroupID", groupID);
                    cmd.Parameters.AddWithValue("@TaskName", taskName);
                    cmd.Parameters.AddWithValue("@TaskDescription", taskDescription);
                    cmd.Parameters.AddWithValue("@TaskStatus", taskStatus);
                    cmd.Parameters.AddWithValue("@TaskType", taskType);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    result.Succeeded = rowsAffected > 0;
                    result.message = rowsAffected > 0 ? "Service succesvol geupdate." : "Service met deze ID niet gevonden.";
                }
            }
            catch (Exception ex)
            {
                result.Succeeded = false;
                result.message = $"Error: {ex.Message}";
            }

            return result;
        }
    }
}



