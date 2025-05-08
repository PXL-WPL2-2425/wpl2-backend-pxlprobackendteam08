using NUnit.Framework;
using ClassLibrary1.Business.Entities;
using ClassLibTeam08.Business.Entities;

namespace WPFTeam08.Tests
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void UserConstructor()
        {
            // Input variabelen
            string firstName = "John";
            string lastName = "Doe";
            string userName = "johndoe";
            string email = "john@example.com";
            string address = "123 Main St";
            string password = "Test1234!";
            DateTime birthday = new DateTime(1990, 1, 1);
            string phone = "123-456-7890";
            string role = "client";

            // Aanmaken user object
            User user = new User(firstName, lastName, userName, email, address, password, birthday, phone, role);

            // Testen user class
            Assert.That(firstName == user.FirstName);
            Assert.That(lastName == user.LastName);
            Assert.That(userName == user.UserName);
            Assert.That(email == user.Email);
            Assert.That(address == user.Address);
            Assert.That(birthday == user.BirthDay);
            Assert.That(phone == user.Phone);
            Assert.That(role == user.Rol);

            // Testen of password geset is
            Assert.That(user.Password != null);

            // Testen password hasing
            Assert.That(password != user.Password);
        }
    }
}