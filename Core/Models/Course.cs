using System;
using System.Collections.Generic;

namespace Core.Models
{
	public class Course
	{
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public virtual ICollection<EnrollmentCourse> EnrollmentCourses { get; set; } = new List<EnrollmentCourse>();

    }
}
