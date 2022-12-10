using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace The_end_of_Gydropon.DBApi
{
    public class Main
    {
        private SqlConnection _servConn = new SqlConnection();

        /// <summary>
        /// Метод который из пароля и логина делает ConnectionString
        /// </summary>
        /// <param name="userId">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns>ConnectionString для подключения к базе данных</returns>
        public static string CreateConnectionString(string userId, string password) =>
            $"Data Source = 46.39.232.190; Initial Catalog = test;User Id={userId}; Password={password};";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static bool ConnectWithDB(string Login, string Password)
        {
            using (SqlConnection connection = new SqlConnection(CreateConnectionString(Login, Password)))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}