using CinemaBooking.Modules.Cinemas.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBooking.Modules.Cinemas.Core.Data.Configurations;

internal class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
{
    public void Configure(EntityTypeBuilder<Cinema> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedNever().IsRequired();
        builder.Property(c => c.Name).IsRequired();
        builder.Property(c => c.Address).IsRequired();
        builder.HasMany(c => c.Screens)
            .WithOne()
            .HasForeignKey();//TODO: correct
    }
}