using ExtensionMethodValidation.Models;

namespace ExtensionMethodValidation.Extensions
{
    public static class ProductExtension
    {
        public static IEnumerable<string> Validate(this CreateProductDto productDto)
        {
            if (string.IsNullOrWhiteSpace(productDto.Name))
            {
                yield return "Name is required";
            }

            if (productDto.Name.Length > 100)
            {
                yield return "Name length can't be more than 100";
            }

            if (productDto.Price < 0.01m || productDto.Price > 1000.00m)
            {
                yield return "Price must be between 0.01 and 1000.00";
            }
        }
    }
}
