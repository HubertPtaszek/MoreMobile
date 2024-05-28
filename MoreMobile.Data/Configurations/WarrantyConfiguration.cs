using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoreMobile.Domain.Entities;

namespace MoreMobile.Data.Configurations
{
    internal class WarrantyConfiguration : IEntityTypeConfiguration<Warranty>
    {
        public void Configure(EntityTypeBuilder<Warranty> builder)
        {
            builder.HasOne(e => e.User)
                .WithMany(e => e.Warranties)
                .HasForeignKey(e => e.UserId)
                .IsRequired();

            builder.HasMany(e => e.VisitDates)
                .WithOne(e => e.Warranty)
                .HasForeignKey(e => e.WarrantyId)
                .IsRequired();

            builder.HasOne(e => e.ServiceType)
                .WithMany(e => e.Warranties)
                .HasForeignKey(e => e.ServiceTypeId)
                .IsRequired();
        }
    }
}