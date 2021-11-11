using OnlineShopWebApp.Models;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public class InMemoryOrdersStorage : IOrdersStorage
    {
        private List<Order> orders = new List<Order>();

        public void Add(Order order)
        {
            orders.Add(order);
        }
        public List<Order> GetAll()
        {
            return orders;
        }
    }
}