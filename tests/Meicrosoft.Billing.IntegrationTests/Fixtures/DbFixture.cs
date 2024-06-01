using Meicrosoft.Billing.Infra.Data;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Meicrosoft.Billing.IntegrationTests.Fixtures
{
    public class DbFixture : IDisposable
    {
        private readonly OrderContext _dbContext;
        public readonly string DatabaseName = $"MeicrosoftBilling-{Guid.NewGuid()}";
        public readonly string ConnectionString;

        private bool _disposed;

        public DbFixture()
        {
            ConnectionString = $"Server=[::1];Database={DatabaseName};User=sa;Password=the_Real@riginal01;TrustServerCertificate=True";

            var builder = new DbContextOptionsBuilder<OrderContext>();

            builder.UseSqlServer(ConnectionString);

            _dbContext = new OrderContext(builder.Options);

            _dbContext.Database.Migrate();
            _dbContext.GetInfrastructure().GetRequiredService<IMigrator>().Migrate(Migration.InitialDatabase);
            _dbContext.Database.Migrate();
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Database.EnsureDeleted();
                }

                _disposed = true;
            }
        }
    }

    [CollectionDefinition("Database")]
    public class DatabaseCollection : ICollectionFixture<DbFixture>
    {

    }
}
