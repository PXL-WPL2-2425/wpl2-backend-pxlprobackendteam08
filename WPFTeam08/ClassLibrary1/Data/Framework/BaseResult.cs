using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam08.Data.Framework
{
    public abstract class BaseResult
    {
        private List<string> errors = new List<string>();
        public bool Succeeded { get; set; }
        public IEnumerable<string> Errors => errors;

        public string Token { get => _token; set => _token = value; }

        public string message;
        string _token = "default";
        public static int timeOut;
        public void AddError(string error)
        {
            errors.Add(error);
        }

        public string GenerateToken()
        {

            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            string token = Convert.ToBase64String(time.Concat(key).ToArray());

            _token = token;

            return token;
        }
    }
}
