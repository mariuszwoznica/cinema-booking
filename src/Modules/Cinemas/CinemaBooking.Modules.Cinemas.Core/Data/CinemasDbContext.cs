using CinemaBooking.Modules.Cinemas.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Modules.Cinemas.Core.Data;

internal sealed class CinemasDbContext : DbContext
{
    internal DbSet<Cinema> Cinemas { get; set; }
    internal DbSet<Screen> Screens { get; set; }
    internal DbSet<Seat> Seats { get; set; }

    public CinemasDbContext(DbContextOptions<CinemasDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("cinemas");

        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}