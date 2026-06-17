using Core.Models;
using DAL.Data;
using DAL.Interfaces;

namespace DAL.Repositories;

public class UserRepository(EducationContext context) : Repository<User>(context), IUserRepository
{
    public async Task<User?> GetByEmailAsync(string email)
    {
        return await Context.Users
            .FirstOrDefaultAsync(u => u.Email == email);
    }
}