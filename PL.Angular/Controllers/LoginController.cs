using Microsoft.AspNetCore.Mvc;
using PL.Angular.Models;
using BL.Services.Interfaces;

namespace PL.Angular.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController(IUserService userService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userService.AuthenticateAsync(model.Email, model.Password);
            if (user == null)
            {
                return Unauthorized("Invalid email or password.");
            }
            return Ok(user);
        }
    }
}