using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Pluralize.NET;

namespace AppGestion.Infrastructure.Persistence.Extensions;

public static class ModelBuilderExtensions
{
    public static void RegisterAllEntities<BaseType>(this ModelBuilder modelBuilder, params Assembly[] assemblies)
    {
        IEnumerable<Type> types = assemblies.SelectMany(a => a.GetExportedTypes())
            .Where(c => c.IsClass && !c.IsAbstract && c.IsPublic && typeof(BaseType).IsAssignableFrom(c));
        
        foreach (Type type in types)
            modelBuilder.Entity(type);
    }
    
    /// <summary>
    /// Set DeleteBehavior.Restrict by default for relations
    /// </summary>
    /// <param name="modelBuilder"></param>
    public static void AddRestrictDeleteBehaviorConvention(this ModelBuilder modelBuilder)
    {
        IEnumerable<IMutableForeignKey> cascadeFKs = modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
        foreach (IMutableForeignKey fk in cascadeFKs)
            fk.DeleteBehavior = DeleteBehavior.Restrict;
    }
    
    public static void AddPluralizingTableNameConvention(this ModelBuilder modelBuilder)
    {
        Pluralizer pluralizer = new Pluralizer();
        foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
        {
            string tableName = entityType.GetTableName()!;
            entityType.SetTableName(pluralizer.Pluralize(tableName));
        }
    }
}