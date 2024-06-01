using Meicrosoft.Billing.Application.Commands.Order;
using Meicrosoft.Billing.Domain.OrdersAggregate;
using Meicrosoft.Billing.Infra.Data;
using Meicrosoft.Billing.Infra.Repositories;
using Meicrosoft.Billing.IntegrationTests.Fixtures;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Meicrosoft.Billing.IntegrationTests
{
    [Collection("Database")]
    public class OrderApiApplicationFactory(DbFixture dbFixture) : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Test");

            builder.ConfigureServices(services =>
            {
                services.AddScoped<IOrderRepository, OrderRepository>();
                services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateOrderCommand).Assembly));
            });

            builder.ConfigureAppConfiguration((context, config) =>
            {
                config.AddInMemoryCollection(new[]
                {
                    new KeyValuePair<string, string>("ConnectionStrings:OrderConnection", dbFixture.ConnectionString)
                });
            });
        }
    }
}
