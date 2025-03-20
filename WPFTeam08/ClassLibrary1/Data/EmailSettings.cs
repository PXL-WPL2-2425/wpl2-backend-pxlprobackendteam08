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
            SmtpServer = configuration["EmailSettings:SmtpServer"] ?? throw new ArgumentNullException(nameof(configuration), "SmtpServer is not configured.");
            SmtpPort = int.TryParse(configuration["EmailSettings:SmtpPort"], out var port) ? port : throw new ArgumentNullException(nameof(configuration), "SmtpPort is not configured or invalid.");
            Address = configuration["EmailSettings:Address"] ?? throw new ArgumentNullException(nameof(configuration), "Address is not configured.");
            Password = configuration["EmailSettings:Password"] ?? throw new ArgumentNullException(nameof(configuration), "Password is not configured.");
        }

        public string SmtpServer { get; }
        public int SmtpPort { get; }
        public string Address { get; }
        public string Password { get; }
    }
}
