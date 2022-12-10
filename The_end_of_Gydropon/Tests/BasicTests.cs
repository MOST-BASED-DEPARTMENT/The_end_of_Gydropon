using NUnit.Framework;
using The_end_of_Gydropon.DBApi;

namespace The_end_of_Gydropon.Tests
{
    [TestFixture]
    public class BasicTests
    {
        private static string _connectionString = null;

        private protected static string ConnectionString
        {
            get => _connectionString;
            set => _connectionString = value;
        }

        [Test, Description("Тест на забирание данных с БД")]
        public static void TestSpecificTasks()
        {
            Assert.AreEqual(Taking.RunProcedure("add_task"), "бурундук");
        }
    }
}