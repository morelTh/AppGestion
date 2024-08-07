using AppGestion.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AppGestion.Application.Contracts.Identity;

public interface IAppRoleManager
{
    Task<IdentityResult> CreateRoleAsync(Role role);
    Task<List<Role>> GetRolesAsync();
    Task<Role> GetRoleByIdAsync(int roleId);
    Task<bool> DeleteRoleAsync(int roleId);
}