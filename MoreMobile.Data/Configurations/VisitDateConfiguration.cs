using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoreMobile.Domain.Entities;

namespace MoreMobile.Data.Configurations
{
    internal class VisitDateConfiguration : IEntityTypeConfiguration<VisitDate>
    {
        public void Configure(EntityTypeBuilder<VisitDate> builder)
        {
            builder.HasOne(e => e.Warranty)
                .WithMany(e => e.VisitDates)
                .HasForeignKey(e => e.WarrantyId)
                .IsRequired();
        }
    }
}