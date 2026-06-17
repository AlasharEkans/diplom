using Core.Enums;
using System;

namespace BL.DTO;

public class UserDTO
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public Role Role { get; set; }
}