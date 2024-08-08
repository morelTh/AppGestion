using Microsoft.AspNetCore.Identity;

namespace AppGestion.Domain.Entities;

public class UserRole : IdentityUserRole<int>, IEntity
{
    public DateTime CreatedUserRoleDate { get; set; }
    
    #region Navigation Properties
    public virtual User? User { get; set; }
    public virtual Role? Role { get; set; }
    #endregion
}