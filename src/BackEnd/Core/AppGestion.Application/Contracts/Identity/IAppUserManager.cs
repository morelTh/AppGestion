using AppGestion.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AppGestion.Application.Contracts.Identity;

public interface IAppUserManager
{
    Task<IdentityResult> CreateUser(User user);
    Task<IdentityResult> CreateUserWithPasswordAsync(User user,string password);
    Task<IdentityResult> AddUserToRoleAsync(User user, Role role);
    Task<User> GetByUserName(string userName);
    Task<User> GetUserByIdAsync(int userId);
    Task<List<User>> GetAllUsersAsync();
    Task UpdateUserAsync(User user);
}