using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;
using System.Linq;

namespace OnlineShopWebApp.Helpers
{
    public static class Mapping
    {

        public static ProductViewModel ToProductViewModel(this Product productDb)
        {
            return new ProductViewModel
            {
                Id = productDb.Id,
                Name = productDb.Name,
                Cost = productDb.Cost,
                Description = productDb.Description
            };
        }

        public static CartViewModel ToCartViewModel(this Cart cartDb)
        {
            if (cartDb == null)
            {
                return null;
            }
            return new CartViewModel
            {
                Id = cartDb.Id,
                UserId = cartDb.UserId,
                Items = cartDb.Items.Select(x => x.ToCartItemViewModel()).ToList()
            };
        }

        public static OrderViewModel ToOrderViewModel(this Order orderDb)
        {
            return new OrderViewModel
            {
                Id = orderDb.Id,
                CreateDateTime = orderDb.CreateDateTime,
                UserDeliveryInfo = orderDb.UserDeliveryInfo.ToUserDeliveryInfoViewModel(),
                Items = orderDb.Items.Select(x => x.ToCartItemViewModel()).ToList(),
                Status = (OrderStatusViewModel)(int)orderDb.Status
            };
        }

        public static UserDeliveryInfoViewModel ToUserDeliveryInfoViewModel(this UserDeliveryInfo userDb)
        {
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

        public static UserDeliveryInfo ToUserDeliveryInfo(this UserDeliveryInfoViewModel user)
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

        public static CartItemViewModel ToCartItemViewModel(this CartItem cartItemDb)
        {
            return new CartItemViewModel
            {
                Id = cartItemDb.Id,
                Amount = cartItemDb.Amount,
                Product = cartItemDb.Product.ToProductViewModel()
            };
        }
    }
}
