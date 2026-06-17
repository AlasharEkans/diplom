using System;

namespace Core.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public virtual User? User { get; set; }
        public Guid CourseId { get; set; }
        public virtual Course? Course { get; set; }
    }
}
