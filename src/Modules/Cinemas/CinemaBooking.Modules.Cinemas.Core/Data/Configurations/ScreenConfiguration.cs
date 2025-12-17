using CinemaBooking.Modules.Cinemas.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBooking.Modules.Cinemas.Core.Data.Configurations;

internal class ScreenConfiguration : IEntityTypeConfiguration<Screen>
{
    public void Configure(EntityTypeBuilder<Screen> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).ValueGeneratedNever().IsRequired();
        builder.Property(s => s.Name).IsRequired();
        builder.Property(s => s.Seats).IsRequired(); //TODO: correct
    }
}