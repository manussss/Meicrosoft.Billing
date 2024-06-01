using AutoMapper;
using MediatR;
using Meicrosoft.Billing.Application.Commands.Order;
using Meicrosoft.Billing.Application.DTOs;
using Meicrosoft.Billing.Domain.OrdersAggregate;
using Microsoft.AspNetCore.Mvc;

namespace Meicrosoft.Billing.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController(IMediator mediator, IMapper mapper) : ControllerBase
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
        public async Task<IActionResult> CreateAsync(CreateOrderDto dto)
        {
            var result = await mediator.Send(new CreateOrderCommand(mapper.Map<Order>(dto)));

            return result.Success ? Created(nameof(CreateAsync), result) : BadRequest(result);
        }
    }
}
