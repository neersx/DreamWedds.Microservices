using AutoMapper;
using DreamWedds.Services.ProductsApi.Entities;
using DreamWedds.Services.ProductsApi.Models;
using DreamWedds.Services.ProductsApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DreamWedds.Services.ProductsApi.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodMasterRepository _repository;
        private readonly IIngredientsRepository _ingredientRepository;
        //private readonly IRepository<Image> _imageRepository;
        private readonly IFoodItemRepository _foodItemRepository;
        private readonly ILogger<FoodController> _logger;
        private readonly IMapper _mapper;
        protected ResponseDto _response;

        public FoodController(IFoodMasterRepository repository, IIngredientsRepository ingredientRepository, IFoodItemRepository foodItemRepository, ILogger<FoodController> logger,
             IMapper mapper)
        {
            _repository = repository;
            _ingredientRepository = ingredientRepository;
            _foodItemRepository = foodItemRepository;
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
        public async Task<IActionResult> Create([FromBody] CreateFoodMasterDto dto)
        {
            if (dto == null) return BadRequest("Invalid request data");

            _response.Result = await _repository.CreateAsync(dto);
            return Ok(_response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CreateFoodMasterDto dto)
        {
            if (dto == null) return BadRequest("Invalid request data");

            _response.Result = await _repository.UpdateAsync(dto);
            return Ok(_response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetFoodById(string id)
        {
            var details = await _repository.GetByIdAsync(id);
            _response.Result = details;

            if (_response.Result == null)
            {
                _response.IsSuccess = false;
                return NotFound();
            }
            return Ok(_response);
        }

    }
}
