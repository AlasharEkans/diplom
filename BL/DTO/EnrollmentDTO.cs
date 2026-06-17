using Core.Enums;
using System;
using System.Collections.Generic;

namespace BL.DTO;

public class EnrollmentDTO
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public DateTime EnrolledAt { get; set; }
    public EnrollmentStatus Status { get; set; }
    public IEnumerable<CourseDTO> Courses { get; set; } = new List<CourseDTO>();
}