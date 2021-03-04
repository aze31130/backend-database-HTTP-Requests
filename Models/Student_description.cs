using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend_database_HTTP_Requests.Models
{
    public class Student_description
    {
        [Key]
        public int id { get; set; }
        public int studentId { get; set; }
        public int age { get; set; }
        public string  firstName { get; set; }
        public string lastName { get; set; }
        public string adress { get; set; }
        public string country { get; set; }

    }
}
