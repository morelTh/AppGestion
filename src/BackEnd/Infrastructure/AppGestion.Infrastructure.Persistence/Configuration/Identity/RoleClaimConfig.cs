using AppGestion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppGestion.Infrastructure.Persistence.Configuration.Identity
{
    internal class RoleClaimConfig : IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            builder.HasOne(u => u.Role)
                .WithMany(u => u.RoleClaims)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("RoleClaims");
        }
    }
}
