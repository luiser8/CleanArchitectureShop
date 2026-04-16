using System.ComponentModel.DataAnnotations;

namespace ShopProducts.WebAPI.DTos
{
    public class CreateProductDto
    {
        [Required]
        [MaxLength(200)]
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public int InventoryInitial { get; set; }

    }
}
