using AppGestion.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AppGestion.Infrastructure.Identity.Identity.Validator;

public class AppUserValidator : UserValidator<User>
{
    public AppUserValidator(IdentityErrorDescriber errors):base(errors)
    {
            
    }
    public override async Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
    {
        var result = await base.ValidateAsync(manager, user);
        return result;
    }
}