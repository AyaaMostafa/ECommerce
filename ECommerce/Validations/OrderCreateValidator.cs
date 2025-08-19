using ECommerce.DTOs;
using FluentValidation;

namespace ECommerce.Validations
{
    public class OrderCreateValidator : AbstractValidator<OrderCreateDto>
    {
        public OrderCreateValidator()
        {
            RuleFor(x => x.CustomerId).GreaterThan(0).WithMessage("CustomerId is required and must be greater than 0");
            RuleFor(x => x.ProductIds).NotEmpty().WithMessage("Order must contain at least one product");
        }
    
}
}
