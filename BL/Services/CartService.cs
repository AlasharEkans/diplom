using AutoMapper;
using BL.DTO;
using BL.Services.Interfaces;
using Core.Enums;
using Core.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Services;

public class CartService(IUnitOfWork unitOfWork, IMapper mapper) : ICartService
{
    public async Task<IEnumerable<CartDTO>> GetCartByUserIdAsync(Guid userId)
    {
        var items = await unitOfWork.Carts.GetCartByUserIdAsync(userId);
        return mapper.Map<IEnumerable<CartDTO>>(items);
    }

    public async Task AddToCartAsync(Guid userId, Guid courseId)
    {
        var existingItems = await unitOfWork.Carts.GetCartByUserIdAsync(userId);
        if (existingItems.Any(i => i.CourseId == courseId))
        {
            return;
        }

        var cart = new Cart
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            CourseId = courseId
        };

        await unitOfWork.Carts.AddAsync(cart);
        await unitOfWork.SaveChangesAsync();
    }

    public async Task RemoveFromCartAsync(Guid cartId)
    {
        var cart = await unitOfWork.Carts.GetByIdAsync(cartId);
        if (cart != null)
        {
            unitOfWork.Carts.Delete(cart);
            await unitOfWork.SaveChangesAsync();
        }
    }

    public async Task ClearCartAsync(Guid userId)
    {
        var items = await unitOfWork.Carts.GetCartByUserIdAsync(userId);
        foreach (var item in items)
        {
            unitOfWork.Carts.Delete(item);
        }
        await unitOfWork.SaveChangesAsync();
    }
}