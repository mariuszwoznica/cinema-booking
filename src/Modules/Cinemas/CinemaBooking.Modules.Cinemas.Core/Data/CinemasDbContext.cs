using CinemaBooking.Modules.Cinemas.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Modules.Cinemas.Core.Data;

internal class CinemasDbContext : DbContext
{
    private const string Schema = "cinemas";

    internal DbSet<Cinema> Cinemas { get; set; }

    public CinemasDbContext(DbContextOptions<CinemasDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schema);
        
        modelBuilder.ApplyConfiguration(new CinemaConfiguration());
    }
}