using backend_database_HTTP_Requests.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_database_HTTP_Requests.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Values> Values { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Book_description> Book_Description { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Student_description> Students_Description { get; set; }
    }
}
