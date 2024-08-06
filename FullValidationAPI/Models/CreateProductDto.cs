using System.ComponentModel.DataAnnotations;

namespace FullValidationAPI.Models
{
    public class CreateProductDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(0.01, 10000.00)]
        public decimal Price { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        [Required]
        [EmailAddress]
        public string SupplierEmail { get; set; }
    }
}
