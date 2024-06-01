namespace Meicrosoft.Billing.Application.DTOs
{
    public class CreateOrderDto
    {
        public CreateAddressDto Address { get; set; }
        public CreateTaxDto Tax { get; set; }
    }
}
