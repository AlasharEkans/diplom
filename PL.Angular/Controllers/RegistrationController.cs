using Microsoft.AspNetCore.Mvc;
using PL.Angular.Models;
using BL.Services.Interfaces;
using BL.DTO;

namespace PL.Angular.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistrationController(IUserService userService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            try
            {
                var user = await userService.RegisterAsync(model.Email, model.Password, model.FirstName, model.LastName);
                return Ok(user);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("teacher")]
        public async Task<IActionResult> RegisterTeacher([FromBody] RegisterTeacherModel model)
        {
            const string validCode = "TEACHER2025";
            if (model.AccessCode != validCode)
                return BadRequest("Невірний код доступу викладача.");

            try
            {
                var user = await userService.RegisterTeacherAsync(model.Email, model.Password, model.FirstName, model.LastName);
                return Ok(user);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
