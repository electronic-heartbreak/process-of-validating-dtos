using System.ComponentModel.DataAnnotations;

namespace FullValidationAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string SupplierEmail { get; set; }

        public int InternalCode { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDiscontinued { get; set; }

    }
}
