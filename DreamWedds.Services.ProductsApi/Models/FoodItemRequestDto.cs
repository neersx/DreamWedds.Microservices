namespace DreamWedds.Services.ProductsApi.Models
{
    public class FoodItemRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string Weight { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
