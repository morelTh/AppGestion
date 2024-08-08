using AppGestion.Application.Contracts.Identity;
using AppGestion.Domain.Entities;
using AppGestion.Infrastructure.Identity.Identity.Manager;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AppGestion.Infrastructure.Identity.Identity.UserManager;

public class AppUserManagerImplementation : IAppUserManagerService
{
    private readonly AppUserManager _userManager;

    public AppUserManagerImplementation(AppUserManager userManager)
    {
        _userManager = userManager;
    }

    public async Task<IdentityResult> CreateUser(User user) => await _userManager.CreateAsync(user);

    public async Task<IdentityResult> CreateUserWithPasswordAsync(User user, string password) => await _userManager.CreateAsync(user, password);

    public async Task<IdentityResult> AddUserToRoleAsync(User user, Role role)
    {
        return await _userManager.AddToRoleAsync(user, role.Name!);
    }

    public async Task<User?> GetByUserName(string userName)
    {
        return await _userManager.FindByNameAsync(userName);
    }

    public async Task<User?> GetUserByIdAsync(int userId)
    {
        return await _userManager.FindByIdAsync(userId.ToString());
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _userManager.Users.AsNoTracking().ToListAsync();
    }

    public async Task UpdateUserAsync(User user)
    {
        await _userManager.UpdateAsync(user);
    }
}