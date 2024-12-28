using DreamWedds.Services.EmailAPI.Message;
using DreamWedds.Services.EmailAPI.Models.Dto;

namespace DreamWedds.Services.EmailAPI.Services
{
    public interface IEmailService
    {
        Task EmailCartAndLog(CartDto cartDto);
        Task RegisterUserEmailAndLog(string email);
        Task LogOrderPlaced(RewardsMessage rewardsDto);
    }
}
