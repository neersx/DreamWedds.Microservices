namespace DreamWedds.Services.ProductsApi.Models
{
    public class FoodModelDto
    {
        public string Id { get; set; }  // Maps from FoodMaster's Id
        public string Name { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string? ImageUrl { get; set; }  // Maps f
    }
}
