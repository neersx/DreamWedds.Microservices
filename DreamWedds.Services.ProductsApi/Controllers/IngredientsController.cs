using DreamWedds.Services.ProductsApi.Entities;
using DreamWedds.Services.ProductsApi.Models;
using DreamWedds.Services.ProductsApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DreamWedds.Services.ProductsApi.Controllers
{
    [Route("api/ingredients")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientsRepository _ingredientService;

        public IngredientsController(IIngredientsRepository ingredientService) =>
            _ingredientService = ingredientService;

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _ingredientService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id) =>
            Ok(await _ingredientService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] IngredientRequestDto dto)
        {
            var ingredient = new Ingredient { Name = dto.Name, HealthBenefits = dto.HealthBenefits };
            await _ingredientService.CreateAsync(ingredient);
            return CreatedAtAction(nameof(GetById), new { id = ingredient.Id }, ingredient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] IngredientRequestDto dto)
        {
            var ingredient = new Ingredient { Id = id, Name = dto.Name, HealthBenefits = dto.HealthBenefits };
            await _ingredientService.UpdateAsync(id, ingredient);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _ingredientService.DeleteAsync(id);
            return NoContent();
        }
    }
}
