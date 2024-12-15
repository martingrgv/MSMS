using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSMS.Infrastructure.Data.Models;
using MSMS.Infrastructure.Data.Seeder;

namespace MSMS.Infrastructure.Data.Configurations
{
    public class WorldConfiguration : IEntityTypeConfiguration<World>
    {
        public void Configure(EntityTypeBuilder<World> builder)
        {
            var seeder = new DbSeeder();
            builder.HasData(new World[] { seeder.CreatorOverworld, seeder.CreatorNether, seeder.CreatorEnd });
        }
    }
}
