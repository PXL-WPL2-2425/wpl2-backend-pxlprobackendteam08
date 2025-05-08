using ClassLibrary08.Data.Framework;
using ClassLibrary1.Business.Entities;
using ClassLibTeam08.Business.Entities;
using ClassLibTeam08.Data.Framework;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Data
{
    internal class GroupMemberData : SqlServer
    {
        public SelectResult SelectByMemberID(int id)
        {
            SelectResult result = new SelectResult();
            try
            {
                StringBuilder selectQuery = new StringBuilder();
                selectQuery.Append($"SELECT * FROM GroupMembers WHERE MemberID = {id}");
                using (SqlCommand selectCmd = new SqlCommand(selectQuery.ToString()))
                {
                    result = Select(selectCmd);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }

        public SelectResult SelectByGroupID(int id)
        {
            SelectResult result = new SelectResult();
            try
            {
                StringBuilder selectQuery = new StringBuilder();
                selectQuery.Append($"SELECT * FROM GroupMembers WHERE groupid = {id}");
                using (SqlCommand selectCmd = new SqlCommand(selectQuery.ToString()))
                {
                    result = Select(selectCmd);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }

        public SelectResult SelectbyUserID(int id)
        {
            SelectResult result = new SelectResult();
            try
            {
                StringBuilder selectQuery = new StringBuilder();
                selectQuery.Append($"SELECT * FROM GroupMembers WHERE userID = {id}");
                using (SqlCommand selectCmd = new SqlCommand(selectQuery.ToString()))
                {
                    result = Select(selectCmd);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }

            public DeleteResult DeleteByUserID(int id)
    {
        DeleteResult result = new DeleteResult();
        try
        {
            StringBuilder deleteQuery = new StringBuilder();
            deleteQuery.Append($"DELETE FROM GroupMembers WHERE userID = {id};");
            using (SqlCommand deleteCmd = new SqlCommand(deleteQuery.ToString()))
            {
                result = Delete(deleteCmd);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
        return result;
    }


    public DeleteResult DeleteByGroupID(int id)
    {
        DeleteResult result = new DeleteResult();
        try
        {
            StringBuilder deleteQuery = new StringBuilder();
            deleteQuery.Append($"DELETE FROM GroupMembers WHERE groupid = {id};");
            using (SqlCommand deleteCmd = new SqlCommand(deleteQuery.ToString()))
            {
                result = Delete(deleteCmd);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
        return result;
    }

        public InsertResult InsertGroupMember(GroupMember groupMember)
        {
            var result = new InsertResult();
            try
            {
                //SQL Command
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"Insert INTO GroupMembers");
                insertQuery.Append($"(userid, groupid, isadmin) VALUES");
                insertQuery.Append($"(@userid, @groupid, @isadmin);");
                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    insertCommand.Parameters.Add("@userid", SqlDbType.VarChar).Value =
                    groupMember.UserID;
                    insertCommand.Parameters.Add("@groupid", SqlDbType.VarChar).Value =
                    groupMember.GroupID;
                    insertCommand.Parameters.Add("@isadmin", SqlDbType.VarChar).Value =
                    groupMember.IsAdmin;                
                    
                    result = Insert(insertCommand);
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
