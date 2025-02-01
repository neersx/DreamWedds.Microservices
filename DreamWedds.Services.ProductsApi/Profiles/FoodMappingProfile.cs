using AutoMapper;
using DreamWedds.Services.ProductsApi.Entities;
using DreamWedds.Services.ProductsApi.Models;

namespace DreamWedds.Services.ProductsApi.Profiles
{
    public class FoodMappingProfile : Profile
    {
        public FoodMappingProfile()
        {
            CreateMap<FoodMaster, FoodModelDto>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))  // Mapping Id to ProductId
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src =>
                    src.Images != null && src.Images.Count > 0 ? src.Images.FirstOrDefault().Url : null)); // First image URL
        }
    }
}
