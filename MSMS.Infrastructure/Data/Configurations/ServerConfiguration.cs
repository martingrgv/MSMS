using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSMS.Infrastructure.Data.Models;
using MSMS.Infrastructure.Data.Seeder;

namespace MSMS.Infrastructure.Data.Configurations
{
    public class ServerConfiguration : IEntityTypeConfiguration<Server>
    {
        public void Configure(EntityTypeBuilder<Server> builder)
        {
            var seeder = new DbSeeder();
            builder.HasData( seeder.CreatorServer );
        }
    }
}
