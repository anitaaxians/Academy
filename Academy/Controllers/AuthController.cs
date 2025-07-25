using Academy.DTOs;
using Academy.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Academy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService= authService ;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto)
        {
            try
            {
                var message = await _authService.RegisterAsync(dto);
                return Ok(new { message });
            }
            catch (Exception e)
            {
                var errorMessage = e.InnerException?.Message ?? e.Message;
                return BadRequest(new { error = errorMessage });
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        {
            try
            {
                var token = await _authService.LoginAsync(dto);
                return Ok(new { token });
            }
            catch (Exception e)
            {
                var errorMessage = e.InnerException?.Message ?? e.Message;
                return Unauthorized(new { error = errorMessage });
            }
        }

    }
}
