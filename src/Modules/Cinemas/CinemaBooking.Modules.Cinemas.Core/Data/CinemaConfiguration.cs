using CinemaBooking.Modules.Cinemas.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBooking.Modules.Cinemas.Core.Data;

internal class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
{
    public void Configure(EntityTypeBuilder<Cinema> builder)
    {
        builder.ToTable("cinemas");
        
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Id)
            .ValueGeneratedNever()
            .IsRequired();
        
        builder.Property(c => c.Name).IsRequired();
        
        builder.ComplexProperty(c => c.Address, address =>
        {
            address.Property(a => a.Street).IsRequired();
            address.Property(a => a.City).IsRequired();
            address.Property(a => a.ZipCode).IsRequired();

            address.ToJson();
        });

        builder.ComplexCollection(c => c.Screens, screens =>
        {
            screens.ComplexCollection(s => s.Seats);

            screens.ToJson();
        });
    }
}