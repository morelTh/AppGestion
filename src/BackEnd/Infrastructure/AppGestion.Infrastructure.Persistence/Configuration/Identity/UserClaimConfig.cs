using AppGestion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppGestion.Infrastructure.Persistence.Configuration.Identity
{
    internal class UserClaimConfig : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            builder.HasOne(u => u.User)
                .WithMany(u => u.Claims)
                .HasForeignKey(u => u.UserId);
            builder.ToTable("UserClaims", "usr");
        }
    }
}
