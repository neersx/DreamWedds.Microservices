using DreamWedds.Services.ProductsApi.Contexts;
using DreamWedds.Services.ProductsApi.Entities;
using MongoDB.Driver;

namespace DreamWedds.Services.ProductsApi.Repository
{
    public class IngredientRepository(IIngredientsContext context) : IIngredientsRepository
    {
        private readonly IIngredientsContext _context = context ?? throw new ArgumentNullException(nameof(context));


        //public IngredientRepository(IMongoClient mongoClient)
        //{
        //    var database = mongoClient.GetDatabase("rr_productdb");
        //    _ingredientCollection = database.GetCollection<Ingredient>("ingredients");
        //}

        public async Task<List<Ingredient>> GetByIdsAsync(IEnumerable<string> ids)
        {
            var filter = Builders<Ingredient>.Filter.In(i => i.Id, ids);
            return await _context.Ingredients.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Ingredient>> GetAllAsync() =>
            await _context.Ingredients.Find(_ => true).ToListAsync();

        public async Task<Ingredient?> GetByIdAsync(string id) =>
            await _context.Ingredients.Find(i => i.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Ingredient ingredient) =>
            await _context.Ingredients.InsertOneAsync(ingredient);

        public async Task CreateManyAsync(List<Ingredient> ingredients) =>
          await _context.Ingredients.InsertManyAsync(ingredients);

        public async Task UpdateAsync(string id, Ingredient ingredient) =>
            await _context.Ingredients.ReplaceOneAsync(i => i.Id == id, ingredient);

        public async Task DeleteAsync(string id) =>
            await _context.Ingredients.DeleteOneAsync(i => i.Id == id);

        public async Task DeleteManyAsync(string id) =>
        await _context.Ingredients.DeleteManyAsync(i => i.Id == id);
    }
}
