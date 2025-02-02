using DreamWedds.Services.ProductsApi.Entities;

namespace DreamWedds.Services.ProductsApi.Repository
{
    public interface IFoodItemRepository
    {
        Task<IEnumerable<FoodItem>> GetAllAsync();
        Task<FoodItem?> GetByIdAsync(string id);
        public Task CreateAsync(FoodItem foodItem);
        Task UpdateAsync(string id, FoodItem foodItem);
        Task DeleteAsync(string id);
    }
}
