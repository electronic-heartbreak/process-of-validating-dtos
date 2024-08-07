using FluentValidation;
using FluentValidationAPI.Models;

namespace FluentValidationAPI.Validation
{
    public class ProductValidator : AbstractValidator<Product> 
    {
        public ProductValidator()
        {
            RuleFor(product => product.Name).NotNull().MaximumLength(100);
            RuleFor(product => product.Price).NotNull().InclusiveBetween(0.01m, 10000.00m);
            RuleFor(product => product.Description)
                .MaximumLength(250)
                .When(product => !string.IsNullOrEmpty(product.Description));
            RuleFor(product => product.SupplierEmail).NotNull().EmailAddress();
        }
    }
}
