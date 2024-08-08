using AppGestion.Application.Contracts.Identity;
using AppGestion.Domain.Entities;
using AppGestion.Infrastructure.Identity.Identity.Manager;
using AppGestion.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AppGestion.Infrastructure.Identity.Identity.PermissionManager;

public class RoleManagerService : IAppRoleManagerService
{
    private readonly AppRoleManager _roleManger;
    private readonly AppUserManager _userManager;
    private readonly ApplicationDbContext _db;

    public RoleManagerService(AppRoleManager roleManger, AppUserManager userManager, ApplicationDbContext db)
    {
        _roleManger = roleManger;
        _userManager = userManager;
        _db = db;
    }

    public async Task<IdentityResult> CreateRoleAsync(Role role)
    {
        var result = await _roleManger.CreateAsync(role);
        return result;
    }

    public async Task<List<Role>> GetRolesAsync()
    {
        var result = await _roleManger.Roles.Where(c => !c.Name!.Equals("admin")).ToListAsync();
        return result;
    }

    public async Task<Role?> GetRoleByIdAsync(int roleId)
    {
        return await _roleManger.FindByIdAsync(roleId.ToString());
    }

    public async Task<bool> DeleteRoleAsync(int roleId)
    {
        var role = await _roleManger.Roles.Include(r => r.RoleClaims)
            .Include(r => r.UserRoles).FirstOrDefaultAsync(r => r.Id == roleId);
        
        if (role == null)
            return false;

        var users = await _userManager.GetUsersInRoleAsync(role.Name!);

        foreach (var user in users)
        {
            await _userManager.RemoveFromRoleAsync(user, role.Name!);
            await _userManager.UpdateSecurityStampAsync(user);
        }

        _db.RemoveRange(role.UserRoles!);
        _db.RemoveRange(role.UserRoles!);
        _db.Remove(role);
        await _db.SaveChangesAsync();

        return true;
    }
}