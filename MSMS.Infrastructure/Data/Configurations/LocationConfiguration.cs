using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSMS.Infrastructure.Data.Enums;
using MSMS.Infrastructure.Data.Models;
using static MSMS.Infrastructure.Constants.ValidationConstants;

namespace MSMS.Infrastructure.Data.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(LOCATION_NAME_MAX_LENGTH)
                .IsRequired();

            builder.Property(x => x.Coordinates)
                .HasMaxLength(LOCATION_COORDINATES_MAX_LENGTH)
                .IsRequired();

            builder.Property(x => x.LocationType)
                .HasConversion(
                    x => x.ToString(),
                    dbx => Enum.Parse<LocationType>(dbx))
                .IsRequired();

            builder.Property(x => x.AccessModifier)
                .HasConversion(
                    x => x.ToString(),
                    dbx => Enum.Parse<LocationAccessModifier>(dbx))
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(DESCRIPTION_MAX_LENGTH);

            builder.HasOne(x => x.Creator)
                .WithMany(x => x.Locations)
                .HasForeignKey(x => x.CreatorId)
                .IsRequired();

            builder
                .HasOne(l => l.World)
                .WithMany(x => x.Locations)
                .HasForeignKey(x => x.WorldId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
