using Meicrosoft.Billing.Domain.OrdersAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meicrosoft.Billing.Infra.Mapping
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(o => o.Id);

            builder
                .HasOne(o => o.Order)
                .WithOne(a => a.Address)
                .HasForeignKey<Address>(a => a.OrderId);
        }
    }
}
