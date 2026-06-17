using System;
using System.Threading.Tasks;

namespace DAL.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ICourseRepository Courses { get; }
    IStudentsRepository Students { get; }
    IEnrollmentsRepository Enrollments { get; }
    IEnrollmentCoursesRepository EnrollmentCourses { get; }
    ICartRepository Carts { get; }
    IUserRepository Users { get; }
    Task<int> SaveChangesAsync();
}