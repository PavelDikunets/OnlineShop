using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class CompareDbStorage : ICompareStorage
    {
        private readonly DatabaseContext databaseContext;

        public CompareDbStorage(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public List<Product> GetAll(string userId)
        {
            return databaseContext.CompareProducts.Where(u => u.UserId == userId)
                                                  .Include(x => x.Product)
                                                  .Select(x => x.Product)
                                                  .ToList();
        }
        public void Add(string userId, Product product)
        {
            var currentProduct = databaseContext.CompareProducts.FirstOrDefault(x => x.UserId == userId && x.Product == product);
            if (currentProduct == null)
            {
                databaseContext.CompareProducts.Add(new CompareProduct { Product = product, UserId = userId });
                databaseContext.SaveChanges();
            }
        }
        public void Remove(string userId, Guid productId)
        {
            var currentProduct = databaseContext.CompareProducts.FirstOrDefault(x => x.UserId == userId && x.Product.Id == productId);
            databaseContext.CompareProducts.Remove(currentProduct);
            databaseContext.SaveChanges();
        }
        public void Clear(string userId)
        {
            var userFavoriteProducts = databaseContext.CompareProducts.Where(x => x.UserId == userId).ToList();
            databaseContext.CompareProducts.RemoveRange(userFavoriteProducts);
            databaseContext.SaveChanges();
        }

    }
}
