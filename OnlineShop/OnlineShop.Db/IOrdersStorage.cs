using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    public interface IOrdersStorage
    {
        Task AddAsync(Order order);
        Task<List<Order>> GetAllAsync();
        Task<Order> TryGetByIdAsync(Guid id);
        Task UpdateStatusAsync(Guid orderId, OrderStatus status);
    }
}