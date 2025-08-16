using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartRoomScheduler.Api.Data;
using SmartRoomScheduler.Api.Models;

namespace SmartRoomScheduler.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public RoomsController(AppDbContext db) { _db = db; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms() => await _db.Rooms.AsNoTracking().ToListAsync();
    }
}
