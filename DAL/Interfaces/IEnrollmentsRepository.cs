using Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces;

public interface IEnrollmentsRepository : IRepository<Enrollment>
{
    Task<IEnumerable<Enrollment>> GetEnrollmentsByStudentIdAsync(Guid studentId);
}