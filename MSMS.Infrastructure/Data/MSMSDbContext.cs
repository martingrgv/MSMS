﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MSMS.Infrastructure.Data.Configurations;
using MSMS.Infrastructure.Data.Models;

namespace MSMS.Infrastructure.Data
{
    public class MSMSDbContext : IdentityDbContext<ApplicationUser>
    {
        public MSMSDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ApplicationUserConfiguration());
        }
    }
}