using CinemaBooking.Modules.Cinemas.Core.Entities;
using CinemaBooking.Modules.Cinemas.Core.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Modules.Cinemas.Core.Data;

internal class CinemaRepository(CinemasDbContext context) : ICinemaRepository
{
    public Task<bool> ExistsAsync(string name, CancellationToken cancellationToken)
        => context.Cinemas
            .AnyAsync(c => c.Name.ToLower() == name.ToLower(), cancellationToken);

    public async Task<Cinema> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => await context.Cinemas
               .AsNoTracking()
               .SingleOrDefaultAsync(c => c.Id == id, cancellationToken) ??
           throw new CinemaNotFoundException(id);

    public async Task CreateAsync(Cinema cinema, CancellationToken cancellationToken)
    {
        context.Cinemas.Add(cinema);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Cinema cinema, CancellationToken cancellationToken)
    {
        context.Cinemas.Update(cinema);
        await context.SaveChangesAsync(cancellationToken);
    }

    //TODO: https://github.com/dotnet/efcore/issues/37373
    public async Task DeleteAsync(Cinema cinema, CancellationToken cancellationToken)
    {
        context.Cinemas.Remove(cinema);
        await context.SaveChangesAsync(cancellationToken);
    }
}