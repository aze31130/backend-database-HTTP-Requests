using System.ComponentModel.DataAnnotations;

namespace backend_database_HTTP_Requests.Models
{
    public class AddStudent
    {
        [Required]
        public string grade { get; set; }
        [Required]
        public int studentId { get; set; }
        [Required]
        public int age { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public string adress { get; set; }
        [Required]
        public string country { get; set; }
    }
}
