using NUnit.Framework;

namespace The_end_of_Gydropon.Tests
{
    [TestFixture]
    public class ErrorTests
    {
        [Test]
        public void TestSpecificTasks()
        {
            string testText = "bebeeb";
            ErrorMessages.BaseErrors.WriteLogMessage(testText);
            string logText = System.IO.File.ReadAllText(@"D:\log.txt");
            Assert.AreEqual(testText, logText);
        }
    }
}