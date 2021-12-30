using Microsoft.EntityFrameworkCore;
using App.Models.DbContexts;

namespace App.Repositories.XUnitTest
{
    public class InMemoryDbContextFactory
    {
        public ApplicationDbContext GetApplicationDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                        .UseInMemoryDatabase(databaseName: "InMemoryApplicationDatabase")
                        .Options;
            var dbContext = new ApplicationDbContext(options, null);

            return dbContext;
        }
    }
}
