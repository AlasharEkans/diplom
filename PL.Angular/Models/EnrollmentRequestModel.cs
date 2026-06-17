namespace PL.Angular.Models
{
    public class EnrollmentRequestModel
    {
        public Guid UserId { get; set; }
        public IEnumerable<Guid> CourseIds { get; set; } = new List<Guid>();
    }
}