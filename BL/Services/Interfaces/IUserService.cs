using BL.DTO;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Core.Enums;

namespace BL.Services.Interfaces;

public interface IUserService
{
    Task<UserDTO?> AuthenticateAsync(string email, string password);
    Task<UserDTO> RegisterAsync(string email, string password, string firstName, string lastName);
    Task<UserDTO?> GetByIdAsync(Guid id);
    Task<IEnumerable<UserDTO>> GetAllUsersAsync();
}
