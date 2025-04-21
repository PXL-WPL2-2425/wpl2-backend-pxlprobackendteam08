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
        public EmailSettings(IConfiguration configuration)
        {
            SmtpServer = "smtp.gmail.com";
            SmtpPort = 587;
            Address = "monohomepass@gmail.com";
            Password = "dndz vqer tfcm ierc";
        }

        public string SmtpServer { get; }
        public int SmtpPort { get; }
        public string Address { get; }
        public string Password { get; }
    }
}
