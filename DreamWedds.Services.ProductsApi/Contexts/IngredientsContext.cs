using DreamWedds.Services.ProductsApi.Entities;
using MongoDB.Driver;

namespace DreamWedds.Services.ProductsApi.Contexts
{
    public interface IIngredientsContext
    {
        IMongoCollection<Ingredient> Ingredients { get; }
    }

    public class IngredientsContext : IIngredientsContext
    {
        public IMongoCollection<Ingredient> Ingredients { get; }

        public IngredientsContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:Databasename"));
            Ingredients = database.GetCollection<Ingredient>(configuration.GetValue<string>("DatabaseSettings:IngredientsCollection"));
        }
    }
}
