using NUnit.Framework;

[TestFixture]
public class UnitTest1
{
    [Test]
    public void TestMethod1()
    {
        int test = 3;
        int result = test;

        Assert.That(result, Is.EqualTo(3));
    }
}