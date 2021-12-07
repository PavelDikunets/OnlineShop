using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class CartsDbStorage : ICartsStorage
    {
        private readonly DatabaseContext databaseContext;

        public CartsDbStorage(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public Cart TryGetByUserId(string userId)
        {
            return databaseContext.Carts.Include(x => x.Items).ThenInclude(x => x.Product).FirstOrDefault(x => x.UserId == userId);
        }

        public void Add(Product product, string userId)
        {
            var currentCart = TryGetByUserId(userId);
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
                databaseContext.Carts.Add(newCart);
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
            databaseContext.SaveChanges();
        }
        public void DecreaseAmount(Product product, string userId)
        {
            var currentCart = TryGetByUserId(userId);
            var currentCartItem = currentCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
            if (currentCartItem.Amount > 1)
            {
                currentCartItem.Amount -= 1;
            }
            else
            {
                currentCart.Items.Remove(currentCartItem);
            }
            databaseContext.SaveChanges();
        }
        public void Clear(string userId)
        {
            var currentCart = TryGetByUserId(userId);
            var currentItems = currentCart.Items.ToList();
            foreach (var item in currentItems)
            {
                databaseContext.Items.Remove(item);
            }
            databaseContext.Carts.Remove(currentCart);
            databaseContext.SaveChanges();
        }
    }
}