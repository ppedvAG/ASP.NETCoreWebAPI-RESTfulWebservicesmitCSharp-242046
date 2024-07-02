using BusinessLogic;
using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;

namespace M010_UnitTests
{
    // https://learn.microsoft.com/de-de/ef/core/testing/testing-with-the-database
    public class TestDatabase
    {
        private const string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=EFTestSample;Trusted_Connection=True;ConnectRetryCount=0";

        private static readonly object _lock = new();

        public TestDatabase()
        {
            lock (_lock)
            {
                using (var context = CreateContext())
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();

                    context.AddRange(
                        new Vehicle { ModelName = "abc" },
                        new Vehicle { ModelName = "345" }
                    );
                    context.SaveChanges();
                }
            }
        }

        public WebApiDbContext CreateContext()
        {
            var builder = new DbContextOptionsBuilder<WebApiDbContext>().UseSqlServer(ConnectionString);
            return new WebApiDbContext(builder.Options);
        }
    }
}