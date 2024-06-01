using AutoMapper;
using Meicrosoft.Billing.Application.DTOs;
using Meicrosoft.Billing.Domain.OrdersAggregate;

namespace Meicrosoft.Billing.Application.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CreateOrderDto, Order>();
        }
    }
}
