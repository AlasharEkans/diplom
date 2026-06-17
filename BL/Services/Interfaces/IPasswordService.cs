using Core.Enums;

namespace BL.Services.Interfaces;

public interface IPasswordService
{
    string HashPassword(string password);
    bool VerifyPassword(string password, string hashedPassword);
    PasswordStrength CheckStrength(string password);
}