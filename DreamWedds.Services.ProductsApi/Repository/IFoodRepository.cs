using DreamWedds.Services.ProductsApi.Entities;
using DreamWedds.Services.ProductsApi.Models;
using MongoDB.Driver;

namespace DreamWedds.Services.ProductsApi.Repository
{
    public interface IFoodRepository
    {
        Task<IEnumerable<FoodMaster>> GetFoodItemsList();
        Task<FoodMaster> GetFoodDetailsById(string id);
        IMongoCollection<FoodResponseModel> GetFoodByCategory(string category);

    }
}
