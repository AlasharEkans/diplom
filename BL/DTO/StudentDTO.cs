using System;

namespace BL.DTO;

public class StudentDTO
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Guid UserId { get; set; }
}