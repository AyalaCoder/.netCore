using final_project.BL;
using final_project.models;
using final_project.models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace final_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public AuthController(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            var user = await _userService.RegisterAsync(dto);
            return Ok(new { user.Id, user.Email });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var user = await _userService.GetUserByEmailAsync(dto.Email);
            if (user == null) return Unauthorized("Email not found");

            var hasher = new PasswordHasher<User>();
            var result = hasher.VerifyHashedPassword(user, user.HashPassword, dto.Password);

            if (result == PasswordVerificationResult.Failed)
                return Unauthorized("Invalid password");

            var token = _jwtService.GenerateToken(user);
            return Ok(new { token });
        }
    }

}
