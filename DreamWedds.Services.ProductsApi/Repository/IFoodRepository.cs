using DreamWedds.Services.ProductsApi.Entities;
using DreamWedds.Services.ProductsApi.Models;
using MongoDB.Driver;

namespace DreamWedds.Services.ProductsApi.Repository
{
    public interface IFoodRepository
    {
        Task<IEnumerable<FoodMaster>> GetFoodItemsList();
        Task<FoodMaster> GetByIdAsync(string id);
        Task CreateAsync(FoodMaster food);
        IMongoCollection<FoodResponseModel> GetFoodByCategory(string category);

    }
}
