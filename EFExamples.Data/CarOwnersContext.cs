using EFExamples.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EFExamples.Data
{
    public class CarOwnersContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=CarOwners;User Id=hacker;Password=hacker;");
        }
    }
}
