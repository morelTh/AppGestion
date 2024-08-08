using Microsoft.AspNetCore.Identity;

namespace AppGestion.Domain.Entities;

public class Role : IdentityRole<int>, ITimeModification,IEntity
{
    public DateTime CreatedTime { get; set; }
    public DateTime? ModifiedDate { get; set; }
    
    #region Navigation Properties
    public virtual ICollection<UserRole>? UserRoles { get; set; }
    public virtual ICollection<RoleClaim>? RoleClaims { get; set; }
    #endregion
}