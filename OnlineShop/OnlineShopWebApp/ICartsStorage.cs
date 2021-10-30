using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface ICartsStorage
    {
        void Add(Product product, string userId);
        void DecreaseAmount(Product product, string userId);
        void Clear(Product product, string userId);
        Cart TryGetByUserId(string userId);
    }
}