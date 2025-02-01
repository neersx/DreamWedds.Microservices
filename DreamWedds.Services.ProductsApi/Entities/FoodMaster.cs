using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DreamWedds.Services.ProductsApi.Entities
{
    public class FoodMaster
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]  // ✅ Ensure ObjectId mapping
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();


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
        public int Id { get; set; }

        public required string Name { get; set; }
        public required string HealthBenefits { get; set; }
    }

    public class Image
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]  // ✅ Ensure ObjectId mapping
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        public required string Name { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
    }

    public class FoodItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]  // ✅ Ensure ObjectId mapping
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        public required string Name { get; set; }
        public int? Quantity { get; set; }
        public bool IsRequired { get; set; }
        public bool AvailableToday { get; set; } = false;
        public string? Weight { get; set; }
        public string? Description { get; set; }
    }

    public class Comment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]  // ✅ Ensure ObjectId mapping
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        public required string CommentText { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserImage { get; set; }
    }

}
