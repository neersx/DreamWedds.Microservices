using AutoMapper;
using DreamWedds.Services.CouponAPI.Models;
using DreamWedds.Services.CouponAPI.Models.Dto;

namespace DreamWedds.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>();
                config.CreateMap<Coupon, CouponDto>();
            });
            return mappingConfig;
        }
    }
}
