using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Db
{
    public interface IProductsStorage
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> TryGetByIdAsync(Guid id);
        Task RemoveAsync(Guid id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product editedProduct);
        Task<List<Product>> SearchAsync(string searchRequest);
    }
}