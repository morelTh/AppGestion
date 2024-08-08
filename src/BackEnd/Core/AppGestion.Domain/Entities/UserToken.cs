using Microsoft.AspNetCore.Identity;

namespace AppGestion.Domain.Entities;

public class UserToken : IdentityUserToken<int>, IEntity
{
    public DateTime GeneratedTime { get; set; }
    
    #region Navigation Properties
    public virtual User? User { get; set; }
    #endregion
}