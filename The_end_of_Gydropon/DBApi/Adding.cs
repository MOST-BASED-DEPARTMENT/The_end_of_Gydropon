using System.Data.SqlClient;
using System.Globalization;

namespace The_end_of_Gydropon.DBApi
{
    public class Adding : Main
    {
        private string data;
        private SqlCommand command; 
        
        public void add_task(int id, int id2, int id3, int id4, int id5, CultureInfo id6, CultureInfo id7, CultureInfo id8, string id9)
        {
            string sqlExpression =
                $"INSERT INTO [tasks] (task_id, task_execution_id, task_field_id, task_type_id, task_status_id, task_date, task_start_time, task_finishing_time, task_description) VALUES({id}, {id2}, {id3}, {id4}, {id5}, '{id6}', '{id7}', '{id8}', {id9});";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (command = new SqlCommand(sqlExpression, connection))
                {
                    connection.Open();
                    SqlParameter nameParam = new SqlParameter("@task_id", id);
                    SqlParameter nameParam2 = new SqlParameter("@task_execution_id", id2);
                    SqlParameter nameParam3 = new SqlParameter("@task_field_id", id3);
                    SqlParameter nameParam4 = new SqlParameter("@task_type_id", id4);
                    SqlParameter nameParam5 = new SqlParameter("@task_status_id", id5);
                    SqlParameter nameParam6 = new SqlParameter("@task_date", id6);
                    SqlParameter nameParam7 = new SqlParameter("@task_start_time", id7);
                    SqlParameter nameParam8 = new SqlParameter("@task_finishing_time", id8);
                    SqlParameter nameParam9 = new SqlParameter("@task_description", id9);
                    command.Parameters.Add(nameParam);
                    command.Parameters.Add(nameParam2);
                    command.Parameters.Add(nameParam3);
                    command.Parameters.Add(nameParam4);
                    command.Parameters.Add(nameParam5);
                    command.Parameters.Add(nameParam6);
                    command.Parameters.Add(nameParam7);
                    command.Parameters.Add(nameParam8);
                    command.Parameters.Add(nameParam9);
                    command.ExecuteReader();
                    connection.Close();
                }
            }
        }

