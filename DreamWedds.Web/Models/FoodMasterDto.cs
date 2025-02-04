namespace DreamWedds.Web.Models
{
    public class FoodMasterDto
    {
        public FoodMasterDto()
        {
                
        }
        public FoodMasterDto(string title)
        {
            Name = title.Replace(' ', '-').ToLower();
            Title = title;
        }
        public string? Id { get; set; }
        public required string? Name { get; set; }
        public required string Title { get; set; }
        public string? BestSeason { get; set; }
        public bool IsNonVeg { get; set; }
        public string? Region { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int? LifeInDays { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime LastUpdatedOn { get; set; }
        public string? Size { get; set; }
        public decimal Price { get; set; } = 0;
        public int? Quantity { get; set; }
        public string? Measurement { get; set; }
        public double Discount { get; set; } = 0;
        public string? Type { get; set; }
        public bool AvailableToday { get; set; }
        public double? Ratings { get; set; }

        public List<Ingredient> Ingredients { get; set; }
        public List<Image> Images { get; set; }
        public List<FoodItem> FoodItems { get; set; }
    }

    public class Ingredient
    {
        public string? Id { get; set; }
        public required string Name { get; set; }
        public required string HealthBenefits { get; set; }
    }

    public class Image
    {
        public Image()
        {
          
        }
        public Image(string title )
        {
            Name = title.Replace(' ', '-').ToLower();
            Title = title;
        }
        public string? Id { get; set; }
        public required string Name { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
    }

    public class FoodItem
    {
        public string? Id { get; set; }
        public required string Name { get; set; }
        public int? Quantity { get; set; } = 0;
        public bool IsRequired { get; set; } = false;
        public bool AvailableToday { get; set; } = false;
        public string? Weight { get; set; }
        public string? Description { get; set; }
    }

}
