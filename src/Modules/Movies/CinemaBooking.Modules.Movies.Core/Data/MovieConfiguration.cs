using CinemaBooking.Common.Infrastructure.EFCore;
using CinemaBooking.Modules.Movies.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaBooking.Modules.Movies.Core.Data;

internal class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    private const string Config = "simple";
    
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("movies");

        builder.HasIndex(m => new { m.Title })
            .HasMethod("GIN")
            .IsTsVectorExpressionIndex(Config);

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(m => m.Title).IsRequired();
        builder.Property(m => m.Description).IsRequired();
        builder.Property(m => m.Length).IsRequired();
        builder.Property(m => m.ReleaseDate).IsRequired();
        builder.Property(m => m.AgeRestriction).IsRequired();
        builder.Property(m => m.Genres).HasJsonbEnumCollectionConversion();

        builder.ComplexCollection(m => m.Directors, directors => directors.ToJson());
        builder.ComplexCollection(m => m.Cast, cast => cast.ToJson());
    }
}