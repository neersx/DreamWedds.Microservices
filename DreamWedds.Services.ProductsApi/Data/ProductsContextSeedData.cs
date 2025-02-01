using DreamWedds.Services.ProductsApi.Entities;
using MongoDB.Driver;

namespace DreamWedds.Services.ProductsApi.Data
{
    public class FoodContextSeedData
    {
        public static void SeedData(IMongoCollection<FoodMaster> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(AddFoods());
            }
        }

        private static IEnumerable<FoodMaster> AddFoods()
        {
            var data = new List<FoodMaster>
                {
                };
            return data;
        }
    }
}
