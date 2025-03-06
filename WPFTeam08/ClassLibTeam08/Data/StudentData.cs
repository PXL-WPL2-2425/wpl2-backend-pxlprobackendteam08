using ClassLibTeam08.Business.Entities;
using ClassLibTeam08.Data.Framework;
using System.Data.SqlClient;
using System.Text;
using System;
using System.Data;

namespace ClassLibTeam08.Data
{

    internal class StudentData : SqlServer
    {
        public StudentData()
        {
            TableName = "students";
        }
        public string TableName { get; set; }
        public SelectResult Select()
        {
            return base.Select(TableName);
        }

        public InsertResult Insert(Student student)
        {
            var result = new InsertResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"Insert INTO {TableName} ");
                insertQuery.Append($"(firstname, lastname) VALUES ");
                insertQuery.Append($"(@firstname, @lastname); ");
                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                   
                        insertCommand.Parameters.Add("@firstname", SqlDbType.VarChar).Value =
                        student.FirstName;
                        insertCommand.Parameters.Add("@lastname", SqlDbType.VarChar).Value =
                        student.LastName;
                        result = InsertRecord(insertCommand);
                    
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

