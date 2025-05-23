using Microsoft.AspNetCore.Mvc;
using OracleJwtApiFull.DTOs;
using OracleJwtApiFull.Services.Interfaces;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OracleJwtApiFull.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var result = await _userService.RegisterAsync(dto);
            if (result == "Email already exists.")
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var result = await _userService.LoginAsync(dto);
            if (result == "Invalid credentials.")
                return Unauthorized(result);

            return Ok(new { token = result });
        }

        [HttpGet("me")]
        public async Task<IActionResult> Me()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdString, out var userId))
                return Unauthorized();

            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null)
                return Unauthorized();

            return Ok(new { user.Id, user.Name, user.Email, user.Role });
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser(UpdateUserDto dto)
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdString, out var userId))
                return Unauthorized();

            var result = await _userService.UpdateUserAsync(userId, dto);
            if (result == "User not found.")
                return NotFound(result);

            return Ok(result);
        }
    }
}
