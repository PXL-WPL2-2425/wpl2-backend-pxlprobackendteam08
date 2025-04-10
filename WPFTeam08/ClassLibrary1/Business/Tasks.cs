﻿using ClassLibrary08.Data.Framework;
using ClassLibTeam08.Data;
using ClassLibTeam08.Data.Framework;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Configuration;
using ClassLibrary1.Data;
using WebApiTeam08.DTOs;


namespace ClassLibTeam08.Business
{
    public static class Tasks
    {
        private static IConfiguration _configuration;

        public static void SetConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        //private static string _connectionString = "TrustServerCertificate=True; Server=10.128.4.7; Database=Db2025Team_08; User Id=PxlUser_08; Password=GoTeam08";

        //private static string _connectionString = ClassLibrary1.ClassLib.Default.SqlServerConnect;
        private static string _connectionString = ClassLibrary1.ClassLib.Default.MyLocalDB;
        //AddOrUpdateTask
        public static SelectResult AddTask(TaskRequest dto) 
        {
            var result = new SelectResult();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    //Controleer per e-mail of de leverancier bestaat
                    string checkSupplierQuery = "SELECT SupplierID FROM Suppliers WHERE Email = @Email";
                    SqlCommand checkCmd = new SqlCommand(checkSupplierQuery, conn);
                    checkCmd.Parameters.AddWithValue("@Email", dto.Email);

                    object supplierIdObj = checkCmd.ExecuteScalar();

                    int supplierId;
                    if (supplierIdObj != null)
                    {
                        supplierId = Convert.ToInt32(supplierIdObj);
                    }
                    else
                    {
                        // 2. Een nieuwe leverancier invoegen
                        string insertSupplier = @"INSERT INTO Suppliers (CompanyName, Email, Phone, Address, ServiceType)
                                          VALUES (@CompanyName, @Email, @Phone, @Address, @ServiceType);
                                          SELECT SCOPE_IDENTITY();";
                        SqlCommand insertCmd = new SqlCommand(insertSupplier, conn);
                        insertCmd.Parameters.AddWithValue("@CompanyName", dto.CompanyName);
                        insertCmd.Parameters.AddWithValue("@Email", dto.Email);
                        insertCmd.Parameters.AddWithValue("@Phone", dto.Phone);
                        insertCmd.Parameters.AddWithValue("@Address", dto.Address);
                        insertCmd.Parameters.AddWithValue("@ServiceType", dto.ServiceType);

                        supplierId = Convert.ToInt32(insertCmd.ExecuteScalar());
                    }

                    // 3. Een service invoegen
                    string insertService = @"INSERT INTO Services (SupplierID, ServiceName, Descriptions)
                                     VALUES (@SupplierID, @ServiceName, @Description)";
                    SqlCommand serviceCmd = new SqlCommand(insertService, conn);
                    serviceCmd.Parameters.AddWithValue("@SupplierID", supplierId);
                    serviceCmd.Parameters.AddWithValue("@ServiceName", dto.ServiceName);
                    serviceCmd.Parameters.AddWithValue("@Description", dto.Description);

                    int serviceRows = serviceCmd.ExecuteNonQuery();
                    result.Message = serviceRows > 0 ? "Service succesvol toegevoegd." : "Fout bij het toevoegen van een service.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error: {ex.Message}";
            }

            return result;
        }



        public static SelectResult GetTasksByGroup(int TaskId)
        {
            var data = new TaskData(_configuration);
            SelectResult result = data.SelectByGroupID(TaskId);
            return result;
        }
        //public static SelectResult AddTask(int SupplierId, string ServiceName, string Description)
        //{
        //    var data = new TaskData(_configuration);
        //    SelectResult result = data.SelectByGroupID(SupplierId, ServiceName, Description);
        //    return result;
        //}
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
