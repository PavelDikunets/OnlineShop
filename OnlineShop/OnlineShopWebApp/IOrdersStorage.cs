using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public interface IOrdersStorage
    {
        void Add(Order order);
    }
}