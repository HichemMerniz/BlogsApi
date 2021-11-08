using BlogsApi.Data.Repositories;
using BlogsApi.Dtos;
using BlogsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogsApi.Controllers.Api
{
    [Route("api")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost("register")]
        public IActionResult Register(RegisterDto registerDto)
        {
            var user = new Users
            {
                FullName = registerDto.FullName,
                Email = registerDto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
                BirthDay = registerDto.Birthday
            };

            return Created("success", _userRepository.Register(user));
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto loginDto)
        {
            var user = _userRepository.GetByEmail(loginDto.Email);

            if (user == null) return BadRequest(new { message = $"User Not Existe !!"});

            if (BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password)==false)
            {
                return BadRequest(new { message = "Check your password !! " });
            }
            return Ok(user);
        }

    }
}
