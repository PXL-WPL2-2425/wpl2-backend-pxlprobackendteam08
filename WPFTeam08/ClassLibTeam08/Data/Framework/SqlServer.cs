using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                using (connection)
                {
                    selectCommand.Connection = connection;
                    connection.Open();
                    adapter = new SqlDataAdapter(selectCommand);
                    result.DataTable = new System.Data.DataTable();
                    adapter.Fill(result.DataTable);
                    connection.Close();
                }
                result.Succeeded = true;
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

    }
}
