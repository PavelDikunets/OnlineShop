using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Db
{
    public class CompareDbStorage : ICompareStorage
    {
        private readonly DatabaseContext databaseContext;

        public CompareDbStorage(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<List<Product>> GetAllAsync(string userId)
        {
            return await databaseContext.CompareProducts.Where(u => u.UserId == userId)
                                                  .Include(x => x.Product)
                                                  .Select(x => x.Product)
                                                  .ToListAsync();
        }
        public async Task AddAsync(string userId, Product product)
        {
            var currentProduct = await databaseContext.CompareProducts.FirstOrDefaultAsync(x => x.UserId == userId && x.Product == product);
            if (currentProduct == null)
            {
                await databaseContext.CompareProducts.AddAsync(new CompareProduct { Product = product, UserId = userId });
                await databaseContext.SaveChangesAsync();
            }
        }
        public async Task RemoveAsync(string userId, Guid productId)
        {
            var currentProduct = await databaseContext.CompareProducts.FirstOrDefaultAsync(x => x.UserId == userId && x.Product.Id == productId);
            databaseContext.CompareProducts.Remove(currentProduct);
            await databaseContext.SaveChangesAsync();
        }
        public async Task ClearAsync(string userId)
        {
            var userFavoriteProducts = await databaseContext.CompareProducts.Where(x => x.UserId == userId).ToListAsync();
            databaseContext.CompareProducts.RemoveRange(userFavoriteProducts);
            await databaseContext.SaveChangesAsync();
        }

    }
}
