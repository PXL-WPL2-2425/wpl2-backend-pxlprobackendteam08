using ClassLibrary08.Data.Framework;
using ClassLibTeam08.Data;
using ClassLibTeam08.Data.Framework;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Configuration;
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


        //
        private static string _connectionString = "TrustServerCertificate=True; Server=10.128.4.7; Database=Db2025Team_08; User Id=PxlUser_08; Password=GoTeam08";
        public static SelectResult AddedTask(int supplierId, string serviceName, string description)
        {
            var result = new SelectResult();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "INSERT INTO Tasks (SupplierId, ServiceName, Description) VALUES (@SupplierId, @ServiceName, @Description)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SupplierId", supplierId);
                    cmd.Parameters.AddWithValue("@ServiceName", serviceName);
                    cmd.Parameters.AddWithValue("@Description", description);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    result.Message = rowsAffected > 0 ? "Taak succesvol toegevoegd." : "Geen gegevens toegevoegd.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Fout bij toevoegen van taak: {ex.Message}";
            }

            return result;
        }
        //


        public static SelectResult GetTasksByGroup(int TaskId)
        {
            var data = new TaskData(_configuration);
            SelectResult result = data.SelectByGroupID(TaskId);
            return result;
        }
        public static SelectResult AddTask(int SupplierId, string ServiceName, string Description)
        {
            var data = new TaskData(_configuration);
            SelectResult result = data.SelectByGroupID(SupplierId, ServiceName, Description);
            return result;
        }
        public static SelectResult DeleteTask(int TaskId)
        {
            var data = new TaskData(_configuration);
            SelectResult result = data.SelectByGroupID(TaskId);
            return result;
        }
        public static SelectResult UpdateTask(/*int TaskId,*/ int SupplierId, string ServiceName, string Description)
        {
            var data = new TaskData(_configuration);
            SelectResult result = data.SelectByGroupID(/*TaskId,*/ SupplierId, ServiceName, Description);
            return result;
        }
    }
}
