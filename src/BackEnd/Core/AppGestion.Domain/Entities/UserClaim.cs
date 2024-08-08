using Microsoft.AspNetCore.Identity;

namespace AppGestion.Domain.Entities;

public class UserClaim : IdentityUserClaim<int>, IEntity
{
    #region Navigation Properties
    public virtual User? User { get; set; }
    #endregion
}