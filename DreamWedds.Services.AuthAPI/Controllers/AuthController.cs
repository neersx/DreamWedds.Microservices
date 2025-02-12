using System.ComponentModel.DataAnnotations;
using DreamWedds.Services.AuthAPI.Models;
using DreamWedds.Services.AuthAPI.Models.Dto;
using DreamWedds.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Mvc;

[Route("api/mobile/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IAuthService _authService;
    protected ResponseDto _response;

    public AuthController(IAuthService authService, IConfiguration configuration)
    {
        _authService = authService;

        _configuration = configuration;
        _response = new();
    }

    // Registration Endpoint
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = new ApplicationUser
        {
            Name = model.Name ?? "Guest",
            UserName = model.PhoneNumber,
            PhoneNumber = model.PhoneNumber,
        };

        var result = await _authService.Register(model);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok(new { Message = "User registered successfully!" });
    }

    // Login Endpoint
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var loginResponse = await _authService.Login(model);
        if (loginResponse.User == null)
        {
            _response.IsSuccess = false;
            _response.Message = "Username or password is incorrect";
            return BadRequest(_response);
        }

        _response.Result = loginResponse;
        return Ok(_response);
    }
}

public class LoginModel
{
    [Required]
    [Phone]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}
