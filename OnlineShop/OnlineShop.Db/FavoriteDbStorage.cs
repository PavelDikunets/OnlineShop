using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class FavoriteDbStorage : IFavoriteStorage
    {
        private readonly DatabaseContext databaseContext;

        public FavoriteDbStorage(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public List<Product> GetAll(string userId)
        {
            return databaseContext.FavoriteProducts.Where(u => u.UserId == userId)
                                                   .Include(x => x.Product)
                                                   .Select(x => x.Product)
                                                   .ToList();
        }
        public void Add(string userId, Product product)
        {
            var currentProduct = databaseContext.FavoriteProducts.FirstOrDefault(x => x.UserId == userId && x.Product == product);
            if (currentProduct == null)
            {
                databaseContext.FavoriteProducts.Add(new FavoriteProduct { Product = product, UserId = userId });
                databaseContext.SaveChanges();
            }
        }
        public void Remove(string userId, Guid productId)
        {
            var currentProduct = databaseContext.FavoriteProducts.FirstOrDefault(x => x.UserId == userId && x.Product.Id == productId);
            databaseContext.FavoriteProducts.Remove(currentProduct);
            databaseContext.SaveChanges();
        }
        public void Clear(string userId)
        {
            var userFavoriteProducts = databaseContext.FavoriteProducts.Where(x => x.UserId == userId).ToList();
            databaseContext.FavoriteProducts.RemoveRange(userFavoriteProducts);
            databaseContext.SaveChanges();
        }

    }
}
