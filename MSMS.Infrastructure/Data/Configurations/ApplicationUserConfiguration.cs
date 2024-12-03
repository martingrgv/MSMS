using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSMS.Infrastructure.Data.Models;
using MSMS.Infrastructure.Data.Seeder;
using static MSMS.Infrastructure.Constants.ValidationConstants;

namespace MSMS.Infrastructure.Data.Configurations
{
    internal class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x => x.UserName).HasMaxLength(USERNAME_MAX_LENGTH);
            builder.Property(x => x.UserName).IsRequired();
            builder.Property(x => x.NormalizedUserName).HasMaxLength(USERNAME_MAX_LENGTH);
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.PasswordHash).IsRequired();

            var seeder = new DbSeeder();
            builder.HasData(new ApplicationUser [] { seeder.GuestUser, seeder.CreatorUser });
        }
    }
}
