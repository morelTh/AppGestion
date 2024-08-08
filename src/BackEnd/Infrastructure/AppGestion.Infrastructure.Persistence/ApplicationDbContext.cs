using AppGestion.Domain.Entities;
using AppGestion.Infrastructure.Persistence.Configuration.Identity;
using AppGestion.Infrastructure.Persistence.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppGestion.Infrastructure.Persistence;

public class ApplicationDbContext : IdentityDbContext<User,  Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        base.SavingChanges += OnSavingChanges!;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        var entitiesAssembly = typeof(IEntity).Assembly;
        builder.RegisterAllEntities<IEntity>(entitiesAssembly);
        
        builder.ApplyConfiguration(new RoleConfig());
        builder.ApplyConfiguration(new UserConfig());
        builder.ApplyConfiguration(new UserRoleConfig());
        builder.ApplyConfiguration(new RefreshTokenConfig());
        builder.ApplyConfiguration(new RoleClaimConfig());
        builder.ApplyConfiguration(new UserClaimConfig());
        builder.ApplyConfiguration(new UserLoginConfig());
        builder.ApplyConfiguration(new UserTokenConfig());
        
        //builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        builder.AddRestrictDeleteBehaviorConvention();
        builder.AddPluralizingTableNameConvention();
    }

    private void OnSavingChanges(object sender, SavingChangesEventArgs e)
    {
        ConfigureEntityDates();
    }
    
    
    private void ConfigureEntityDates()
    {
        var updatedEntities = ChangeTracker.Entries().Where(x =>
            x.Entity is ITimeModification && x.State == EntityState.Modified).Select(x => x.Entity as ITimeModification);

        var addedEntities = ChangeTracker.Entries().Where(x =>
            x.Entity is ITimeModification && x.State == EntityState.Added).Select(x => x.Entity as ITimeModification);

        foreach (var entity in updatedEntities)
        {
            if (entity != null)
            {
                entity.ModifiedDate = DateTime.Now;
            }
        }

        foreach (var entity in addedEntities)
        {
            if (entity != null)
            {
                entity.CreatedTime = DateTime.Now;
                entity.ModifiedDate = DateTime.Now;
            }
        }
    }
}