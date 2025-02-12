using DreamWedds.Services.ProductsApi.Entities;
using DreamWedds.Services.ProductsApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DreamWedds.Services.ProductsApi.Controllers
{
    [Route("api/foodItems")]
    [ApiController]
    public class FoodItemsController : ControllerBase
    {
        private readonly IFoodItemRepository _foodItemsService;

        public FoodItemsController(IFoodItemRepository foodItemsService)
        {
            _foodItemsService = foodItemsService;
        }

        // GET: api/FoodItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodItem>>> GetAll()
        {
            var foodItems = await _foodItemsService.GetAllAsync();
            return Ok(foodItems);
        }

        // GET: api/FoodItems/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodItem>> GetById(string id)
        {
            var foodItem = await _foodItemsService.GetByIdAsync(id);
            if (foodItem == null) return NotFound();
            return Ok(foodItem);
        }

        // POST: api/FoodItems
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] FoodItem foodItem)
        {
            if (foodItem == null) return BadRequest("Invalid data");

            await _foodItemsService.CreateAsync(foodItem);
            return CreatedAtAction(nameof(GetById), new { id = foodItem.Id }, foodItem);
        }

        // PUT: api/FoodItems/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] FoodItem foodItem)
        {
            if (foodItem == null || id != foodItem.Id) return BadRequest("Invalid data");

            var existingItem = await _foodItemsService.GetByIdAsync(id);
            if (existingItem == null) return NotFound();

            await _foodItemsService.UpdateAsync(id, foodItem);
            return NoContent();
        }

        // DELETE: api/FoodItems/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existingItem = await _foodItemsService.GetByIdAsync(id);
            if (existingItem == null) return NotFound();

            await _foodItemsService.DeleteAsync(id);
            return NoContent();
        }
    }
}
