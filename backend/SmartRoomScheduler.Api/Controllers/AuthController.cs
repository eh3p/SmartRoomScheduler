using Microsoft.AspNetCore.Mvc;
using SmartRoomScheduler.Api.Data;
using SmartRoomScheduler.Api.Models;
using SmartRoomScheduler.Api.Dtos;


namespace SmartRoomScheduler.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = dto.Password
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(new[] { "User registered successfully" });
        }
    }
}
