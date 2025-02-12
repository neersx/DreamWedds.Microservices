using DreamWedds.Services.ShoppingCartAPI.Models.Dto;

namespace DreamWedds.Services.ShoppingCartAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
