using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoreMobile.Data.Configurations;
using MoreMobile.Domain.Entities;

namespace MoreMobile.Data.Context
{
    public class DatabaseContext : IdentityDbContext<UserBase, IdentityRole<Guid>, Guid>
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        //Add-Migration -Context DatabaseContext -o ".\Migrations\" <Nazwa migracji>
        //Update-Database -Context DatabaseContext
        //Remove-Migration -Context DatabaseContext

        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<Warranty> Warranties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ServiceTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new VisitDateConfiguration());
            modelBuilder.ApplyConfiguration(new WarrantyConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new AdminConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}