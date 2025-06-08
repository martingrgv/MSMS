using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSMS.Infrastructure.Data.Enums;
using MSMS.Infrastructure.Data.Models;

namespace MSMS.Infrastructure.Data.Configurations
{
    public class WorldConfiguration : IEntityTypeConfiguration<World>
    {
        public void Configure(EntityTypeBuilder<World> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ImagePath);

            builder.Property(x => x.Seed);

            builder.Property(x => x.WorldType)
                .HasConversion(
                    x => x.ToString(),
                    dbx => Enum.Parse<WorldType>(dbx));

            builder.HasOne(x => x.Server)
                .WithMany(x => x.Worlds)
                .HasForeignKey(x => x.ServerId);
        }
    }
}
