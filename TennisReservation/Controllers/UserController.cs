using Microsoft.AspNetCore.Mvc;
using TennisReservation.Models;
using TennisReservation.Services;
using TennisReservation.Services.Authentication;

namespace TennisReservation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController: ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public UserController(IUserService userService,ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            var result= await _userService.RegisterUserAsync(request);
            if (!result)
                return BadRequest("User could not be created");
            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            var user = await _userService.LoginUserAsync(request);
            if (user == null)
                return Unauthorized("Invalid credentials.");
            var token = _tokenService.GenerateJwtToken(user);
            return Ok(new { Token = token });
        }
    }
}
