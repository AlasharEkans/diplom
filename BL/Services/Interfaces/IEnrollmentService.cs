using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BL.DTO;
using Core.Enums;

namespace BL.Services.Interfaces;

public interface IEnrollmentService
{
    Task<EnrollmentDTO> CreateEnrollmentAsync(Guid userId, IEnumerable<Guid> courseIds);
    Task<IEnumerable<EnrollmentDTO>> GetStudentEnrollmentsAsync(Guid userId);
    Task UpdateStatusAsync(Guid enrollmentId, EnrollmentStatus status);
    Task<IEnumerable<EnrollmentDTO>> GetAllEnrollmentsAsync();
}