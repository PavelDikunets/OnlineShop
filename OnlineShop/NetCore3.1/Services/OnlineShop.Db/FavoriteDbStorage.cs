using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Db
{
    public class FavoriteDbStorage : IFavoriteStorage
    {
        private readonly DatabaseContext databaseContext;

        public FavoriteDbStorage(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<List<Product>> GetAllAsync(string userId)
        {
            return await databaseContext.FavoriteProducts.Where(u => u.UserId == userId)
                                                   .Include(x => x.Product)
                                                   .Select(x => x.Product)
                                                   .ToListAsync();
        }
        public async Task AddAsync(string userId, Product product)
        {
            var currentProduct = await databaseContext.FavoriteProducts.FirstOrDefaultAsync(x => x.UserId == userId && x.Product == product);
            if (currentProduct == null)
            {
                await databaseContext.FavoriteProducts.AddAsync(new FavoriteProduct { Product = product, UserId = userId });
                await databaseContext.SaveChangesAsync();
            }
        }
        public async Task RemoveAsync(string userId, Guid productId)
        {
            var currentProduct = await databaseContext.FavoriteProducts.FirstOrDefaultAsync(x => x.UserId == userId && x.Product.Id == productId);
            databaseContext.FavoriteProducts.Remove(currentProduct);
            await databaseContext.SaveChangesAsync();
        }
        public async Task ClearAsync(string userId)
        {
            var userFavoriteProducts = await databaseContext.FavoriteProducts.Where(x => x.UserId == userId).ToListAsync();
            databaseContext.FavoriteProducts.RemoveRange(userFavoriteProducts);
            await databaseContext.SaveChangesAsync();
        }

    }
}
