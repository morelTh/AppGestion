using Microsoft.AspNetCore.Identity;

namespace AppGestion.Domain.Entities;

public class UserRole : IdentityUserRole<int>, IEntity
{
    public User User { get; set; }
    public Role Role { get; set; }
    public DateTime CreatedUserRoleDate { get; set; }
}