using DreamWedds.Services.ProductsApi.Entities;
using MongoDB.Driver;

namespace DreamWedds.Services.ProductsApi.Contexts
{
    public interface IFoodItemsContext
    {
        IMongoCollection<FoodItem> FoodItems { get; }
    }

    public class FoodItemsContext : IFoodItemsContext
    {
        public IMongoCollection<FoodItem> FoodItems { get; }

        public FoodItemsContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:Databasename"));
            FoodItems = database.GetCollection<FoodItem>(configuration.GetValue<string>("DatabaseSettings:FoodItemsCollection"));
            //FoodContextSeedData.SeedData(Dishes);
        }
    }

}



 