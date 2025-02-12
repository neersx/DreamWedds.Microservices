using DreamWedds.Services.AuthAPI.Models.Dto;
using Microsoft.AspNetCore.Identity;

namespace DreamWedds.Services.AuthAPI.Service.IService
{
    public interface IAuthService
    {
        Task<IdentityResult> Register(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        Task<LoginResponseDto> Login(LoginModel loginRequestDto);
        Task<bool> AssignRole(string email, string roleName);
    }
}
