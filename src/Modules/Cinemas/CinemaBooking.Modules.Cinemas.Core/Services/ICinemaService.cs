using CinemaBooking.Modules.Cinemas.Core.DTOs;

namespace CinemaBooking.Modules.Cinemas.Core.Services;

public interface ICinemaService
{
    Task<CinemaDto> GetByIdAsync(Guid id);
    Task CreateAsync(CinemaDto cinema);
    Task UpdateAsync(CinemaDto cinema);
    Task DeleteAsync(Guid id);
}