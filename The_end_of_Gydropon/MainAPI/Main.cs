using System;
using System.Data.SqlClient;

namespace The_end_of_Gydropon.MainAPI
{
    public class Main
    {
        private static string CreateConnectionString(string userId, string password) =>
            $"server=ip; database=db; user id={userId}; password={password};";
        
        public static string TakeTasks()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(CreateConnectionString("3", "34")))
                {
                    connection.Open();
                    
                    connection.Close();
                }

                return null;
            }
            catch (Exception error)
            {
                // ignored
            }

            return "0";
        }

        public static string TakeTasks(string tasks)
        {
            try
            {
                string task = null;
                using (SqlConnection connection = new SqlConnection(CreateConnectionString("3", "34")))
                {

                }

                return null;
            }
            catch (Exception error)
            {
                // ignored
            }

            return "0";
        }
        
        
    }
}