using NUnit.Framework;
using The_end_of_Gydropon.MainAPI;

namespace The_end_of_Gydropon.Tests
{
    [TestFixture]
    public static class BasicTests
    {
        private static string _connectionString = null;

        [Test, Description("My really really cool test")]
        public static void TestSpecificTasks()
        {
            Main.TakeTasks("sdfsd");
        }
    }
}