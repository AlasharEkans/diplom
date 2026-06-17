using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Angular.Models
{
    public class EnrollmentModel
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public string EnrolledAt { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public IEnumerable<EnrolledCourse> Courses { get; set; } = new List<EnrolledCourse>();
    }
}
