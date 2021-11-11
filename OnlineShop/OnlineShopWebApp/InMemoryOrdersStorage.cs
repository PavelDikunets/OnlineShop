using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public Order TryGetByOrderId(Guid id)
        {
            return orders.FirstOrDefault(order => order.Id == id);
        }
    }
}