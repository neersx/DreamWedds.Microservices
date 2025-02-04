using DreamWedds.Services.ProductsApi.Entities;

namespace DreamWedds.Services.ProductsApi.Models
{
    public class CreateFoodMasterDto
    {
        public CreateFoodMasterDto(string title)
        {
            Name = title.Replace(' ', '-').ToLower();
            Title = title;
        }
        public CreateFoodMasterDto()
        {
            
        }

        public string? Id { get; set; }
        public required string Name { get; set; }
        public required string Title { get; set; }
        public string? BestSeason { get; set; }
        public bool IsNonVeg { get; set; }
        public string? Region { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public int LifeInDays { get; set; }
        public string? Size { get; set; }
        public decimal Price { get; set; }
        public int? Quantity { get; set; }
        public string? Measurement { get; set; }
        public double Discount { get; set; }
        public string? Type { get; set; }
        public bool AvailableToday { get; set; }
        public double Ratings { get; set; }

        public List<string> IngredientIds { get; set; } = [];
        public List<FoodImage> Images { get; set; } = [];
        public List<CreateFoodItemsDto> FoodItems { get; set; } = [];
        public List<string> FoodItemIds { get; set; } = [];
    }

    public class CreateFoodItemsDto
    {
        public string? Id { get; set; }
        public int? Quantity { get; set; }
        public string? Weight { get; set; }
    }

    public class CreateFoodImageDto
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
    }

}
