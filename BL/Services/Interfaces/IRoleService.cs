using Core.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.Services.Interfaces;

public interface IRoleService
{
    Task<IEnumerable<string>> GetAvailableRolesAsync();
    bool IsInRole(Role userRole, Role requiredRole);
}