using System.ComponentModel.DataAnnotations;

namespace backend_database_HTTP_Requests.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
    }
}
