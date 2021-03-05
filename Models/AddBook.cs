using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend_database_HTTP_Requests.DTO
{
    public class AddBook
    {
        [Required]
        public decimal Book_price { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Book_name { get; set; }
        [Required]
        public string Book_description { get; set; }
    }
}