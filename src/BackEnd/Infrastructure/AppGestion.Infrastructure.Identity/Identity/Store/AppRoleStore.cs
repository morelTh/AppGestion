using AppGestion.Domain.Entities;
using AppGestion.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AppGestion.Infrastructure.Identity.Identity.Store;

public class AppRoleStore : RoleStore<Role,ApplicationDbContext,int,UserRole,RoleClaim>
{
    public AppRoleStore(ApplicationDbContext context, IdentityErrorDescriber? describer = null) : base(context, describer)
    {
    }
}