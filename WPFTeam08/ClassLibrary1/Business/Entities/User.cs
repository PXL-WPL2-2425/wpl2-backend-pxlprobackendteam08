using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam08.Business.Entities
{
    internal class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName {get; set; }
        public string UserName {get; set; }
        public string Email {get; set; }
        public string Address {get; set; }
        public string Password {get; set; }
        public string BirthDay {get; set; }
        public string Phone {get; set; }
        
        public string GeneratePasswordResetToken()
        {
            var token = Guid.NewGuid().ToString();
            var encodedToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(token));
            string confirmationLink = $"https://monohome.be/confirm-password-change?token={encodedToken}&email={Email}";
            
            return confirmationLink;
        }
    }


}
