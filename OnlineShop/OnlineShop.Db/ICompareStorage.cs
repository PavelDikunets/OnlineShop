using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Db
{
    public interface ICompareStorage
    {
        Task AddAsync(string userId, Product product);
        Task ClearAsync(string userId);
        Task<List<Product>> GetAllAsync(string userId);
        Task RemoveAsync(string userId, Guid productId);
    }
}