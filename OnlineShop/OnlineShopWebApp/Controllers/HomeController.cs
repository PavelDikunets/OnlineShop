using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

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
        public class Product
        {
            private int Id { get; set; }
            private string Name { get; set; }
            private decimal Cost { get; set; }
            private string Description { get; set; }
            public Product(int id, string name, decimal cost, string description)
            {
                Id = id;
                Name = name;
                Cost = cost;
                Description = description;
            }
            public string Print()
            {
                return $"{Id}\n{Name}\n{Cost}\n";
            }
        }
        public string Index()
        {
            Store store1 = new Store();
            return $"{store1.ShowCatalog()}";
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
