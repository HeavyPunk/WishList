using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Wishlist.Entities;
using Wishlist.Models;

namespace Wishlist.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterModel registerModel)
    {
        if (!ModelState.IsValid)
            return BadRequest("Login or password has invalid format");
        var user = new User
        {
            Id = Guid.NewGuid(),
            UserName = registerModel.Login,
            Email = registerModel.Email
        };
        var result = await _userManager.CreateAsync(user);
        if (!result.Succeeded)
            return BadRequest();
        await _signInManager.SignInAsync(user, false);
        return Ok();
    }
    
    [HttpPost("auth")]
    public IActionResult Authenticate()
    {
        throw new NotImplementedException();
    }

    [HttpGet("logout")]
    public IActionResult Logout()
    {
        throw new NotImplementedException();
    }
}