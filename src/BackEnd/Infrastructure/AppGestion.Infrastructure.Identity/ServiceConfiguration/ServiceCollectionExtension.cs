using AppGestion.Domain.Entities;
using AppGestion.Infrastructure.Identity.Identity.Dtos;
using AppGestion.Infrastructure.Identity.Identity.Manager;
using AppGestion.Infrastructure.Identity.Identity.SeedDatabaseService;
using AppGestion.Infrastructure.Identity.Identity.Store;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace AppGestion.Infrastructure.Identity.ServiceConfiguration;

public static class ServiceCollectionExtension
{
    public static IServiceCollection RegisterIdentityServices(this IServiceCollection services, IdentitySettings identitySettings)
    {
        
        //Identity
        services.AddIdentity<User, Role>(options =>
        {
            options.Stores.ProtectPersonalData = false;

            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredUniqueChars = 0;
            options.Password.RequireUppercase = false;

            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;

            options.Lockout.MaxFailedAccessAttempts = 10;
            options.Lockout.AllowedForNewUsers = false;
            options.User.RequireUniqueEmail = false;
        }).AddUserStore<AppUserStore>()
        .AddRoleStore<AppRoleStore>()
        .AddUserManager<AppUserManager>()
        .AddRoleManager<AppRoleManager>()
        .AddSignInManager<AppSignInManager>()
        .AddDefaultTokenProviders();
        return services;
    }
    
    public static async Task SeedDefaultUsersAsync(this WebApplication app)
    {
        // await using var scope = app.Services.CreateAsyncScope();
        //
        // var seedService = scope.ServiceProvider.GetRequiredService<ISeedDataBase>();
        // await seedService.Seed();
    }
}