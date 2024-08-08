using AppGestion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppGestion.Infrastructure.Persistence.Configuration.Identity
{
    internal class UserLoginConfig : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> builder)
        {
            builder.HasOne(u => u.User)
                .WithMany(u => u.Logins)
                .HasForeignKey(u => u.UserId);
            builder.ToTable("UserLogins");
        }
    }
}
