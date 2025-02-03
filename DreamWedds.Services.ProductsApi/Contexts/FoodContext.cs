using DreamWedds.Services.ProductsApi.Data;
using DreamWedds.Services.ProductsApi.Entities;
using MongoDB.Driver;

namespace DreamWedds.Services.ProductsApi.Contexts
{
    public class FoodContext : IFoodContext
    {

        public IMongoCollection<FoodMaster> Dishes { get; }

        public FoodContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:Databasename"));
            Dishes = database.GetCollection<FoodMaster>(configuration.GetValue<string>("DatabaseSettings:MasterCollection"));
            //FoodContextSeedData.SeedData(Dishes);
        }
    }
}
