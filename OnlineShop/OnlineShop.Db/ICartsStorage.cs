using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public interface ICartsStorage
    {
        void Add(Product product, string userId);
        void DecreaseAmount(Product product, string userId);
        void Clear(string userId);
        Cart TryGetByUserId(string userId);
    }
}