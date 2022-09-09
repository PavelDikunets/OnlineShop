using OnlineShop.WebApp.Models;
using System;
using System.Threading.Tasks;

namespace OnlineShop.WebApp.Services.IServices
{
    public interface IProductService
    {
        Task<T> GetAllProductsAsync<T>();
        Task<T> GetProductbyIdAsync<T>(Guid id);
        Task<T> CreateProductAsync<T>(ProductDto productDto);
        Task<T> UpdateProductAsync<T>(ProductDto productDto);
        Task<T> DeleteProductAsync<T>(Guid id);
    }
}
