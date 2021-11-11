using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IOrdersStorage
    {
        void Add(Order order);
        List<Order> GetAll();
    }
}