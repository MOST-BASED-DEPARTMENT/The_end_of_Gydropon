using System;
using System.Globalization;
using NUnit.Framework;

namespace The_end_of_Gydropon.Tests
{
    [TestFixture]
    public class ErrorTests
    {
        [Test]
        public void TestSpecificTasks()
        {
            string randomText = "bebeebe";
            string addingInfo(string text) => text + " - on " + DateTime.Now.ToString(CultureInfo.InvariantCulture);
            string testText = addingInfo(randomText);
            ErrorMessages.BaseErrors.WriteLogMessage(randomText);
            string logText = System.IO.File.ReadAllText(@"D:\log.txt");
            Assert.AreEqual(testText, logText);
        }
    }
}