namespace DreamWedds.Web.Models
{
    public class FoodMasterDto
    {
        public string Id { get; set; }
        public required string Name { get; set; }
        public required string Title { get; set; }
        public string BestSeason { get; set; }
        public bool IsNonVeg { get; set; }
        public string Region { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int LifeInDays { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public int? Quantity { get; set; }
        public string Measurement { get; set; }
        public double Discount { get; set; }
        public string Type { get; set; }
        public bool AvailableToday { get; set; }
        public double Ratings { get; set; }

        public List<Ingredient> Ingredients { get; set; }
        public List<Image> Images { get; set; }
        public List<FoodItem> FoodItems { get; set; }
    }

    public class Ingredient
    {
        public required string Name { get; set; }
        public required string HealthBenefits { get; set; }
    }

    public class Image
    {
        public required string Name { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
    }

    public class FoodItem
    {
        public required string Name { get; set; }
        public int? Quantity { get; set; }
        public bool IsRequired { get; set; }
        public bool AvailableToday { get; set; } = false;
        public string? Weight { get; set; }
        public string? Description { get; set; }
    }

}
