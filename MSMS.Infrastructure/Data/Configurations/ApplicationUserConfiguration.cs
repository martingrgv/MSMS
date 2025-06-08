using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSMS.Infrastructure.Data.Models;
using static MSMS.Infrastructure.Constants.ValidationConstants;

namespace MSMS.Infrastructure.Data.Configurations
{
    internal class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserName)
                .HasMaxLength(USERNAME_MAX_LENGTH)
                .IsRequired();

            builder.Property(x => x.NormalizedUserName)
                .HasMaxLength(USERNAME_MAX_LENGTH)
                .IsRequired();

            builder.Property(x => x.FirstName)
                .HasMaxLength(FIRSTNAME_MAX_LENGTH)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasMaxLength(LASTNAME_MAX_LENGTH)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(x => x.PasswordHash)
                .IsRequired();
        }
    }
}
