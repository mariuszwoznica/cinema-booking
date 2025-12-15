using CinemaBooking.Modules.Cinemas.Core.DTOs;

namespace CinemaBooking.Modules.Cinemas.Core.Services;

public interface ICinemaService
{
    Task<CinemaDto> GetAsync(Guid id,  CancellationToken cancellationToken);
    Task CreateAsync(CinemaDto dto, CancellationToken cancellationToken);
    Task UpdateAsync(CinemaDto dto, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}