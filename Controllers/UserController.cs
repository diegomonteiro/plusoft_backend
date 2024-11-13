using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using plusoft_backend.Data;
using plusoft_backend.Models;
using Microsoft.Extensions.Logging;

namespace plusoft_backend.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase{
    private readonly UserContext _context;
    private readonly ILogger<UserController> _logger;

    public UserController(UserContext context, ILogger<UserController> logger){
        _context = context;
        _logger  = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers(){
        return await _context.Users.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return NotFound();
        return user;
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(User user)
    {
        user.UpdatedAt = DateTime.UtcNow;
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, User user)
    {
        

        var existingUser = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);

        if(existingUser == null) return NotFound($"User with id {id} not founded");

        _logger.LogInformation($"Updating user with ID: {id} == {existingUser.Id}");

        if (id != existingUser.Id) { return BadRequest(); }
        
        //Update object with User Object Data
        user.Id = id;
        existingUser.Name = user.Name;
        existingUser.Email = user.Email;
        existingUser.Phone = user.Phone;
        existingUser.UpdatedAt = DateTime.UtcNow;   

        try{
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();            
        }catch(DbUpdateConcurrencyException){
            return Conflict("Concurrency error: user is modified or deleted");
        }        
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return NotFound();
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
