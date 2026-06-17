using System;

namespace Core.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
