using System;
using System.Globalization;
using NUnit.Framework;

namespace The_end_of_Gydropon.Tests
{
    [TestFixture]
    public class ErrorTests
    {
        [Test]
        public void TestLogging()
        {
            string randomText = "bebeebe";
            string addingInfo(string text)
            {
                return text + " - on " + DateTime.Now.ToString(CultureInfo.InvariantCulture);
            }

            string testText = addingInfo(randomText);
            ErrorMessages.BaseErrors.WriteLogMessage(randomText);
            string logText = System.IO.File.ReadAllText(@"D:\log.txt");
            
            Assert.AreEqual(testText, logText);
        }

        [Test]
        public void TestErrorCodes()
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