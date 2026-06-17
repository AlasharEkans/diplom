using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BL.DTO;
using BL.Services.Interfaces;
using Core.Enums;
using Core.Models;
using DAL.Interfaces;

namespace BL.Services;

public class EnrollmentService(IUnitOfWork unitOfWork, IMapper mapper) : IEnrollmentService
{
    public async Task<EnrollmentDTO> CreateEnrollmentAsync(Guid userId, IEnumerable<Guid> courseIds)
    {
        var student = await unitOfWork.Students.GetStudentByUserIdAsync(userId);
        if (student == null)
        {
            throw new InvalidOperationException("Student profile not found.");
        }

        var enrollment = new Enrollment
        {
            Id = Guid.NewGuid(),
            StudentId = student.Id,
            EnrolledAt = DateTime.UtcNow,
            Status = EnrollmentStatus.Requested
        };

        await unitOfWork.Enrollments.AddAsync(enrollment);

        foreach (var courseId in courseIds)
        {
            var enrollmentCourse = new EnrollmentCourse
            {
                EnrollmentId = enrollment.Id,
                CourseId = courseId
            };
            await unitOfWork.EnrollmentCourses.AddAsync(enrollmentCourse);
        }

        await unitOfWork.SaveChangesAsync();

        var result = await unitOfWork.Enrollments.GetByIdAsync(enrollment.Id);
        return mapper.Map<EnrollmentDTO>(result);
    }

    public async Task<IEnumerable<EnrollmentDTO>> GetStudentEnrollmentsAsync(Guid userId)
    {
        var student = await unitOfWork.Students.GetStudentByUserIdAsync(userId);
        if (student == null)
        {
            return Enumerable.Empty<EnrollmentDTO>();
        }

        var enrollments = await unitOfWork.Enrollments.GetEnrollmentsByStudentIdAsync(student.Id);
        return mapper.Map<IEnumerable<EnrollmentDTO>>(enrollments);
    }

    public async Task UpdateStatusAsync(Guid enrollmentId, EnrollmentStatus status)
    {
        var enrollment = await unitOfWork.Enrollments.GetByIdAsync(enrollmentId);
        if (enrollment != null)
        {
            enrollment.Status = status;
            unitOfWork.Enrollments.Update(enrollment);
            await unitOfWork.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<EnrollmentDTO>> GetAllEnrollmentsAsync()
    {
        var enrollments = await unitOfWork.Enrollments.GetAllAsync();
        return mapper.Map<IEnumerable<EnrollmentDTO>>(enrollments);
    }
}