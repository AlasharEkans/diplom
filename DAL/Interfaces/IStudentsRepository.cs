using Core.Models;
using System;
using System.Threading.Tasks;

namespace DAL.Interfaces;

public interface IStudentsRepository : IRepository<Student>
{
    Task<Student?> GetStudentByUserIdAsync(Guid userId);
}