using DreamWedds.Services.ProductsApi.Entities;
using DreamWedds.Services.ProductsApi.Models;
using MongoDB.Driver;

namespace DreamWedds.Services.ProductsApi.Repository
{
    public interface IFoodMasterRepository
    {
        Task<IEnumerable<FoodMaster>> GetFoodItemsList();
        Task<FoodMaster> GetByIdAsync(string id);
        Task<FoodMaster> CreateAsync(CreateFoodMasterDto food);
        IMongoCollection<FoodResponseModel> GetFoodByCategory(string category);

    }
}
