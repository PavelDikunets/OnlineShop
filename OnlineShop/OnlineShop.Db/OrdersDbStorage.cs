using Microsoft.EntityFrameworkCore;
using OnlineShop.Db;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    public class OrdersDbStorage : IOrdersStorage
    {
        private readonly DatabaseContext databaseContext;

        public OrdersDbStorage(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task AddAsync(Order order)
        {
            await databaseContext.Orders.AddAsync(order);
            databaseContext.SaveChanges();
        }
        public async Task<List<Order>> GetAllAsync()
        {
            return await databaseContext.Orders.Include(x => x.UserDeliveryInfo)
                                         .Include(x => x.Items)
                                         .ThenInclude(x => x.Product).ToListAsync();
        }
        public async Task<Order> TryGetByIdAsync(Guid id)
        {
            return await databaseContext.Orders.Include(x => x.UserDeliveryInfo)
                                         .Include(x => x.Items)
                                         .ThenInclude(x => x.Product).FirstOrDefaultAsync(x => x.Id == id);

        }
        public async Task UpdateStatusAsync(Guid orderId, OrderStatus status)
        {
            var order = await TryGetByIdAsync(orderId);
            order.Status = status;
            databaseContext.SaveChanges();
        }
    }
}