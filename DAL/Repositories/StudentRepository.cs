using Core.Models;
using DAL.Data;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories;

public class StudentRepository(EducationContext context) : Repository<Student>(context), IStudentsRepository
{
    public async Task<Student?> GetStudentByUserIdAsync(Guid userId)
    {
        return await Context.Students
            .Include(s => s.User)
            .Include(s => s.Enrollments)
            .FirstOrDefaultAsync(s => s.UserId == userId);
    }
}