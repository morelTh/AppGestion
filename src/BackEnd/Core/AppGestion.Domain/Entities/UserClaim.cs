using Microsoft.AspNetCore.Identity;

namespace AppGestion.Domain.Entities;

public class UserClaim : IdentityUserClaim<int>, IEntity
{
    public User? User { get; set; }
}