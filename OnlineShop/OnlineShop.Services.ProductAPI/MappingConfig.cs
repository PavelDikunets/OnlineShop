using AutoMapper;
using OnlineShop.Services.ProductAPI.Models;
using OnlineShop.Services.ProductAPI.Models.Dtos;

namespace OnlineShop.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var MappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();
            });
            return MappingConfig;
        }
    }
}
