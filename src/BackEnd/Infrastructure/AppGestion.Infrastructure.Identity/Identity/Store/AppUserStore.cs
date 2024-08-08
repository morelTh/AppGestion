using AppGestion.Domain.Entities;
using AppGestion.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AppGestion.Infrastructure.Identity.Identity.Store;

public class AppUserStore : UserStore<User,Role,ApplicationDbContext,int,UserClaim,UserRole,UserLogin,UserToken,RoleClaim>
{
    public AppUserStore(ApplicationDbContext context, IdentityErrorDescriber? describer = null) : base(context, describer)
    {
    }
}