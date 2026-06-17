using Core.Models;

namespace DAL.Interfaces;

public interface ICartRepository : IRepository<Cart>
{
    Task<IEnumerable<Cart>> GetCartByUserIdAsync(Guid userId);
}