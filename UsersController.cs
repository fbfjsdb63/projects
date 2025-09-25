using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task1.data;
using task1.DTOs;
using task1.model;
using task1.NewFolder;

// Alias عشان نتفادى التعارض مع System.Threading.Tasks.TaskStatus
using ModelTaskStatus = task1.model.TaskStatus;

namespace task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _context.Users
                .Include(u => u.Tasks)
                .AsNoTracking()
                .ToListAsync();

            return Ok(users.Select(MapUserToDto));
        }

        // GET: api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _context.Users
                .Include(u => u.Tasks)
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                return NotFound(new { message = $"User with ID {id} not found" });

            return Ok(MapUserToDto(user));
        }


        [HttpPost]
        public async Task<ActionResult<UserDto>> PostUser([FromForm] UserCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newUser = new user
            {
                Name = dto.Name,
                Email = dto.Email,
                Tasks = new List<TaskItem>
        {
            new TaskItem
            {
                Title = dto.TaskTitle,
                Description = dto.TaskDescription,
                Status = (ModelTaskStatus)dto.TaskStatus
            }
        }
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, MapUserToDto(newUser));
        }









        // PUT: api/users/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> PutUser(int id, [FromForm] UserUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingUser = await _context.Users
                .Include(u => u.Tasks)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (existingUser == null)
                return NotFound(new { message = $"User with ID {id} not found" });

            existingUser.Name = dto.Name;
            existingUser.Email = dto.Email;

            existingUser.Tasks.Clear();
            existingUser.Tasks.Add(new TaskItem
            {
                Title = dto.TaskTitle,
                Description = dto.TaskDescription,
                Status = (ModelTaskStatus)dto.TaskStatus
            });

            await _context.SaveChangesAsync();

            return Ok(MapUserToDto(existingUser));
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound(new { message = $"User with ID {id} not found" });

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Mapping helper
        private static UserDto MapUserToDto(user u) =>
            new UserDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Tasks = u.Tasks?.Select(t => new TaskDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Status = (int)t.Status
                }).ToList() ?? new List<TaskDto>()
            };
    }
}
