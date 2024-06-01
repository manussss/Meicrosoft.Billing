using Meicrosoft.Billing.Domain.OrdersAggregate;
using Meicrosoft.Billing.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Meicrosoft.Billing.Infra.CrossCutting.IoC
{
    public static class RepositoryInjection
    {
        public static void AddRepositoryInjection(this IServiceCollection services)
        {
            services.AddTransient<IOrderRepository, OrderRepository>();
        }
    }
}
