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
        private readonly IJwtService _jwtService; // צריך שתבני שירות שמנפיק טוקן

        public AuthController(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            // כאן את צריכה להצפין סיסמה עם Hash
            var hash = PasswordHasher.Hash(dto.Password);
            var user = await _userService.RegisterUserAsync(dto, hash);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var hash = PasswordHasher.Hash(dto.Password);
            var user = await _userService.GetUserByEmailAndPasswordAsync(dto.Email, hash);
            if (user == null) return Unauthorized();

            var token = _jwtService.GenerateToken(user);
            return Ok(new { token });
        }
    }
}
