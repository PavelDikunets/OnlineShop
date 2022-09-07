using System;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace OnlineShop.Services.ProductAPI.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1,999999)]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImgUrl { get; set; }
    }
}
