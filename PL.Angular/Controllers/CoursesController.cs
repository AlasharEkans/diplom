using BL.DTO;
using BL.Services.Interfaces;
using Core.Enums;
using Microsoft.AspNetCore.Mvc;
using PL.Angular.Models;

namespace PL.Angular.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController(ICourseService courseService, IUserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CourseDTO>>> GetCourses()
    {
        var courses = await courseService.GetAllCoursesAsync();
        return Ok(courses);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CourseDTO>> GetCourse(Guid id)
    {
        var course = await courseService.GetCourseByIdAsync(id);
        if (course == null)
            return NotFound();
        return Ok(course);
    }

    [HttpPost]
    public async Task<ActionResult<CourseDTO>> CreateCourse([FromBody] CreateCourseModel model)
    {
        var user = await userService.GetByIdAsync(model.UserId);
        if (user == null || user.Role != Role.Teacher)
            return Forbid();

        var courseDto = new CourseDTO
        {
            Title = model.Title,
            Description = model.Description,
            Author = model.Author,
            ImageName = model.ImageName
        };

        var created = await courseService.AddCourseAsync(courseDto);
        return Ok(created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCourse(Guid id, [FromBody] UpdateCourseModel model)
    {
        var user = await userService.GetByIdAsync(model.UserId);
        if (user == null || user.Role != Role.Teacher)
            return Forbid();

        var courseDto = new CourseDTO
        {
            Id = id,
            Title = model.Title,
            Description = model.Description,
            Author = model.Author,
            ImageName = model.ImageName
        };

        await courseService.UpdateCourseAsync(courseDto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourse(Guid id, [FromQuery] Guid userId)
    {
        var user = await userService.GetByIdAsync(userId);
        if (user == null || user.Role != Role.Teacher)
            return Forbid();

        await courseService.DeleteCourseAsync(id);
        return Ok();
    }
}
