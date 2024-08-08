using Microsoft.AspNetCore.Identity;

namespace AppGestion.Domain.Entities;

public class RoleClaim : IdentityRoleClaim<int>, ITimeModification,IEntity
{
    public DateTime CreatedTime { get; set; }
    public DateTime? ModifiedDate { get; set; }
    
    #region Navigation Properties
    public virtual Role? Role { get; set; }
    #endregion

    
}