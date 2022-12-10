using System;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace The_end_of_Gydropon.DBApi
{
    public static class Taking
    {
        /// <summary>
        /// Выполняет процедуру на сервере
        /// </summary>
        /// <param name="ProcedureName">Название процедуры на сервере</param>
        /// <returns>Данные в JSON</returns>
        public static string RunProcedure(string ProcedureName)
        {
            try
            {
                using (SqlConnection connection = 
                       new SqlConnection(Main.CreateConnectionString("Sharp228", "!rrave1in##")))
                {
                    connection.OpenAsync();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = ProcedureName;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = connection;
                    connection.Close();
                    return JsonConvert.SerializeObject(cmd.ExecuteReader());
                }
            }
            catch (Exception error)
            {
                ErrorMessages.BaseErrors.WriteLogMessage(error.Message);
            }
            
            return "Error, view log file";
        }
    }
}