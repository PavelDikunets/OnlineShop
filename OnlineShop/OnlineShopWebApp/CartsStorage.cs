using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShopWebApp
{
    public class CartsStorage
    {
        private static List<Cart> carts = new List<Cart>();

        public static Cart TryGetByUserId(string userId)
        {
            return carts.FirstOrDefault(x => x.UserId == userId);
        }

        public static void Add(Product product, string userId)
        {
            var currentCart = TryGetByUserId(userId);
            if (currentCart == null)
            {
                var newCart = new Cart
                {
                    Id = Guid.NewGuid(),
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
                carts.Add(newCart);
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
                        Id = Guid.NewGuid(),
                        Product = product,
                        Amount = 1
                    });
                }
            }
        }
    }
}