using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject;

namespace TestProject
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}

public class DbContextFactory
{
    public static ApplicationDbContext Create()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        var context = new ApplicationDbContext(options);

        // Seed the database
        context.Users.AddRange(TestDataGenerator.GenerateUsers(100));
        context.SaveChanges();

        return context;
    }
}
