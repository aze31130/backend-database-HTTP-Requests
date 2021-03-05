using System.ComponentModel.DataAnnotations;

namespace backend_database_HTTP_Requests.Models
{
    public class Values
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}