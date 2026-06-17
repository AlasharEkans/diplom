using Core.Enums;
using System;
using System.Collections.Generic;

namespace Core.Models
{
	public class Enrollment 
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public virtual Student? Student { get; set; }
        public DateTime EnrolledAt { get; set; }
        public EnrollmentStatus Status { get; set; }
        public virtual ICollection<EnrollmentCourse> EnrollmentCourses { get; set; } = new List<EnrollmentCourse>();
    }
}
