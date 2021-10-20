using Microsoft.AspNetCore.Mvc;

namespace OnlineShopWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository productRepository;
        public ProductController()
        {
            productRepository = new ProductRepository();
        }
        public string Index(int id)
        {
            var product = productRepository.TryGetById(id);
            if (product == null)
            {
                return $"По текущему Id:{id} товар не найден!";
            }
            return $"{product}\n{product.Description}";
        }
    }
}
