using MediatR;
using Meicrosoft.Billing.Application.Contracts;
using Meicrosoft.Billing.Domain.OrdersAggregate;

namespace Meicrosoft.Billing.Application.Commands.Order
{
    public class CreateOrderHandler(IOrderRepository orderRepository) : IRequestHandler<CreateOrderCommand, ResponseContract>
    {
        public async Task<ResponseContract> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var response = new ResponseContract();

            try
            {
                var order = request.Order;
                order.Tax.CalculateValue();

                await orderRepository.CreateAsync(order);

                response.SetResponse(order, true);

                return response;
            }
            catch (Exception ex)
            {
                //TODO logs
                response.SetResponse(null, false);
                
                return response;
            }
        }
    }
}
