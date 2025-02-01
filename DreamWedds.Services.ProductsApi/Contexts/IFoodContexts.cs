using DreamWedds.Services.ProductsApi.Entities;
using MongoDB.Driver;

namespace DreamWedds.Services.ProductsApi.Contexts
{
    public interface IFoodContext
    {
        IMongoCollection<FoodMaster> Dishes { get; }
    }
}
