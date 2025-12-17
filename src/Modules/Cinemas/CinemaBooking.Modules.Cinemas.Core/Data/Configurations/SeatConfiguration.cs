using CinemaBooking.Modules.Cinemas.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBooking.Modules.Cinemas.Core.Data.Configurations;

internal class SeatConfiguration : IEntityTypeConfiguration<Seat>
{
    public void Configure(EntityTypeBuilder<Seat> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).ValueGeneratedNever().IsRequired();
        builder.Property(s => s.Row).IsRequired();
        builder.Property(s => s.Number).IsRequired();
        builder.Property(s => s.Type).IsRequired();
    }
}