using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoreMobile.Data.Configurations;
using MoreMobile.Domain.Entities;

namespace MoreMobile.Data.Context
{
    public class DatabaseContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        //Add-Migration -Context DatabaseContext -o ".\Migrations\" <Nazwa migracji>
        //Update-Database -Context DatabaseContext
        //Remove-Migration -Context DatabaseContext

        public DbSet<ServiceType> ServiceTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ServiceTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new VisitDateConfiguration());
            modelBuilder.ApplyConfiguration(new WarrantyConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}