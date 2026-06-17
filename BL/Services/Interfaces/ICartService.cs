using BL.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Services.Interfaces;

public interface ICartService
{
    Task<IEnumerable<CartDTO>> GetCartByUserIdAsync(Guid userId);
    Task AddToCartAsync(Guid userId, Guid courseId);
    Task RemoveFromCartAsync(Guid cartId);
    Task ClearCartAsync(Guid userId);
}