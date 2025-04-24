using ClassLibTeam08.Data.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Data
{
    static class PasswordChecker
    {
        public static BaseResult CheckPassword(string password, BaseResult result)
        {

            if (string.IsNullOrEmpty(password))
            {
                result.AddError("leeg passwoord");
                result.Succeeded = false;
                return result;
            }

            else if (password.Length <= 8)

            {
                result.AddError("paswoord moet langer zijn dan 8 tekens");
                result.Succeeded = false;
                return result;
            }

            result.Succeeded = true;
            return result;
        }

        public static InsertResult CheckPasswordInsertResult(string password, InsertResult result)
        {

            if (string.IsNullOrEmpty(password))
            {
                result.message = "leeg passwoord";
                return result;
            }

            else if (password.Length <= 8)

            {
                result.message = "paswoord moet langer zijn dan 8 tekens";
                return result;
            }

            result.Succeeded = true;
            return result;
        }
    }
}

