using MediatR;
using Meicrosoft.Billing.Application.Contracts;

namespace Meicrosoft.Billing.Application.Commands.Order
{
    public class CreateOrderCommand(Domain.OrdersAggregate.Order order) : IRequest<ResponseContract>
    {
        public Domain.OrdersAggregate.Order Order { get; set; } = order;
    }
}
