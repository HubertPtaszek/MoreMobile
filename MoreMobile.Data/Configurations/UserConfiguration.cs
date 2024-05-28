using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoreMobile.Domain.Entities;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace MoreMobile.Data.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(e => e.Warranties)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .IsRequired();
        }
    }
}