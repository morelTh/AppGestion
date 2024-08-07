using Microsoft.AspNetCore.Identity;

namespace AppGestion.Domain.Entities;

public class RoleClaim : IdentityRoleClaim<int>,IEntity
{
    public RoleClaim()
    {
        CreatedClaim=DateTime.Now;
    }

    public DateTime CreatedClaim { get; set; }
    public Role Role { get; set; }
}