        public void add_task_status(int id, string id2)
        {
            string sqlExpression =
                $"INSERT INTO [task_status] (task_statuse_id, task_status_name) VALUES({id}, '{id2}');";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (command = new SqlCommand(sqlExpression, connection))
                {
                    connection.Open();
                    SqlParameter nameParam = new SqlParameter("@task_statuse_id", id);
                    SqlParameter nameParam2 = new SqlParameter("@task_status_name", id2);
                    command.Parameters.Add(nameParam);
                    command.Parameters.Add(nameParam2);
                    command.ExecuteReader();
                    connection.Close();
                }
            }
        }

        public void add_task_type(int id, string id2, int id3, int id4, int id5)
        {
            string sqlExpression =
                $"INSERT INTO task_type (task_type_id, task_type_name, superior_type_id, chemical_id, agricultural_machinery_id) VALUES({id}, '{id2}', {id3}, {id4}, {id5});";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (command = new SqlCommand(sqlExpression, connection))
                {
                    connection.Open();
                    SqlParameter nameParam = new SqlParameter("@task_type_id", id);
                    SqlParameter nameParam2 = new SqlParameter("task_type_name", id2);
                    SqlParameter nameParam3 = new SqlParameter("@superior_type_id", id3);
                    SqlParameter nameParam4 = new SqlParameter("@chemical_id", id4);
                    SqlParameter nameParam5 = new SqlParameter("@agricultural_machinery_id", id5);
                    command.Parameters.Add(nameParam);
                    command.Parameters.Add(nameParam2);
                    command.Parameters.Add(nameParam3);
                    command.Parameters.Add(nameParam4);
                    command.Parameters.Add(nameParam5);
                    command.ExecuteReader();
                    connection.Close();
                }
            }
        }

        public void add_field(int id, int id2, string id3, int id4)
        {
            string sqlExpression =
                $"INSERT INTO fields (field_id, field_area, field_identifier, fiend_plant_id) VALUES({id}, {id2}, '{id3}', {id4});";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (command = new SqlCommand(sqlExpression, connection))
                {
                    connection.Open();
                    SqlParameter nameParam = new SqlParameter("@field_id", id);
                    SqlParameter nameParam2 = new SqlParameter("@field_area", id2);
                    SqlParameter nameParam3 = new SqlParameter("@field_identifier", id3);
                    SqlParameter nameParam4 = new SqlParameter("@fiend_plant_id", id4);
                    command.Parameters.Add(nameParam);
                    command.Parameters.Add(nameParam2);
                    command.Parameters.Add(nameParam3);
                    command.Parameters.Add(nameParam4);
                    command.ExecuteReader();
                    connection.Close();
                }
            }
        }

        public void add_user(int id, int id2, string id3, string id4)
        {
            string sqlExpression =
                $"INSERT INTO users (user_id, user_post_id, user_login, user_password) VALUES({id}, {id2}, '{id3}', '{id4}');";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (command = new SqlCommand(sqlExpression, connection))
                {
                    connection.Open();
                    SqlParameter nameParam = new SqlParameter("@user_id", id);
                    SqlParameter nameParam2 = new SqlParameter("@user_post_id", id2);
                    SqlParameter nameParam3 = new SqlParameter("@user_login", id3);
                    SqlParameter nameParam4 = new SqlParameter("@user_password", id4);
                    command.Parameters.Add(nameParam);
                    command.Parameters.Add(nameParam2);
                    command.Parameters.Add(nameParam3);
                    command.Parameters.Add(nameParam4);
                    command.ExecuteReader();
                    connection.Close();
                }
            }
        }

        public void add_post(int id, string id2, int id3)
        {
            string sqlExpression =
                $"INSERT INTO post (post_id, post_name, superior_post_id) VALUES({id}, '{id2}', {id3});";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (command = new SqlCommand(sqlExpression, connection))
                {
                    connection.Open();
                    SqlParameter nameParam = new SqlParameter("@post_id", id);
                    SqlParameter nameParam2 = new SqlParameter("@post_name", id2);
                    SqlParameter nameParam3 = new SqlParameter("@superior_post_id", id3);
                    command.Parameters.Add(nameParam);
                    command.Parameters.Add(nameParam2);
                    command.Parameters.Add(nameParam3);
                    command.ExecuteReader();
                    connection.Close();
                }
            }
            
        }

        public void add_plant(int id, string id2, int id3)
        {
            string sqlExpression =
                $"INSERT INTO plants (id_plant, plant_name, plant_type_id) VALUES({id}, '{id2}', {id3});";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (command = new SqlCommand(sqlExpression, connection))
                {
                    connection.Open();
                    SqlParameter nameParam = new SqlParameter("@id_plan", id);
                    SqlParameter nameParam2 = new SqlParameter("@plant_name", id2);
                    SqlParameter nameParam3 = new SqlParameter("@plant_type_id", id3);
                    command.Parameters.Add(nameParam);
                    command.Parameters.Add(nameParam2);
                    command.Parameters.Add(nameParam3);
                    command.ExecuteReader();
                    connection.Close();
                }
            }
        }

        public void add_plant_status(int id, string id2)
        {
            string sqlExpression =
                $"INSERT INTO plants_types (id_plant_type, plant_type_name) VALUES({id}, '{id2}');";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (command = new SqlCommand(sqlExpression, connection))
                {
                    connection.Open();
                    SqlParameter nameParam = new SqlParameter("@id_plant_type", id);
                    SqlParameter nameParam2 = new SqlParameter("@plant_type_name", id);
                    command.Parameters.Add(nameParam);
                    command.Parameters.Add(nameParam2);
                    command.ExecuteReader();
                    connection.Close();
                }
            }
        }

        public void add_chemical(int id, string id2, int id3)
        {
            string sqlExpression =
                $"INSERT INTO chemicals (id_chemical, chemical_name, chemical_type_id) VALUES({id}, '{id2}', {id3});";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (command = new SqlCommand(sqlExpression, connection))
                {
                    connection.Open();
                    SqlParameter nameParam = new SqlParameter("@id_chemical", id);
                    SqlParameter nameParam2 = new SqlParameter("@chemical_name", id2);
                    SqlParameter nameParam3 = new SqlParameter("@chemical_type_id", id3);
                    command.Parameters.Add(nameParam);
                    command.Parameters.Add(nameParam2);
                    command.Parameters.Add(nameParam3);
                    command.ExecuteReader();
                    connection.Close();
                }
            }
        }

        public void add_chemical_type(int id, string id2)
        {
            string sqlExpression =
                $"INSERT INTO chemicals_type (chemical_type_id, chemical_type_name) VALUES({id}, '{id2}');";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (command = new SqlCommand(sqlExpression, connection))
                {
                    connection.Open();
                    SqlParameter nameParam = new SqlParameter("@chemical_type_id", id);
                    SqlParameter nameParam2 = new SqlParameter("@chemical_type_name", id2);
                    command.Parameters.Add(nameParam);
                    command.Parameters.Add(nameParam2);
                    command.ExecuteReader();
                    connection.Close();
                }
            }
        }

        public void add_agricultural_machinery(int id,string id2, int id3)
        {
            string sqlExpression =
                $"INSERT INTO agricultural_machinery (id_agricultural_machinery, agricultural_machinery_name, agricultural_machinery_type_id) VALUES({id}, '{id2}', {id3});";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (command = new SqlCommand(sqlExpression, connection))
                {
                    connection.Open();
                    SqlParameter nameParam = new SqlParameter("@id_agricultural_machinery", id);
                    SqlParameter nameParam2 = new SqlParameter("@agricultural_machinery_name", id2);
                    SqlParameter nameParam3 = new SqlParameter("@agricultural_machinery_type_id", id3);
                    command.Parameters.Add(nameParam);
                    command.Parameters.Add(nameParam2);
                    command.Parameters.Add(nameParam3);
                    command.ExecuteReader();
                    connection.Close();
                }
            }
        }
        
        public void add_agricultural_machinery_type(int id, string id2)
        {
            string sqlExpression =
                $"INSERT INTO agricultural_machinery_types (id_agricultural_machinery_type, agricultural_machinery_type_name) VALUES({id}, '{id2}');";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (command = new SqlCommand(sqlExpression, connection))
                {
                    connection.Open();
                    SqlParameter nameParam = new SqlParameter("@task_id", id);
                    SqlParameter nameParam2 = new SqlParameter("@task_execution_id", id2);
                    command.Parameters.Add(nameParam);
                    command.Parameters.Add(nameParam2);
                    command.ExecuteReader();
                    connection.Close();
                }
            }
        }
    }
}