using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using System;
using System.Collections.Generic;

namespace OnlineShopWebApp.Helpers
{
    public static class Mapping
    {
        public static List<ProductViewModel> ToProductViewModels(List<Product> products)
        {
            var productsViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                productsViewModels.Add(ToProductViewModel(product));
            }
            return productsViewModels;
        }
        public static ProductViewModel ToProductViewModel(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description
            };
        }
        public static CartViewModel ToCartViewModel(Cart cart)
        {
            if (cart == null)
            {
                return null;
            }
            return new CartViewModel
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = ToCartItemViewModels(cart.Items)
            };
        }

        public static List<OrderViewModel> ToOrderViewModels(List<Order> orders)
        {
            var ordersViewModels = new List<OrderViewModel>();
            foreach (var order in orders)
            {
                ordersViewModels.Add(ToOrderViewModel(order));
            }
            return ordersViewModels;
        }
        public static OrderViewModel ToOrderViewModel(Order orderDb)
        {
            return new OrderViewModel
            {
                Id = orderDb.Id,
                CreateDateTime = orderDb.CreateDateTime,
                UserDeliveryInfo = ToUserDeliveryInfoViewModel(orderDb.UserDeliveryInfo),
                Items = ToCartItemViewModels(orderDb.Items),
                Status = (OrderStatusViewModel)(int)orderDb.Status
            };
        }
        public static UserDeliveryInfoViewModel ToUserDeliveryInfoViewModel(UserDeliveryInfo userDb)
        {
            if (userDb == null)
            {
                return null;
            }
            return new UserDeliveryInfoViewModel
            {
                Address = userDb.Address,
                City = userDb.City,
                Comments = userDb.Comments,
                FirstName = userDb.FirstName,
                LastName = userDb.LastName,
                Phone = userDb.Phone,
                ZipCode = userDb.ZipCode
            };
        }
        public static UserDeliveryInfo ToUserDeliveryInfo(UserDeliveryInfoViewModel user)
        {
            return new UserDeliveryInfo
            {
                Address = user.Address,
                City = user.City,
                Comments = user.Comments,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone,
                ZipCode = user.ZipCode
            };
        }
        public static List<CartItemViewModel> ToCartItemViewModels(List<CartItem> cartDbItems)
        {
            var cartItems = new List<CartItemViewModel>();
            foreach (var cartDbItem in cartDbItems)
            {
                var cartItem = new CartItemViewModel
                {
                    Id = cartDbItem.Id,
                    Amount = cartDbItem.Amount,
                    Product = ToProductViewModel(cartDbItem.Product)
                };
                cartItems.Add(cartItem);
            }
            return cartItems;
        }
    }
}
