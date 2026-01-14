using CinemaBooking.Modules.Cinemas.Core.DTOs;

namespace CinemaBooking.Modules.Cinemas.Core.Services;

public interface ICinemaService
{
    Task<CinemaDto> GetAsync(Guid id,  CancellationToken cancellationToken);
    Task<CinemaDto> CreateAsync(CinemaCreateRequest request, CancellationToken cancellationToken);
    Task UpdateAsync(Guid id, CinemaUpdateRequest request, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}