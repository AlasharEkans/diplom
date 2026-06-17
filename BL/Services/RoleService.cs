using BL.Services.Interfaces;
using Core.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Services;

public class RoleService : IRoleService
{
    public Task<IEnumerable<string>> GetAvailableRolesAsync()
    {
        var roles = Enum.GetNames(typeof(Role)).AsEnumerable();
        return Task.FromResult(roles);
    }

    public bool IsInRole(Role userRole, Role requiredRole)
    {
        return userRole == requiredRole;
    }
}