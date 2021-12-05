using Microsoft.EntityFrameworkCore;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class OrdersDbStorage : IOrdersStorage
    {
        private readonly DatabaseContext databaseContext;

        public OrdersDbStorage(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(Order order)
        {
            databaseContext.Orders.Add(order);
            databaseContext.SaveChanges();
        }
        public List<Order> GetAll()
        {
            return databaseContext.Orders.Include(x => x.UserDeliveryInfo)
                                         .Include(x => x.Items)
                                         .ThenInclude(x => x.Product).ToList();
        }
        public Order TryGetById(Guid id)
        {
            return databaseContext.Orders.Include(x => x.UserDeliveryInfo)
                                         .Include(x => x.Items)
                                         .ThenInclude(x => x.Product).FirstOrDefault(x => x.Id == id);

        }
        public void UpdateStatus(Guid orderId, OrderStatus status)
        {
            var order = TryGetById(orderId);
            order.Status = status;
            databaseContext.SaveChanges();
        }
    }
}