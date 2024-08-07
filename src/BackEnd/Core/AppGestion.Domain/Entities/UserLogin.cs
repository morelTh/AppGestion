using Microsoft.AspNetCore.Identity;

namespace AppGestion.Domain.Entities;

public class UserLogin : IdentityUserLogin<int>,IEntity
{
    public UserLogin()
    {
        LoggedOn=DateTime.Now;
    }

    public User User { get; set; }
    public DateTime LoggedOn { get; set; }
}