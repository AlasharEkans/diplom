using Core.Models;
using DAL.Data;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class CartRepository(EducationContext context) : Repository<Cart>(context), ICartRepository
{
    public async Task<IEnumerable<Cart>> GetCartByUserIdAsync(Guid userId)
    {
        return await Context.Carts
            .Include(c => c.Course)
            .Where(c => c.UserId == userId)
            .ToListAsync();
    }
}