using Meicrosoft.Billing.Domain.OrdersAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meicrosoft.Billing.Infra.Mapping
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder
                .HasOne(o => o.Address)
                .WithOne(a => a.Order)
                .HasForeignKey<Address>(a => a.OrderId);

            builder
                .HasOne(o => o.Tax)
                .WithOne(t => t.Order)
                .HasForeignKey<Tax>(a => a.OrderId);
        }
    }
}
