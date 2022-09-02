using AutoMapper;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Areas.Admin.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();
            CreateMap<User, ChangePasswordViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();
            CreateMap<Cart, CartViewModel>();
            CreateMap<Order, OrderViewModel>();
            CreateMap<UserDeliveryInfo, UserDeliveryInfoViewModel>();
            CreateMap<CartItem, CartItemViewModel>();
        }
    };
}
