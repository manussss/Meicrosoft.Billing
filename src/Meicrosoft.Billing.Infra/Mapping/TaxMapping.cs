using Meicrosoft.Billing.Domain.OrdersAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meicrosoft.Billing.Infra.Mapping
{
    public class TaxMapping : IEntityTypeConfiguration<Tax>
    {
        public void Configure(EntityTypeBuilder<Tax> builder)
        {
            builder.HasKey(t => t.Id);

            builder
                .HasOne(t => t.Order)
                .WithOne(o => o.Tax)
                .HasForeignKey<Tax>(t => t.OrderId);
        }
    }
}
