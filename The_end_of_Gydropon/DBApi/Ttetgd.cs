using System.Data.SqlClient;

namespace The_end_of_Gydropon.DBApi
{
    public class Ttetgd : Main
    {
        private static string data = null;
        public static void add_task_status(int value1, string value2)
        {
            SqlCommand command;            
            string sqlExpression =
                $"INSERT INTO [task_statuses] (task_statuse_id, task_status_name) VALUES({value1}, '{value2}');";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (command = new SqlCommand(sqlExpression, connection))
                {
                    connection.Open();
                    SqlParameter nameParam = new SqlParameter("@task_statuse_id", value1);
                    SqlParameter nameParam2 = new SqlParameter("@task_status_name", value2);
                    command.Parameters.Add(nameParam);
                    command.Parameters.Add(nameParam2);
                    command.ExecuteReader();
                    
                    connection.Close();
                    
                }
            }
        }
    }
}