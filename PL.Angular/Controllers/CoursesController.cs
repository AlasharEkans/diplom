using AutoMapper;
using BL.DTO;
using BL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PL.Angular.Models;

namespace PL.Angular.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController(ICourseService courseService) : ControllerBase
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
        {
            return NotFound();
        }
        return Ok(course);
    }
}
