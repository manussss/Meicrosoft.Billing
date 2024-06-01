using Meicrosoft.Billing.Domain.OrdersAggregate;
using Microsoft.EntityFrameworkCore;

namespace Meicrosoft.Billing.Infra.Data
{
    public class OrderContext(DbContextOptions<OrderContext> options) : DbContext(options)
    {
        public DbSet<Order> Order { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Tax> Tax { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(OrderContext).Assembly);

            base.OnModelCreating(builder);
        }
    }
}
