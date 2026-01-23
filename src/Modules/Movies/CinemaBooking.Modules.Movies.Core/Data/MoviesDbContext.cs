using CinemaBooking.Modules.Movies.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Modules.Movies.Core.Data;

internal class MoviesDbContext : DbContext
{
    private const string Schema = "movies";
    
    internal DbSet<Movie>  Movies { get; set; }

    public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schema);
        
        modelBuilder.ApplyConfiguration(new MovieConfiguration());
    }
}