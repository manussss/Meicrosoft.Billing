using MediatR;
using Meicrosoft.Billing.Application.Commands.Order;
using Meicrosoft.Billing.Domain.OrdersAggregate;
using Microsoft.AspNetCore.Mvc;

namespace Meicrosoft.Billing.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController(IMediator mediator) : ControllerBase
    {
        //[HttpGet]
        //public async Task<IActionResult> GetAllAsync()
        //{

        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetByIdAsync(Guid id)
        //{

        //}

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Order order)
        {
            var result = await mediator.Send(new CreateOrderCommand(order));

            return result.Success ? Created(nameof(CreateAsync), result) : BadRequest(result);
        }
    }
}
