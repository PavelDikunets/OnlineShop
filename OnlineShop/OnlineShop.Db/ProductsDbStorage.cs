﻿using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Db
{
    public class ProductsDbStorage : IProductsStorage
    {
        private readonly DatabaseContext databaseContext;

        public ProductsDbStorage(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<List<Product>> GetAllAsync()
        {
            return await databaseContext.Products.ToListAsync();
        }
        public async Task<Product> TryGetByIdAsync(Guid id)
        {
            return await databaseContext.Products.FirstOrDefaultAsync(product => product.Id == id);
        }
        public async Task RemoveAsync(Guid id)
        {
            var product = await TryGetByIdAsync(id);
            databaseContext.Products.Remove(product);
            await databaseContext.SaveChangesAsync();
        }
        public async Task AddAsync(Product product)
        {
            await databaseContext.Products.AddAsync(product);
            await databaseContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Product editedProduct)
        {
            var product = await TryGetByIdAsync(editedProduct.Id);
            databaseContext.Products.Remove(product);
            await databaseContext.Products.AddAsync(editedProduct);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<List<Product>> SearchAsync(string searchRequest)
        {
            var searchResult = new List<Product>();
            if (!string.IsNullOrEmpty(searchRequest))
            {
                searchResult = await databaseContext.Products.Where(x => x.Name.ToLower().Contains(searchRequest.ToLower())).ToListAsync();
            }
            return searchResult;
        }
    }
}