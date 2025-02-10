using DreamWedds.Services.ProductsApi.Entities;

namespace DreamWedds.Services.ProductsApi.Repository
{
    public interface IIngredientsRepository
    {
        Task<IEnumerable<Ingredient>> GetAllAsync();
        Task<Ingredient?> GetByIdAsync(string id);
        Task CreateAsync(Ingredient ingredient);
        Task CreateManyAsync(List<Ingredient> ingredients);
        Task UpdateAsync(string id, Ingredient ingredient);
        Task DeleteAsync(string id);
        Task<List<Ingredient>> GetByIdsAsync(IEnumerable<string> ids);
    }
}
