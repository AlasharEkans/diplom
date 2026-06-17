using BL.DTO;
using BL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PL.Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Angular.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController(ICartService cartService) : ControllerBase
    {
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<CartDTO>>> GetCart(Guid userId)
        {
            var items = await cartService.GetCartByUserIdAsync(userId);
            return Ok(items);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddToCart([FromBody] CartRequestModel request)
        {
            await cartService.AddToCartAsync(request.UserId, request.CourseId);
            return Ok();
        }

        [HttpDelete("remove/{cartId}")]
        public async Task<IActionResult> RemoveFromCart(Guid cartId)
        {
            await cartService.RemoveFromCartAsync(cartId);
            return Ok();
        }

        [HttpDelete("clear/{userId}")]
        public async Task<IActionResult> ClearCart(Guid userId)
        {
            await cartService.ClearCartAsync(userId);
            return Ok();
        }
    }