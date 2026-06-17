using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class EnrollmentCourse
    {
        public Guid EnrollmentId { get; set; }
        public virtual Enrollment? Enrollment { get; set; }
        public Guid CourseId { get; set; }
        public virtual Course? Course { get; set; }
    }
}
