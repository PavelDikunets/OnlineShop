using AutoMapper;
using OnlineShop.Services.ProductAPI.Models;
using OnlineShop.Services.ProductAPI.Models.Dto;

namespace OnlineShop.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Product, ProductDto>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
