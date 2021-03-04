using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_database_HTTP_Requests.DTO
{
    public class StudentDTO
    {
        public int studentId { get; set; }
        public int age { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string adress { get; set; }
        public string country { get; set; }
        public string grade { get; set; }
    }
}
