using System.Security.Cryptography;
using System.Text;
using DatingAppCourse.API.Data;
using DatingAppCourse.API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DatingAppCourse.API.Controllers;

public class AccountController(DataContext context) : BaseApiController
{
    [HttpPost("register")] //account/register
    public async Task<ActionResult<AppUser>> Register(string username, string password)
    {
        using var hmac = new HMACSHA512();

        var user = new AppUser
        {
            Username = username,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
            PasswordSalt = hmac.Key
        };

        context.Users.Add(user);
        await context.SaveChangesAsync();

        return user;
    }
}