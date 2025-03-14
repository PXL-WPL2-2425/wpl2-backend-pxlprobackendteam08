using ClassLibrary08.Data.Framework;
using ClassLibTeam08.Data;
using ClassLibTeam08.Data.Framework;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ClassLibTeam08.Business.Entities
{
    public static class Users
    {
        public static SelectResult GetUser(int id)
        {
            UserData data = new UserData();
            SelectResult result = data.SelectByID(id);
            return result;
        }

        public static SelectResult CheckIfUserExists(string email)
        {
            UserData data = new UserData();
            SelectResult result = data.SelectAllEmail();

            foreach (DataRow row in result.DataTable.Rows)
            {
                if ((string)row[0] == email)
                {
                    result.Succeeded = false;
                    return result;
                }
            }

            result.Succeeded = true;
            return result;
        }

        public static DeleteResult DeleteUser(int id)
        {
            UserData data = new UserData();
            DeleteResult result = data.DeleteByID(id);
            return result;
        }

        public static SelectResult SelectAllEmailAndPasswords()
        {
            UserData data = new UserData();
            SelectResult result = data.SelectAllEmail();
            return result;
        }

        public static SelectResult SelectByEmailAndPasswords(string email, string password)
        {
            UserData data = new UserData();
            SelectResult result = data.SelectByEmailAndPasswords(email, password);
            return result;
        }

        public static UpdateResult ChangePassWord(int userID, string newPassword)
        {
            UserData userData = new UserData(); 
            return userData.ChangePassword(userID, newPassword);
        }

        public static UpdateResult UpdateUserData(int id, string firstName, string lastName, string userName, string email, string adres, string wachtwoord, string Birhday, string phone)
        {
            UserData userData = new UserData();
           return userData.UpdateAllUserData(id, firstName,lastName, userName, email, adres, wachtwoord, Birhday, phone);
        }

    }
}