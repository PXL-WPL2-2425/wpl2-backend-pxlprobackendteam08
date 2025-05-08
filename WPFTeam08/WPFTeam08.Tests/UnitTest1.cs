using NUnit.Framework;
using ClassLibrary1.Business.Entities;

namespace WPFTeam08.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            int getal1 = 1;
            int getal2 = 1;

            Assert.That(getal1 == getal2);
        }

        [Test]
        public void Test2()
        {
            int getal3 = 1;
            int getal4 = 2;

            Assert.That(getal3 == getal4);
        }
    }
}