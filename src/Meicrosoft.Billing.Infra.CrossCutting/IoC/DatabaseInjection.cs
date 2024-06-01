using Meicrosoft.Billing.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Meicrosoft.Billing.Infra.CrossCutting.IoC
{
    public static class DatabaseInjection
    {
        public static void AddDatabaseInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderContext>(options => options.UseSqlServer(configuration.GetConnectionString("OrderConnection")));
        }
    }
}
