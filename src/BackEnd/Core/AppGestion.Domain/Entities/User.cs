using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AppGestion.Domain.Entities;

public class User : IdentityUser<int>,ITimeModification,IEntity
{
    [MaxLength(75)]
    public string? Name { get; set; }
    [MaxLength(45)]
    public string? FamilyName { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime? ModifiedDate { get; set; }
    
    #region Navigation Properties
    public virtual ICollection<UserClaim>? Claims { get; set; }
    public virtual ICollection<UserLogin>? Logins { get; set; }
    public virtual ICollection<UserToken>? Tokens { get; set; }
    public virtual ICollection<UserRole>? UserRoles { get; set; }
    public virtual ICollection<UserRefreshToken>? UserRefreshTokens { get; set; }
    //public IList<Order.Order> Orders { get; set; }
    #endregion
}