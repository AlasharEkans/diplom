using System;
using System.Collections.Generic;

namespace BL.DTO;

public class CartDTO
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid CourseId { get; set; }
    public CourseDTO? Course { get; set; }
}