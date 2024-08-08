using AppGestion.Application.Contracts.Persistence;
using AppGestion.Infrastructure.Persistence.Repositories.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace AppGestion.Infrastructure.Persistence.ServiceConfiguration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options
                .UseSqlite(configuration.GetConnectionString("Sqlite"));
        });

        return services;
    }
    
    public static async Task ApplyMigrationsAsync(this WebApplication app)
    {
        await using var scope = app.Services.CreateAsyncScope();
        var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

        if (context is null)
            throw new Exception("Database Context Not Found");

        await context.Database.MigrateAsync();
    }
}