using NUnit.Framework;
using The_end_of_Gydropon.DBApi;

namespace The_end_of_Gydropon.Tests
{
    [TestFixture]
    public class BasicTests
    {
        [Test, Description("Тест на забирание данных с БД")]
        public static void TestSpecificTasks()
        {
            Ttetgd.add_task_status(1, "dsd");
        }
    }
}