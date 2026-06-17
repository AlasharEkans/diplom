using System.ComponentModel.DataAnnotations;

namespace PL.Angular.Models
{
    public class MainCourseInformation
    {
        public int TotalCoursesCount { get; set; }
        public int ActiveStudentsCount { get; set; }
        public int CompletedEnrollmentsCount { get; set; }
    }
}
