using AppGestion.Application.Contracts.Persistence;
using AppGestion.Infrastructure.Persistence.Repositories.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppGestion.Infrastructure.Persistence.ServiceConfiguration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        // services.AddDbContext<ApplicationDbContext>(options =>
        // {
        //     options
        //         .UseSqlServer(configuration.GetConnectionString("SqlServer"));
        // });

        return services;
    }
    
}