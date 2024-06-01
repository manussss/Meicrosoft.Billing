using Meicrosoft.Billing.Domain.OrdersAggregate;

namespace Meicrosoft.Billing.Application.Contracts
{
    public class ResponseContract
    {
        public Order? Order { get; private set; }
        public bool Success { get; private set; }

        public void SetResponse(Order? order, bool success)
        {
            Order = order;
            Success = success;
        }
    }
}
