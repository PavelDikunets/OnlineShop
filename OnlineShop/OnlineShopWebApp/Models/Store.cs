using System.Collections.Generic;

namespace OnlineShopWebApp.Controllers
{
    public partial class HomeController
    {
        public class Store
        {
            public List<Product> Products;
            public Store()
            {
                Products = new List<Product>
                {
                    new Product(1, "Ноутбук Xiaomi", 74900, "Процессор Intel"),
                    new Product(2, "Ноутбук Asus", 65500, "Процессор Intel"),
                    new Product(3, "Ноутбук Dell", 49300, "Процессор Amd"),
                };
                
            }
            public string ShowCatalog()
            {
                string result = "";
                foreach (Product product in Products)
                {
                    result += product.Print() + "\n";
                }
                return result;
            }

        }
    }
}
