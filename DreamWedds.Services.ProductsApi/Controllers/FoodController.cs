using AutoMapper;
using DreamWedds.Services.ProductsApi.Entities;
using DreamWedds.Services.ProductsApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DreamWedds.Services.ProductsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodRepository _repository;
        private readonly ILogger<FoodController> _logger;
        private readonly IMapper _mapper;

        public FoodController(IFoodRepository repository, ILogger<FoodController> logger,
             IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IList<FoodMaster>>> GetTemplatesList()
        {
            var dishes = await _repository.GetFoodItemsList();
            return Ok(dishes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFood([FromBody] FoodMaster food)
        {
            if (food == null)
            {
                return BadRequest("Invalid food data.");
            }

            food.CreatedOn = DateTime.UtcNow;
            food.LastUpdatedOn = DateTime.UtcNow;

            await _repository.CreateAsync(food);
            return CreatedAtAction(nameof(GetFoodById), new { id = food.Id }, food);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFoodById(string id)
        {
            var food = await _repository.GetByIdAsync(id);
            if (food == null)
            {
                return NotFound();
            }
            return Ok(food);
        }

    }
}
