using Meicrosoft.Billing.Application.DTOs;
using Meicrosoft.Billing.Domain.OrdersAggregate.Enums;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Meicrosoft.Billing.IntegrationTests.Controllers
{
    [Collection("Database")]
    public class OrderControllerTests(OrderApiApplicationFactory factory) : IClassFixture<OrderApiApplicationFactory>
    {
        [Fact]
        public async Task CreateOrder_ShouldReturn_BadRequest()
        {
            //Arrange
            var client = factory.CreateClient();
            var request = JsonSerializer.Serialize(new CreateOrderDto());

            //Act
            var response = await client.PostAsync("order", new StringContent(request, Encoding.UTF8, "application/json"));

            //Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task CreateOrder_ShouldReturn_Created()
        {
            //Arrange
            var client = factory.CreateClient();
            var order = new CreateOrderDto()
            {
                Address = new CreateAddressDto
                {
                    City = "",
                    Country = "",
                    Number = "",
                    State = "",
                    Street = "",
                    ZipCode = ""
                },
                Tax = new CreateTaxDto
                {
                    Type = EType.National,
                    Value = 100
                }
            };
            var request = JsonSerializer.Serialize(order);

            //Act
            var response = await client.PostAsync("order", new StringContent(request, Encoding.UTF8, "application/json"));

            //Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
    }
}
