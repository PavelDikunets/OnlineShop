using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp
{
    public interface IOrdersStorage
    {
        void Add(Order order);
        List<Order> GetAll();
        Order TryGetByOrderId(Guid id);
    }
}