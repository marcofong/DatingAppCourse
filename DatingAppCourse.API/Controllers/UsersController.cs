using DatingAppCourse.API.Data;
using DatingAppCourse.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingAppCourse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(DataContext dataContext) : ControllerBase
    {
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await dataContext.Users.ToListAsync();
            return users;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var user = await dataContext.Users.FindAsync(id);
            if (user == null) return NotFound();
            return user;
        }

    }
}
