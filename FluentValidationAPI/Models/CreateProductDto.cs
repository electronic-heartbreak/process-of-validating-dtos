using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace FluentValidationAPI.Models
{
    public class CreateProductDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [MaxLength(250)]
        [AllowNull]
        public string Description { get; set; }

        [Required]
        public string SupplierEmail { get; set; }
    }
}
