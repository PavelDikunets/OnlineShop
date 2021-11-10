using OnlineShopWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class InMemoryProductsStorage : IProductsStorage
    {
        private List<Product> products = new List<Product>()
        {
            new Product
            {
                Name = "Ноутбук Xiaomi Mi Notebook Air 13.3\"",
                Cost = 79900,
                Description = "\nПроцессор и память:\nПроцессор: Intel i5-8250U\nКоличество ядер: Quad-Core\nЧастота: 3.4 ГГц\nОперативная память: 8 Гб\nВидеокарта: GeForce MX150 VRAM GDDR5 объемом 2 ГБ\n\nДисплей:\nДиагональ экрана: 13.3\nРазрешение дисплея: 1920 x 1080\n\nВнешний вид:\nШирина (мм): 210,9\nТолщина (мм): 14,8\nДлина (мм): 309,6\nВес (г): 1300"
            },
            new Product
            {
                Name = "Ноутбук ASUS ExpertBook B5 13.3\"",
                Cost = 81990,
                Description = "\nПроцессор и память:\nПроцессор: Intel I5-1135G7\nКоличество ядер: Quad-Core\nЧастота: 2.4 ГГц\nОперативная память: 8 Гб\nВидеокарта: Intel Iris Xe Graphics\n\nДисплей:\nДиагональ экрана: 13.3\nРазрешение дисплея: 1920 x 1080\n\nВнешний вид:\nШирина (мм): 210,6\nТолщина (мм): 16,9\nДлина (мм): 309,9\nВес (г): 1200"
            },
            new Product
            {
                Name = "Ноутбук DELL Vostro 3500, 15.6\"",
                Cost = 35990,
                Description = "\nПроцессор и память:\nПроцессор: Intel Core i3 1115G4\nКоличество ядер процессора: Dual-Core\nЧастота: 3.0ГГц\nОперативная память: 8 Гб\nВидеокарта: Intel UHD Graphics\n\nДисплей:\nДиагональ экрана: 15.6\nРазрешение дисплея: 1920 x 1080\n\nВнешний вид:\nШирина (мм): 363.96\nТолщина (мм): 19\nДлина (мм): 249\nВес (г): 1780"
            },
        };
        public List<Product> GetAll()
        {
            return products;
        }
        public Product TryGetById(int id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }
        public void Remove(int id)
        {
            var product = TryGetById(id);
            products.Remove(product);
        }
        public void Add(Product product)
        {
            products.Add(product);
        }
        public void Update(Product editedProduct)
        {
            var product = TryGetById(editedProduct.Id);
            products.Remove(product);
            products.Add(editedProduct);
        }
    }
}