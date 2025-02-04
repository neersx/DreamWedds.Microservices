using AutoMapper;
using DreamWedds.Services.ProductsApi.Contexts;
using DreamWedds.Services.ProductsApi.Entities;
using DreamWedds.Services.ProductsApi.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Xml.Linq;

namespace DreamWedds.Services.ProductsApi.Repository
{
    public class FoodMasterRepository : IFoodMasterRepository
    {
        private readonly IFoodContext _context;
        private readonly IMapper _mapper;
        private readonly IIngredientsRepository _ingredientRepository;
        private readonly IFoodItemRepository _foodItemRepository;

        public FoodMasterRepository(IFoodContext context, IMapper mapper, IIngredientsRepository ingredientRepository, IFoodItemRepository foodItemRepository)
        {
            _ingredientRepository = ingredientRepository;
            _foodItemRepository = foodItemRepository;
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<FoodMaster>> GetFoodItemsList()
        {

            return await _context.Dishes.Find(food => true).ToListAsync();
        }

        public async Task<FoodMaster> CreateAsync(CreateFoodMasterDto dto)
        {
            var ingredients = await _ingredientRepository.GetByIdsAsync(dto.IngredientIds);

            var foodItems = await _foodItemRepository.GetByIdsAsync(dto.FoodItems.Select(x => x.Id).ToArray());
            foodItems = _mapper.Map(dto.FoodItems, foodItems);
            //  Id = ObjectId.GenerateNewId().ToString(),
            var foodMaster = new FoodMaster()
            {
                Name = dto.Title.Replace(' ', '-').ToLower(),
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

        public async Task<bool> UpdateAsync(CreateFoodMasterDto dto)
        {
            var food = await _context.Dishes.Find(f => f.Id == dto.Id).FirstOrDefaultAsync() ?? throw new Exception("Not Found Dish");

            var ingredients = await _ingredientRepository.GetByIdsAsync(dto.IngredientIds);
            var foodItems = await _foodItemRepository.GetByIdsAsync(dto.FoodItems.Select(x => x.Id).ToArray());
            foodItems = _mapper.Map(dto.FoodItems, foodItems);
            var filter = Builders<FoodMaster>.Filter.Eq(f => f.Id, dto.Id);

            var update = Builders<FoodMaster>.Update
                .Set(f => f.Name, dto.Title.Replace(' ', '-').ToLower())
                .Set(f => f.Title, dto.Title)
                .Set(f => f.BestSeason, dto.BestSeason)
                .Set(f => f.IsNonVeg, dto.IsNonVeg)
                .Set(f => f.Region, dto.Region)
                .Set(f => f.Description, dto.Description)
                .Set(f => f.Category, dto.Category)
                .Set(f => f.LifeInDays, dto.LifeInDays)
                .Set(f => f.Price, dto.Price)
                .Set(f => f.Quantity, dto.Quantity)
                .Set(f => f.Measurement, dto.Measurement)
                .Set(f => f.Discount, dto.Discount)
                .Set(f => f.Type, dto.Type)
                .Set(f => f.AvailableToday, dto.AvailableToday)
                .Set(f => f.Ratings, dto.Ratings)
                .Set(f => f.Ingredients, ingredients)  // List of Ingredients
                .Set(f => f.Images, dto.Images)  // List of Images
                .Set(f => f.FoodItems, foodItems)  // List of FoodItems
                .Set(f => f.LastUpdatedOn, DateTime.UtcNow)
                .Set(f => f.IsDeleted, false);

            var result = await _context.Dishes.UpdateOneAsync(filter, update);

            return result.ModifiedCount > 0;
        }
    }
}
