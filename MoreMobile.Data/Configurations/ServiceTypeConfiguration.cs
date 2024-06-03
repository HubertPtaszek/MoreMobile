using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoreMobile.Domain.Entities;

namespace MoreMobile.Data.Configurations
{
    internal class ServiceTypeConfiguration : IEntityTypeConfiguration<ServiceType>
    {
        public void Configure(EntityTypeBuilder<ServiceType> builder)
        {
            builder.Property(p => p.NetPrice)
                   .HasColumnType("decimal(18,4)");

            builder.Property(p => p.GrossPrice)
                   .HasColumnType("decimal(18,4)");

            builder.HasMany(e => e.Warranties)
                .WithOne(e => e.ServiceType)
                .HasForeignKey(e => e.ServiceTypeId)
                .IsRequired();
        }
    }
}