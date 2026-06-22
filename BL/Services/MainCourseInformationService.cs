using AutoMapper;
using BL.DTO;
using BL.Services.Interfaces;
using Core.Models;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Enums;

namespace BL.Services;

public class MainCourseInformationService(IUnitOfWork unitOfWork) : IMainCourseInformationService
{
    public async Task<MainCourseInformationDTO> GetMainInformationAsync()
    {
        var courses = await unitOfWork.Courses.GetAllAsync();
        var enrollments = await unitOfWork.Enrollments.GetAllAsync();
        var enrollmentsList = enrollments.ToList();

        return new MainCourseInformationDTO
        {
            TotalCoursesCount = courses.Count(),
            ActiveStudentsCount = enrollmentsList
                .Where(e => e.Status == EnrollmentStatus.Active)
                .Select(e => e.StudentId)
                .Distinct()
                .Count(),
            CompletedEnrollmentsCount = enrollmentsList.Count(e => e.Status == EnrollmentStatus.Completed)
        };
    }
}