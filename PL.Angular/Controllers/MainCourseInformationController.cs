using AutoMapper;
using BL.DTO;
using BL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PL.Angular.Models;

namespace PL.Angular.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MainCourseInformationController(IMainCourseInformationService infoService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<MainCourseInformationDTO>> GetMainInformation()
        {
            var info = await infoService.GetMainInformationAsync();
            return Ok(info);
        }
    }
}
