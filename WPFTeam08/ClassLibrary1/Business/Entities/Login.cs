using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Business.Entities
{
    internal class Login
    {
        public int LoginId { get; set; }
        public int UserID { get; set; }
        public DateTime LoginTime { get; set; }
        public string IpAdresss { get; set; }


    }
}
