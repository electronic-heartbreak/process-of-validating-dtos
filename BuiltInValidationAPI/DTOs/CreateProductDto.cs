using System.ComponentModel.DataAnnotations;

namespace BuiltInValidationAPI.DTOs
{
    public class CreateProductDto : IValidatableObject
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string SupplierEmail { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                yield return new ValidationResult("Name is required", new[] { nameof(Name) });
            }

            if (Name.Length > 100)
            {
                yield return new ValidationResult("Name must be longer than 100 characters", new[] { nameof(Name) });
            }

            if (Price < 0.01m || Price > 1000.00m)
            {
                yield return new ValidationResult("Price must be between 0,01 and 1000,00", new[] { nameof(Price) });
            }
        }
    }
}
