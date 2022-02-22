using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Db
{
    public class CartsDbStorage : ICartsStorage
    {
        private readonly DatabaseContext databaseContext;

        public CartsDbStorage(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<Cart> TryGetByUserIdAsync(string userId)
        {
            return await databaseContext.Carts.Include(x => x.Items).ThenInclude(x => x.Product).FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task AddAsync(Product product, string userId)
        {
            var currentCart = await TryGetByUserIdAsync(userId);
            if (currentCart == null)
            {
                var newCart = new Cart
                {
                    UserId = userId,
                    Items = new List<CartItem>
                    {
                        new CartItem
                        {
                            Id = Guid.NewGuid(),
                            Product = product,
                            Amount = 1,
                        }
                    }
                };
                await databaseContext.Carts.AddAsync(newCart);
            }
            else
            {
                var currentCartItem = currentCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
                if (currentCartItem != null)
                {
                    currentCartItem.Amount += 1;
                }
                else
                {
                    currentCart.Items.Add(new CartItem
                    {
                        Product = product,
                        Amount = 1
                    });
                }
            }
            await databaseContext.SaveChangesAsync();
        }
        public async Task DecreaseAmountAsync(Product product, string userId)
        {
            var currentCart = await TryGetByUserIdAsync(userId);
            var currentCartItem = currentCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
            if (currentCartItem.Amount > 1)
            {
                currentCartItem.Amount -= 1;
            }
            else
            {
                currentCart.Items.Remove(currentCartItem);
            }
           await databaseContext.SaveChangesAsync();
        }
        public async Task ClearAsync(string userId)
        {
            var currentCart = await TryGetByUserIdAsync(userId);
            var currentItems = currentCart.Items.ToList();
            foreach (var item in currentItems)
            {
                databaseContext.Items.Remove(item);
            }
            databaseContext.Carts.Remove(currentCart);
            await databaseContext.SaveChangesAsync();
        }
    }
}