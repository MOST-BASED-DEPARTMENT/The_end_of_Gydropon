using NUnit.Framework;
using The_end_of_Gydropon.API;

namespace The_end_of_Gydropon.Tests
{
    [TestFixture]
    public class BasicTests
    {
        private string ConnectionString;

        [Test, Description("My really really cool test")]
        public void TestSpecificTasks()
        {
            Base.TakeTasks("sdfsd");
        }
    }
}