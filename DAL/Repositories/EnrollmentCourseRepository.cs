using Core.Models;
using DAL.Data;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories;

public class EnrollmentCourseRepository(EducationContext context) : Repository<EnrollmentCourse>(context), IEnrollmentCoursesRepository
{
}