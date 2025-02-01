using AutoMapper;
using DreamWedds.Services.ProductsApi.Entities;
using DreamWedds.Services.ProductsApi.Models;
using DreamWedds.Services.ProductsApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DreamWedds.Services.ProductsApi.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodRepository _repository;
        private readonly ILogger<FoodController> _logger;
        private readonly IMapper _mapper;
        protected ResponseDto _response;

        public FoodController(IFoodRepository repository, ILogger<FoodController> logger,
             IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet]
        public async Task<ActionResult<IList<FoodMaster>>> GetTemplatesList()
        {
            var dishes = await _repository.GetFoodItemsList();
            _response.Result = _mapper.Map<IEnumerable<FoodModelDto>>(dishes);
            
            return Ok(_response);
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
            var details = await _repository.GetByIdAsync(id);
            _response.Result = _mapper.Map<FoodModelDto>(details);

            if (_response.Result == null)
            {
                _response.IsSuccess = false;
                return NotFound();
            }
            return Ok(_response);
        }

    }
}
