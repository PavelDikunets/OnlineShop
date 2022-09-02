using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Services.ProductAPI.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1, 999999)]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string ImagePath { get; set; }
    }
}
