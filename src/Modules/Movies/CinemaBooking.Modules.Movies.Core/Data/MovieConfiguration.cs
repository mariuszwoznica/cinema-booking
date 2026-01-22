using CinemaBooking.Modules.Movies.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBooking.Modules.Movies.Core.Data;

internal class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("movies");

        builder.HasKey(m => m.Id);
        
        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(m => m.Title).IsRequired();
        builder.Property(m => m.Description).IsRequired();
        builder.Property(m => m.Length).IsRequired();
        builder.Property(m => m.ReleaseDate).IsRequired();
        builder.Property(m => m.AgeRestriction).IsRequired();

        builder.ComplexCollection(m => m.Genres, genres => genres.ToJson());
        builder.ComplexCollection(m => m.Directors, directors => directors.ToJson());
        builder.ComplexCollection(m => m.Cast, cast => cast.ToJson());
    }
}