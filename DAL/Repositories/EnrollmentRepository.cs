using Core.Models;
using DAL.Data;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories;

public class EnrollmentRepository(EducationContext context) : Repository<Enrollment>(context), IEnrollmentsRepository
{
    public async Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentIdAsync(Guid studentId)
    {
        return await Context.Enrollments
            .Include(e => e.EnrollmentCourses)
                .ThenInclude(ec => ec.Course)
            .Where(e => e.StudentId == studentId)
            .ToListAsync();
    }
}