using AutoMapper;
using OnlineShop.Db.Models;
using OnlineShop.WebApp.Areas.Admin.Models;
using OnlineShop.WebApp.Models;

namespace OnlineShop.WebApp.Helpers
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
