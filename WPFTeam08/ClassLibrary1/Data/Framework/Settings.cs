using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam08.Data.Framework
{
    static class Settings
    {
        public static string GetConnectionString()
        {
            //string connectionString = "Trusted_Connection=True;";
            //string connectionString = "user id = sa;";
            //connectionString += "Password = digital@PXL;";
            //connectionString += $@"Server=DESKTOP-VE15COE\SQLEXPRESS;";
            //connectionString += $"Database=DataEssentials;";
            //connectionString += "TrustServerCertificate=true";
            //return connectionString;

            //Inlog voor SQL server
            string connectionString = "user id = PxlUser_08;";
            connectionString += "Password = 41FFVf7!\r\n;";
            connectionString += $@"Server=10.128.4.7;";
            connectionString += $"Database=Db2025Team_08;";
            return connectionString;
        }
    }
}
