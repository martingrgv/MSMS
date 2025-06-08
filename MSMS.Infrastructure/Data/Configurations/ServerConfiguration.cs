using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSMS.Infrastructure.Data.Enums;
using MSMS.Infrastructure.Data.Models;
using static MSMS.Infrastructure.Constants.ValidationConstants;

namespace MSMS.Infrastructure.Data.Configurations
{
    public class ServerConfiguration : IEntityTypeConfiguration<Server>
    {
        public void Configure(EntityTypeBuilder<Server> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(SERVER_NAME_MAX_LENGTH)
                .IsRequired();

            builder.Property(x => x.ImagePath);

            builder.Property(x => x.IpAddress)
                .HasMaxLength(SERVER_IP_ADDRESS_MAX_LENGTH)
                .IsRequired();

            builder.Property(x => x.GameVersion)
                .HasMaxLength(SERVER_GAME_VERSION_MAX_LENGTH)
                .IsRequired();

            builder.Property(x => x.PlayMode)
                .HasConversion(
                        x => x.ToString(),
                        dbx => Enum.Parse<PlayMode>(dbx))
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(DESCRIPTION_MAX_LENGTH);

            builder.HasOne(x => x.Owner)
                .WithMany(x => x.Servers)
                .HasForeignKey(x => x.OwnerId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
