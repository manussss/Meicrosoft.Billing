using Meicrosoft.Billing.Domain.Entities;
using Meicrosoft.Billing.Domain.OrdersAggregate.Enums;

namespace Meicrosoft.Billing.Domain.OrdersAggregate
{
    public class Tax : Entity
    {
        public EType Type { get; private set; }
        public decimal Value { get; private set; }
        public Guid OrderId { get; private set; }
        public Order? Order { get; private set; }

        //TODO improve
        public void CalculateValue()
        {
            Value += Type == EType.National ? 100 : 200;
        }
    }
}
