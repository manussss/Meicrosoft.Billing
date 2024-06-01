using Meicrosoft.Billing.Domain.OrdersAggregate;
using Meicrosoft.Billing.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Meicrosoft.Billing.Infra.Repositories
{
    public class OrderRepository(OrderContext orderContext) : IOrderRepository
    {
        public async Task CreateAsync(Order order)
        {
            await orderContext.AddAsync(order);
            await orderContext.SaveChangesAsync();
        }

        //TODO add paginacao
        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await orderContext.Order.AsNoTracking().ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(Guid id)
        {
            return await orderContext.Order.FindAsync(id);
        }
    }
}
