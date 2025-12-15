using CinemaBooking.Modules.Cinemas.Core.Entities;

namespace CinemaBooking.Modules.Cinemas.Core;

internal interface ICinemaRepository
{
    Task<bool> ExistsAsync(string name,  CancellationToken cancellationToken);
    Task<Cinema> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task CreateAsync(Cinema cinema, CancellationToken cancellationToken);
    Task UpdateAsync(Cinema cinema, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}