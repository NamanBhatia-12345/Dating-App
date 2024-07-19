using DatingApp.API.Data;
using DatingApp.API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers;

[Authorize]
public class UsersController(DataContext context) : BaseApiController
{
    private readonly DataContext _context = context;

    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()  //=> api/users
    {
        var users = await _context.Users.ToListAsync();
        return Ok(users);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<AppUser>> GetUsersById(int id) //=> api/users/1
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        if(user == null)  return NotFound();
        return Ok(user);
    }

}
