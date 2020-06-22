using EFExamples.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DbMigrator
{
    public class CarOwnersContextFactory : IDesignTimeDbContextFactory<CarOwnersContext>
    {
        public CarOwnersContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CarOwnersContext>();
            optionsBuilder.UseSqlServer(@"Server = localhost; Database = CarOwners; User Id = hacker; Password = hacker;");
            return new CarOwnersContext(optionsBuilder.Options);
        }
    }
}
