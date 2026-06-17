using AutoMapper;
using BL.DTO;
using BL.Services.Interfaces;
using Core.Models;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Services;

public class MainCourseInformationService(IUnitOfWork unitOfWork) : IMainCourseInformationService
{
    public async Task<MainCourseInformationDTO> GetMainInformationAsync()
    {
        var courses = await unitOfWork.Courses.GetAllAsync();
        var students = await unitOfWork.Students.GetAllAsync();
        var enrollments = await unitOfWork.Enrollments.GetAllAsync();

        return new MainCourseInformationDTO
        {
            TotalCoursesCount = courses.Count(),
            ActiveStudentsCount = students.Count(),
            CompletedEnrollmentsCount = enrollments.Count(e => e.Status == EnrollmentStatus.Completed)
        };
    }
}