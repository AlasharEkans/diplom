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

public class UserService(IUnitOfWork unitOfWork, IMapper mapper, IPasswordService passwordService) : IUserService
{
    public async Task<UserDTO?> AuthenticateAsync(string email, string password)
    {
        var user = await unitOfWork.Users.GetByEmailAsync(email);
        if (user == null || !passwordService.VerifyPassword(password, user.PasswordHash))
        {
            return null;
        }
        return mapper.Map<UserDTO>(user);
    }

    public async Task<UserDTO> RegisterAsync(string email, string password, string firstName, string lastName)
    {
        var existingUser = await unitOfWork.Users.GetByEmailAsync(email);
        if (existingUser != null)
        {
            throw new InvalidOperationException("User with this email already exists.");
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = email,
            PasswordHash = passwordService.HashPassword(password),
            Role = Role.Student
        };

        await unitOfWork.Users.AddAsync(user);

        var student = new Student
        {
            Id = Guid.NewGuid(),
            FirstName = firstName,
            LastName = lastName,
            UserId = user.Id
        };

        await unitOfWork.Students.AddAsync(student);
        await unitOfWork.SaveChangesAsync();

        return mapper.Map<UserDTO>(user);
    }

    public async Task<UserDTO> RegisterTeacherAsync(string email, string password, string firstName, string lastName)
    {
        var existingUser = await unitOfWork.Users.GetByEmailAsync(email);
        if (existingUser != null)
            throw new InvalidOperationException("User with this email already exists.");

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = email,
            PasswordHash = passwordService.HashPassword(password),
            Role = Role.Teacher
        };

        await unitOfWork.Users.AddAsync(user);
        await unitOfWork.SaveChangesAsync();

        return mapper.Map<UserDTO>(user);
    }

    public async Task<UserDTO?> GetByIdAsync(Guid id)
    {
        var user = await unitOfWork.Users.GetByIdAsync(id);
        return mapper.Map<UserDTO>(user);
    }

    public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
    {
        var users = await unitOfWork.Users.GetAllAsync();
        return mapper.Map<IEnumerable<UserDTO>>(users);
    }
}