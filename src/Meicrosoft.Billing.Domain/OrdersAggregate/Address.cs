using Meicrosoft.Billing.Domain.Entities;

namespace Meicrosoft.Billing.Domain.OrdersAggregate
{
    public class Address : Entity
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public string Number { get; private set; }
        public string Country { get; private set; }
        public Guid OrderId { get; private set; }
        public Order? Order { get; private set; }
    }
}
