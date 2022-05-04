using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NewApp.ViewModels
{
    [Table("user")]
    public class User
    {
        [Key]
        public string User_ID { get; set; }
        public string User_Name { get; set; }
        public string User_Addr { get; set; } 
    }
}