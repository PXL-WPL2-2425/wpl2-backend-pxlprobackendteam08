using ClassLibTeam08.Business.Entities;
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Text;
using ClassLibrary08.Data.Framework;
using Org.BouncyCastle.Tls.Crypto.Impl;

namespace ClassLibTeam08.Data.Framework
{
    abstract class SqlServer
    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        public SqlServer()
        {
            connection = new SqlConnection(Settings.GetConnectionString());
        }
        protected SelectResult Select(SqlCommand selectCommand)
        {
            var result = new SelectResult();
            try
            {
                connection=new SqlConnection(Settings.GetConnectionString());

                using (connection)
                {
                    selectCommand.Connection = connection;
                    connection.Open();
                    adapter = new SqlDataAdapter(selectCommand);

                    selectCommand.ExecuteReader();
                    connection.Close();

                    result.DataTable = new DataTable();
                    adapter.Fill(result.DataTable);


                    result.Succeeded = true;
                }

            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;

        }
        protected SelectResult Select(string tableName)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = $"SELECT * FROM {tableName}";
            return Select(command);
        }

        protected InsertResult Insert(SqlCommand insertCommand)
        {
            InsertResult result = new InsertResult();
            try
            {
                using (connection)
                {
                    insertCommand.CommandText += "SET @new_id = SCOPE_IDENTITY();";
                    insertCommand.Parameters.Add("@new_id", SqlDbType.Int).Direction = ParameterDirection.Output;
                    insertCommand.Connection = connection;
                    connection.Open();
                    insertCommand.ExecuteNonQuery();

                    if(insertCommand.Parameters["@new_id"].Value != DBNull.Value)
                    {
                        int newId = Convert.ToInt32(insertCommand.Parameters["@new_id"].Value);
                        result.NewId = newId;
                        result.Succeeded = true;
                    }
                
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public UpdateResult Update(SqlCommand insertCommand)
        {
            UpdateResult result = new UpdateResult();
            try
            {
                connection.ConnectionString = Settings.GetConnectionString();
                using (connection)
                {
                    insertCommand.Connection = connection;
                    connection.Open();
                    insertCommand.ExecuteNonQuery();
                    connection.Close();
                    result.Succeeded = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public DeleteResult Delete(SqlCommand command)
        {
            var result = new DeleteResult();
            try
            {
                connection = new SqlConnection(Settings.GetConnectionString());
                using (connection)
                {
                    result.Succeeded = true;
                    command.Connection = connection;
                    connection.Open();
                    adapter = new SqlDataAdapter(command);
                    result.DataTable = new System.Data.DataTable();
                    adapter.Fill(result.DataTable);
                    connection.Close();
                }

            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }

        protected AggregateResult Count(SqlCommand selectCommand)
        {
            var result = new AggregateResult();
            try
            {
                connection = new SqlConnection(Settings.GetConnectionString());
                using (connection)
                {
                    selectCommand.Connection = connection;
                    connection.Open();
                    adapter = new SqlDataAdapter(selectCommand);

                
                    result.queryResult = (int)selectCommand.ExecuteScalar();



                    connection.Close();
                    result.Succeeded = true;
                }

            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;

        }
    }

   

    //public 
}
