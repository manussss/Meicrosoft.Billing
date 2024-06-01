using Meicrosoft.Billing.Domain.Entities;

namespace Meicrosoft.Billing.Domain.OrdersAggregate
{
    public class Order : Entity
    {
        public Address Address { get; private set; }
        public Tax Tax { get; private set; }
    }
}
