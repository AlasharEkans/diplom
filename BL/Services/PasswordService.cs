using BL.Services.Interfaces;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace BL.Services;

public class PasswordService : IPasswordService
{
    public string HashPassword(string password)
    {
        return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        var hash = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        return hash == hashedPassword;
    }

    public PasswordStrength CheckStrength(string password)
    {
        if (string.IsNullOrEmpty(password)) return PasswordStrength.None;
        if (password.Length < 4) return PasswordStrength.VeryWeak;
        if (password.Length < 8) return PasswordStrength.Weak;
        if (password.Any(char.IsUpper) && password.Any(char.IsDigit)) return PasswordStrength.Strong;
        return PasswordStrength.Medium;
    }
}