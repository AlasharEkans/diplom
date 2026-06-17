using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BL.DTO;

namespace BL.Services.Interfaces;

public interface ICourseService
{
    Task<IEnumerable<CourseDTO>> GetAllCoursesAsync();
    Task<CourseDTO?> GetCourseByIdAsync(Guid id);
    Task AddCourseAsync(CourseDTO courseDto);
    Task UpdateCourseAsync(CourseDTO courseDto);
    Task DeleteCourseAsync(Guid id);
}