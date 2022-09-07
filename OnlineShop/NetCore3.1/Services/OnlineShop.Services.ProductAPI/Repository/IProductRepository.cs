using OnlineShop.Services.ProductAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Services.ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProductById(Guid productId);
        Task<ProductDto> CreateUpdateProduct(ProductDto productDto);
        Task<bool> DeleteProduct(Guid productId);
    }
}
