using AutoMapper;
using DreamWedds.Services.ShoppingCartAPI.Models.Dto;
using DreamWedds.Services.ShoppingCartAPI.Models;

namespace DreamWedds.Services.ShoppingCartAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
                config.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
