using System;
using System.Data.SqlClient;

namespace The_end_of_Gydropon.API
{
    public class Base
    {
        
        
        private static string CreateConnectionString(string userId, string password) =>
            $"server=ip; database=db; user id={userId}; password={password};";
        
        public static string TakeTasks()
        {
            try
            {
                string task = null;
                using (SqlConnection connection = new SqlConnection(CreateConnectionString("3", "34")))
                {

                }

                return task;
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

                return task;
            }
            catch (Exception error)
            {
                // ignored
            }

            return "0";
        }
    }
}