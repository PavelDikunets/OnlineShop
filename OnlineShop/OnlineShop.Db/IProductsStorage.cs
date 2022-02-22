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
        void Remove(Guid id);
        void Add(Product product);
        void Update(Product editedProduct);
        Task<List<Product>> SearchAsync(string searchRequest);
    }
}