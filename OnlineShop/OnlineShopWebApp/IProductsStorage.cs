using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IProductsStorage
    {
        List<Product> GetAll();
        Product TryGetById(int id);
        void Edit(int id, string name, decimal cost, string description);
        void Remove(int id);
        void Add(string name, decimal cost, string description);
    }
}