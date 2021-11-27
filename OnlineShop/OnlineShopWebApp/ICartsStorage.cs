using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface ICartsStorage
    {
        void Add(ProductViewModel product, string userId);
        void DecreaseAmount(ProductViewModel product, string userId);
        void Clear(string userId);
        Cart TryGetByUserId(string userId);
    }
}