using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class ProductsDbStorage : IProductsStorage
    {
        private readonly DatabaseContext databaseContext;

        public ProductsDbStorage(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public List<Product> GetAll()
        {
            return databaseContext.Products.ToList();
        }
        public Product TryGetById(Guid id)
        {
            return databaseContext.Products.FirstOrDefault(product => product.Id == id);
        }
        public void Remove(Guid id)
        {
            var product = TryGetById(id);
            databaseContext.Products.Remove(product);
            databaseContext.SaveChanges();
        }
        public void Add(Product product)
        {
            databaseContext.Products.Add(product);
            databaseContext.SaveChanges();
        }
        public void Update(Product editedProduct)
        {
            var product = TryGetById(editedProduct.Id);
            databaseContext.Products.Remove(product);
            databaseContext.Products.Add(editedProduct);
            databaseContext.SaveChanges();
        }
    }
}