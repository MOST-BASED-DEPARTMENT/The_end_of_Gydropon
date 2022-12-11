using System.Collections.Generic;

namespace The_end_of_Gydropon.Database
{
    public abstract class Main
    {
        public const string connString = 
            "Data Source = 46.39.232.190; Initial Catalog = test;User Id=TestUser; Password=vag!nA228##;";
        

        public Dictionary<string, string> procedureStuff = new Dictionary<string, string>
        {
            {"add_task", "SELECT * ZAEBIS"},
            {"add_task_status", "SELECT * ZAEBIS"},
            {"add_task_type", "SELECT * ZAEBIS"},
            {"add_field", "SELECT * ZAEBIS"},
            {"add_user", "SELECT * ZAEBIS"},
            {"add_post", "SELECT * ZAEBIS"},
            {"add_plant", "SELECT * ZAEBIS"},
            {"add_plant_status", "SELECT * ZAEBIS"},
            {"add_chemical", "SELECT * ZAEBIS"},
            
            {"add_agricultural_machinery", "SELECT * ZAEBIS"},
            {"add_agricultural_machinery_type", "SELECT * ZAEBIS"}
        };

        
        public string TableName { get; set; }
    }
}