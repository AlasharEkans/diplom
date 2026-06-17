using System;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Interfaces;

namespace DAL.Repositories;

public class UnitOfWork(EducationContext context) : IUnitOfWork
{
    private readonly EducationContext _context = context;
    private ICourseRepository? _courses;
    private IStudentsRepository? _students;
    private IEnrollmentsRepository? _enrollments;
    private IEnrollmentCoursesRepository? _enrollmentCourses;
    private ICartRepository? _carts;
    private IUserRepository? _users;

    public ICourseRepository Courses => _courses ??= new CourseRepository(_context);
    public IStudentsRepository Students => _students ??= new StudentRepository(_context);
    public IEnrollmentsRepository Enrollments => _enrollments ??= new EnrollmentRepository(_context);
    public IEnrollmentCoursesRepository EnrollmentCourses => _enrollmentCourses ??= new EnrollmentCourseRepository(_context);
    public ICartRepository Carts => _carts ??= new CartRepository(_context);
    public IUserRepository Users => _users ??= new UserRepository(_context);

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}