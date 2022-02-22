using Microsoft.EntityFrameworkCore;
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
        public async void Remove(Guid id)
        {
            var product = await TryGetByIdAsync(id);
            databaseContext.Products.Remove(product);
            databaseContext.SaveChanges();
        }
        public void Add(Product product)
        {
            databaseContext.Products.Add(product);
            databaseContext.SaveChanges();
        }
        public async void Update(Product editedProduct)
        {
            var product = await TryGetByIdAsync(editedProduct.Id);
            databaseContext.Products.Remove(product);
            databaseContext.Products.Add(editedProduct);
            databaseContext.SaveChanges();
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