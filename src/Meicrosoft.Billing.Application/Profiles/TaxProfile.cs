using AutoMapper;
using Meicrosoft.Billing.Application.DTOs;
using Meicrosoft.Billing.Domain.OrdersAggregate;

namespace Meicrosoft.Billing.Application.Profiles
{
    public class TaxProfile : Profile
    {
        public TaxProfile()
        {
            CreateMap<CreateTaxDto, Tax>();
        }
    }
}
