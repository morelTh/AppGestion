using Microsoft.AspNetCore.Identity;

namespace AppGestion.Domain.Entities;

public class UserToken : IdentityUserToken<int>, IEntity
{
    public UserToken()
    {
        GeneratedTime=DateTime.Now;
    }

    public User User { get; set; }
    public DateTime GeneratedTime { get; set; }
}