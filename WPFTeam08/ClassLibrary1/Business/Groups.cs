using ClassLibrary08.Data.Framework;
using ClassLibTeam08.Business.Entities;
using ClassLibTeam08.Data.Framework;
using ClassLibTeam08.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ClassLibrary1.Data;

namespace ClassLibrary1.Business
{
    public static class Groups
    {
        private static IConfiguration _configuration;

        public static void SetConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static SelectResult GetGroup(int id)
        {
            var data = new GroupData(_configuration); // Pass the configuration
            SelectResult result = data.SelectByGroupID(id);
            return result;
        }
        
    }
}