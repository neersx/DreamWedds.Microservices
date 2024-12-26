
using DreamWedds.Services.OrderAPI.Models.Dto;

namespace DreamWedds.Services.ShoppingCartAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
