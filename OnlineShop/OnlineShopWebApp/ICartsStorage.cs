using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface ICartsStorage
    {
        void Add(Product product, string userId);
        void Remove(Product product, string userId);
        void Clear(Product product, string userId);
        Cart TryGetByUserId(string userId);
    }
}