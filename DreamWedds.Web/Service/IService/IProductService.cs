using DreamWedds.Web.Models;

namespace DreamWedds.Web.Service.IService
{
    public interface IProductService
    {
     
        Task<ResponseDto?> GetAllProductsAsync();
        Task<ResponseDto?> GetProductByIdAsync(string id);
        Task<ResponseDto?> CreateProductsAsync(ProductDto productDto);
        Task<ResponseDto?> UpdateProductsAsync(FoodMasterDto productDto);
        Task<ResponseDto?> DeleteProductsAsync(string id);
    }
}
