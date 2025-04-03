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

        public static SelectResult GetTasksByGroup(int groupId)
        {
            var data = new TaskData(_configuration);
            SelectResult result = data.SelectByGroupID(groupId);
            return result;
        }
        public static SelectResult AddTask(int SupplierId, string ServiceName, string Description)
        {
            var data = new TaskData(_configuration);
            SelectResult result = data.SelectByGroupID(SupplierId, ServiceName, Description);
            return result;
        }
    }
}
