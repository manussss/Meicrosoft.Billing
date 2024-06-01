namespace Meicrosoft.Billing.Domain.OrdersAggregate
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(Guid id);
        Task CreateAsync(Order order);
    }
}
