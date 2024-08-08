using AppGestion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppGestion.Infrastructure.Persistence.Configuration.Identity;

internal class UserTokenConfig : IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        builder.HasOne(u => u.User)
            .WithMany(u => u.Tokens)
            .HasForeignKey(u => u.UserId);
        
        builder.ToTable("UserTokens", "usr");
    }
}