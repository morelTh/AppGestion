using AppGestion.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AppGestion.Infrastructure.Identity.Identity.Validator;

public class AppRoleValidator : RoleValidator<Role>
{
    public AppRoleValidator(IdentityErrorDescriber errors) : base(errors)
    {
        
    }

    public override Task<IdentityResult> ValidateAsync(RoleManager<Role> manager, Role role)
    {
        var result = base.ValidateAsync(manager, role);
        return result;
    }
}