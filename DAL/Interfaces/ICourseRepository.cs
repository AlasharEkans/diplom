using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;

namespace DAL.Interfaces;

public interface ICourseRepository : IRepository<Course>
{
    Task<IEnumerable<Course>> GetCoursesWithDetailsAsync();
}