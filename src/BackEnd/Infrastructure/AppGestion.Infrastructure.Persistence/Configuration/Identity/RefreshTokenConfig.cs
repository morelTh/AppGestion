using AppGestion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppGestion.Infrastructure.Persistence.Configuration.Identity;

internal class RefreshTokenConfig : IEntityTypeConfiguration<UserRefreshToken>
{
    public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
    {
        builder.HasOne(u => u.User)
            .WithMany(user => user.UserRefreshTokens)
            .HasForeignKey(u => u.UserId);

        builder.ToTable("UserRefreshTokens");
    }
}