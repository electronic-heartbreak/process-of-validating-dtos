using BuiltInValidationAPI.DTOs;
using BuiltInValidationAPI.Models;

namespace BuiltInValidationAPI.Extensions
{
    public static class MappingExtensions
    {
        public static Product ToDomain(this CreateProductDto dto)
        {
            return new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Description = dto.Description,
                SupplierEmail = dto.SupplierEmail,
            };
        }
    }
}
