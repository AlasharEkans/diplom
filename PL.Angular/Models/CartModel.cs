
namespace PL.Angular.Models
{
    public class CartModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CourseId { get; set; }
        public CourseModel? Course { get; set; }
    }
}
