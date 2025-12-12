using CinemaBooking.Modules.Cinemas.Core.Entities;

namespace CinemaBooking.Modules.Cinemas.Core;

internal interface ICinemaRepository
{
    Task<Cinema> GetByIdAsync(Guid id);
    Task CreateAsync(Cinema cinema);
    Task UpdateAsync(Cinema cinema);
    Task DeleteAsync(Guid id);
}