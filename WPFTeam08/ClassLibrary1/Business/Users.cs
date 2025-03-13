using ClassLibrary08.Data.Framework;
using ClassLibTeam08.Data;
using ClassLibTeam08.Data.Framework;

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

        public static DeleteResult DeleteUser(int id)
        {
            UserData data = new UserData();
            DeleteResult result = data.DeleteByID(id);
            return result;
        }


        public static InsertResult Add(string firstName, string lastName, string username, string email, string address, string password, string birthday, string phone)
        {
            User user = new User();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.UserName = username;
            user.Email = email;
            user.Address = address;
            user.Password = password;
            user.BirthDay = birthday;
            user.Phone = phone;
            UserData userData = new UserData();
            InsertResult result = userData.Insert(user);
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