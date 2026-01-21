using CinemaBooking.Modules.Movies.Core.DTOs;

namespace CinemaBooking.Modules.Movies.Core.Services;

public interface IMovieService
{
    Task<MovieDto> GetAsync(Guid id,  CancellationToken cancellationToken);
    Task<MovieDto> CreateAsync(MovieCreateRequest request, CancellationToken cancellationToken);
}