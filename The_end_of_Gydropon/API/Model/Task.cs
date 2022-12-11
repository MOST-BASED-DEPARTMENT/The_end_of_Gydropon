using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace The_end_of_Gydropon.API.Model
{
    [DataContract]
    public class Tasks
    {
        [DataMember(Name = "ID")]
        public int ID { get; set; }

        [DataMember(Name = "User Id")]
        public string User { get; set; }
        
        [DataMember(Name = "Description")]
        public string Description { get; set; }

        [DataMember(Name = "Field ID")]
        public string Field { get; set; }

        [DataMember(Name = "Type ID")]
        public string Type { get; set; }

        [DataMember(Name = "Status ID")]
        public string Status { get; set; }
        
        [DataMember(Name = "Date")]
        [DataType(DataType.Date)]
        public string Date { get; set; }
        
        [DataMember(Name = "Starting Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime StartTime { get; set; }
        
        [DataMember(Name = "Finishing Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public string FinishTime { get; set; }
        
        [DataMember(Name = "WeatherInformation")]
        public string Weather { get; set;}
    }
}