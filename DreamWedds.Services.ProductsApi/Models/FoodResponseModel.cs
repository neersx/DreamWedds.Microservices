using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DreamWedds.Services.ProductsApi.Models
{

    public class FoodResponseModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        [BsonRequired]
        public string Name { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("bestSeason")]
        public string BestSeason { get; set; }

        [BsonElement("isNonVeg")]
        public bool IsNonVeg { get; set; }

        [BsonElement("region")]
        public string Region { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("category")]
        public string Category { get; set; }

        [BsonElement("lifeInDays")]
        public int LifeInDays { get; set; }

        [BsonElement("flavourType")]
        public string FlavourType { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("measurement")]
        public string Measurement { get; set; }

        [BsonElement("addons")]
        public List<string> Addons { get; set; }

        [BsonElement("discount")]
        public double Discount { get; set; }

        [BsonElement("days")]
        public string Days { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("availableToday")]
        public bool AvailableToday { get; set; }

        [BsonElement("ratings")]
        public double Ratings { get; set; }
    }

}
