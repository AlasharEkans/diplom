using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BL.DTO;
using BL.Services.Interfaces;
using Core.Models;
using DAL.Interfaces;

namespace BL.Services;

public class CourseService(IUnitOfWork unitOfWork, IMapper mapper) : ICourseService
{
    public async Task<IEnumerable<CourseDTO>> GetAllCoursesAsync()
    {
        var courses = await unitOfWork.Courses.GetAllAsync();
        return mapper.Map<IEnumerable<CourseDTO>>(courses);
    }

    public async Task<CourseDTO?> GetCourseByIdAsync(Guid id)
    {
        var course = await unitOfWork.Courses.GetByIdAsync(id);
        return mapper.Map<CourseDTO>(course);
    }

    public async Task AddCourseAsync(CourseDTO courseDto)
    {
        var course = mapper.Map<Course>(courseDto);
        await unitOfWork.Courses.AddAsync(course);
        await unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateCourseAsync(CourseDTO courseDto)
    {
        var course = mapper.Map<Course>(courseDto);
        unitOfWork.Courses.Update(course);
        await unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteCourseAsync(Guid id)
    {
        var course = await unitOfWork.Courses.GetByIdAsync(id);
        if (course != null)
        {
            unitOfWork.Courses.Delete(course);
            await unitOfWork.SaveChangesAsync();
        }
    }
}