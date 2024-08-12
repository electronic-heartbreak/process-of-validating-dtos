using ExtensionMethodValidation.Models;

namespace ExtensionMethodValidation.Extensions
{
    public static class ProductExtension
    {
        public static IEnumerable<string> Validate(this CreateProductDto productDto)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(productDto.Name))
            {
                errors.Add("Name is required.");
            }

            if (productDto.Name != null && productDto.Name.Length > 100)
            {
                errors.Add("Name length can't be more than 100.");
            }

            if (productDto.Price < 0.01m || productDto.Price > 1000.00m)
            {
                errors.Add("Price must be between 0.01 and 1000.00.");
            }

            return errors;
        }
    }
}
