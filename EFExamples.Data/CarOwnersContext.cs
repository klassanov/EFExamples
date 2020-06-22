using EFExamples.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EFExamples.Data
{
    public class CarOwnersContext : DbContext
    {
        public CarOwnersContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Car> Cars { get; set; }


        //Way 1 to make work the migrations, Default project in the package manager console: EFExamples.Data, Startup project: EFExamples
        //Use the default constructor and the OnConfiguring method
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=localhost;Database=CarOwners;User Id=hacker;Password=hacker;");
        //}

        //Way 2 to make work the migrations, Default project in the package manager console: EFExamples.Data, Startup project: DbMigrator

    }
}
