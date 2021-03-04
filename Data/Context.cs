﻿using backend_database_HTTP_Requests.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_database_HTTP_Requests.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Student_description> Students_Description { get; set; }
    }
}
