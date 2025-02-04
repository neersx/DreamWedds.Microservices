using AutoMapper;
using DreamWedds.Services.ProductsApi.Entities;
using DreamWedds.Services.ProductsApi.Models;

namespace DreamWedds.Services.ProductsApi.Profiles
{
    public class CreateFoodProfile : Profile
    {
        public CreateFoodProfile()
        {
            CreateMap<CreateFoodItemsDto, FoodItem>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Preserve existing Id
                .ForMember(dest => dest.Name, opt => opt.Ignore()) // Keep existing Name
                .ForMember(dest => dest.IsRequired, opt => opt.Ignore()) // Keep existing IsRequired
                .ForMember(dest => dest.AvailableToday, opt => opt.Ignore()) // Keep existing value
                .ForMember(dest => dest.Description, opt => opt.Ignore()) // Keep existing description
                .ForMember(dest => dest.ImageUrl, opt => opt.Ignore()); // Keep existing image
        }
    }
}
