using MediatR;
using Meicrosoft.Billing.Application.Commands.Order;
using Microsoft.Extensions.DependencyInjection;

namespace Meicrosoft.Billing.Infra.CrossCutting.IoC
{
    public static class MediatorInjection
    {
        public static void AddMediatorInjection(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateOrderCommand));
        }
    }
}
