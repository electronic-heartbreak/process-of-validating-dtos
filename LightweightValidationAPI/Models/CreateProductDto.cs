using System.ComponentModel.DataAnnotations;

namespace LightWeightValidationAPI.Models
{
    public class CreateProductDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        [Required]
        public string SupplierEmail { get; set; }
    }
}
