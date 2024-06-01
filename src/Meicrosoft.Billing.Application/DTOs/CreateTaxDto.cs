using Meicrosoft.Billing.Domain.OrdersAggregate.Enums;

namespace Meicrosoft.Billing.Application.DTOs
{
    public class CreateTaxDto
    {
        public EType Type { get; set; }
        public decimal Value { get; set; }
    }
}
