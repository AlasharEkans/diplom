namespace PL.Angular.Models
{
    public class CreateCourseModel
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public Guid UserId { get; set; }
    }
}
