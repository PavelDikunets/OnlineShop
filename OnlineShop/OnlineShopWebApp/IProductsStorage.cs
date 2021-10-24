using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IProductsStorage
    {
        List<Product> GetAll();
        Product TryGetById(int id);
    }
}