using Core.Models;
using DAL.Data;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories;

public class CourseRepository(EducationContext context) : Repository<Course>(context), ICourseRepository
{
    public async Task<IEnumerable<Course>> GetCoursesWithDetailsAsync()
    {
        return await Context.Courses
            .Include(c => c.EnrollmentCourses)
            .ToListAsync();
    }
}