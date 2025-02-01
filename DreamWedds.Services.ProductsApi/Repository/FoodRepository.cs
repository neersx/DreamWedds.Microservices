using DreamWedds.Services.ProductsApi.Contexts;
using DreamWedds.Services.ProductsApi.Entities;
using DreamWedds.Services.ProductsApi.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DreamWedds.Services.ProductsApi.Repository
{
    public class FoodRepository(IFoodContext context) : IFoodRepository
    {
        private readonly IFoodContext _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<IEnumerable<FoodMaster>> GetFoodItemsList()
        {

            return await _context
                            .Dishes
                            .Find(food => true).ToListAsync();
        }

        public async Task CreateAsync(FoodMaster food) => await _context.Dishes.InsertOneAsync(food);

        public async Task<FoodMaster> GetByIdAsync(string id)
        {
            if (!ObjectId.TryParse(id, out var objectId))
            {
                throw new FormatException("Invalid ObjectId format.");
            }

            return await _context.Dishes.Find(f => f.Id == id).FirstOrDefaultAsync();
        }

        public IMongoCollection<FoodResponseModel> GetFoodByCategory(string category)
        {
            throw new NotImplementedException();
        }
    }
}
