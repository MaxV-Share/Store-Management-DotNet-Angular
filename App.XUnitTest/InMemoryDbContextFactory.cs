using App.Models;
using App.Models.Dbcontexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace App.XUnitTest
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
