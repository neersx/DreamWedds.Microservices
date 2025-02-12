using DreamWedds.Services.ShoppingCartAPI.Models.Dto;

namespace DreamWedds.Services.ShoppingCartAPI.Service.IService
{
    public interface ICouponService
    {
        Task<CouponDto> GetCoupon(string couponCode);
    }
}
