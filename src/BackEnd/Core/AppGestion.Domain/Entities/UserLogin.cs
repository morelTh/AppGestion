using Microsoft.AspNetCore.Identity;

namespace AppGestion.Domain.Entities;

public class UserLogin : IdentityUserLogin<int>,IEntity
{
    public UserLogin() => LoggedOn=DateTime.Now;
    public DateTime LoggedOn { get; set; }
    
    #region Navigation Properties
    public virtual User? User { get; set; }
    #endregion
}