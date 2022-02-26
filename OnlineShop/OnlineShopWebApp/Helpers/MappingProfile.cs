using AutoMapper;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<Cart, CartViewModel>();
            CreateMap<Order, OrderViewModel>();
            CreateMap<UserDeliveryInfo, UserDeliveryInfoViewModel>();
            CreateMap<CartItem, CartItemViewModel>();
        }
    };
}
