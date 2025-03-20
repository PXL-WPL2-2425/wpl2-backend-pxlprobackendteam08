using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Business.Entities
{
    internal class Login
    {
        public int UserID { get; set; }
        public int loginId { get; set; }
        public DateTime loginTime { get; set; }
        public string ipAdresss { get; set; }
       

    }
}
