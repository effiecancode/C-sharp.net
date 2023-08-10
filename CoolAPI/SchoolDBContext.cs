using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
//  This code defines a way to interact with a database using Entity Framework Core 

namespace WebAPI_Test
{
    //A class named SchoolDBContext that inherits from DBContext provided by Entity Framework Core
    public class SchoolDBContext : DbContext
    {
        //Constructor that accepts options for configuring the database context
        public SchoolDBContext(DbContextOptions<SchoolDBContext> options) :
        base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        // This property defines a DbSet named "Students" which represents a table in the database.
        // It allows you to perform database operations (like querying and saving) on the Student entity.
    }
}
