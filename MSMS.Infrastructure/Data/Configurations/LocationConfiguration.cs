﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSMS.Infrastructure.Data.Models;
using MSMS.Infrastructure.Data.Seeder;

namespace MSMS.Infrastructure.Data.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder
                .HasOne(l => l.World)
                .WithMany(w => w.Locations)
                .HasForeignKey(l => l.WorldId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(DbSeeder.SeedLocations());
        }
    }
}
