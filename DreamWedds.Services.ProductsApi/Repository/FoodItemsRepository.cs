using DreamWedds.Services.ProductsApi.Contexts;
using DreamWedds.Services.ProductsApi.Entities;
using MongoDB.Driver;

namespace DreamWedds.Services.ProductsApi.Repository
{
    public class FoodItemsRepository (IFoodItemsContext context) : IFoodItemRepository
    {
        //private readonly IMongoCollection<FoodItem> _foodItemCollection;
        private readonly IFoodItemsContext _context = context ?? throw new ArgumentNullException(nameof(context));


        //public FoodItemsRepository(IMongoClient mongoClient)
        //{
        //    var database = mongoClient.GetDatabase("FoodDatabase");
        //    _foodItemCollection = database.GetCollection<FoodItem>("foodItems");
        //}

        public async Task<List<FoodItem>> GetByIdsAsync(IEnumerable<string> ids)
        {
            var filter = Builders<FoodItem>.Filter.In(i => i.Id, ids);
            return await _context.FoodItems.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<FoodItem>> GetAllAsync() =>
            await _context.FoodItems.Find(_ => true).ToListAsync();

        public async Task<FoodItem?> GetByIdAsync(string id) =>
            await _context.FoodItems.Find(i => i.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(FoodItem foodItem) =>
            await _context.FoodItems.InsertOneAsync(foodItem);

        public async Task UpdateAsync(string id, FoodItem foodItem) =>
            await _context.FoodItems.ReplaceOneAsync(i => i.Id == id, foodItem);

        public async Task DeleteAsync(string id) =>
            await _context.FoodItems.DeleteOneAsync(i => i.Id == id);
    }
}
