using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartRoomScheduler.Api.Data;
using SmartRoomScheduler.Api.Models;
using SmartRoomScheduler.Api.Dtos;

namespace SmartRoomScheduler.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _db;
        public UsersController(AppDbContext db) 
        { 
            _db = db; 
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetUsers() =>
            await _db.Users
                .Select(u => new { u.Id, u.Name, u.Email, u.Role })
                .ToListAsync();

        // POST: api/Users/register
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterDto dto)
        {
            if (await _db.Users.AnyAsync(u => u.Email == dto.Email))
                return BadRequest(new { message = "Email already exists" });

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = dto.Password, // مبدئياً plain text (الأفضل Hash)
                Role = UserRole.Student       // ممكن تعدل الافتراضي حسب احتياجك
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            return Ok(new { message = "User registered successfully" });
        }

        // POST: api/Users/login
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (user == null || user.PasswordHash != dto.Password) // مبدئياً Plain Text
                return Unauthorized(new { message = "Invalid email or password" });

            return Ok(new
            {
                message = "Login successful",
                user.Id,
                user.Name,
                user.Email,
                user.Role
            });
        }
    }
}
