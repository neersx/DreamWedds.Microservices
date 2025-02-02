using DreamWedds.Services.ProductsApi.Contexts;
using DreamWedds.Services.ProductsApi.Entities;
using DreamWedds.Services.ProductsApi.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DreamWedds.Services.ProductsApi.Repository
{
    public class FoodMasterRepository : IFoodMasterRepository
    {
        private readonly IFoodContext _context;
        private readonly IIngredientsRepository _ingredientRepository;
        private readonly IFoodItemRepository _foodItemRepository;

        public FoodMasterRepository(IFoodContext context, IIngredientsRepository ingredientRepository, IFoodItemRepository foodItemRepository)
        {
            _ingredientRepository = ingredientRepository;
            _foodItemRepository = foodItemRepository;
            _context = context;
        }
        public async Task<IEnumerable<FoodMaster>> GetFoodItemsList()
        {

            return await _context.Dishes.Find(food => true).ToListAsync();
        }

        public async Task<FoodMaster> CreateAsync(CreateFoodMasterDto dto)
        {
            var ingredients = await _ingredientRepository.GetByIdsAsync(dto.IngredientIds);
            //var images = await _imageRepository.GetByIdsAsync(dto.ImageIds);
            var foodItems = await _foodItemRepository.GetByIdsAsync(dto.FoodItemIds);

            var foodMaster = new FoodMaster
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Name = dto.Name,
                Title = dto.Title,
                BestSeason = dto.BestSeason,
                IsNonVeg = dto.IsNonVeg,
                Region = dto.Region,
                Description = dto.Description,
                Category = dto.Category,
                LifeInDays = dto.LifeInDays,
                Price = dto.Price,
                Quantity = dto.Quantity,
                Measurement = dto.Measurement,
                Discount = dto.Discount,
                Type = dto.Type,
                AvailableToday = dto.AvailableToday,
                Ratings = dto.Ratings,
                Ingredients = ingredients,
                Images = dto.Images,
                FoodItems = foodItems,
                CreatedOn = DateTime.UtcNow,
                LastUpdatedOn = DateTime.UtcNow,
                IsDeleted = false
            };

            await _context.Dishes.InsertOneAsync(foodMaster);
            return foodMaster;
        }

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
