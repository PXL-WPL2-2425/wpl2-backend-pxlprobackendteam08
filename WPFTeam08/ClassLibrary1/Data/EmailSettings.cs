using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ClassLibrary1.Data
{
    public class EmailSettings
    {
        //private string smtpServer = "smtp.gmail.com";
        //private int smtpPort = 587;
        //private string address = "monohomepass@gmail.com";
        //private string password = "dndz vqer tfcm ierc";

        //public string SmtpServer
        //{
        //    get { return smtpServer; }
        //    set { smtpServer = value; }
        //}
        //public int SmtpPort
        //{
        //    get { return smtpPort; }
        //    set { smtpPort = value; }
        //}
        //public string Address
        //{
        //    get { return address; }
        //    set { address = value; }
        //}
        //public string Password
        //{
        //    get { return password; }
        //    set { password = value; }
        //}

        public string SmtpServer { get; }
        public int SmtpPort { get; }
        public string Address { get; }
        public string Password { get; }

        public EmailSettings(IConfiguration configuration)
        {
            SmtpServer = configuration["EmailSettings:SmtpServer"];
            SmtpPort = int.Parse(configuration["EmailSettings:SmtpPort"]);
            Address = configuration["EmailSettings:Address"];
            Password = configuration["EmailSettings:Password"];
        }
    }
}
