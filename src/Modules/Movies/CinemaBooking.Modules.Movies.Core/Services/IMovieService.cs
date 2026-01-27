using CinemaBooking.Modules.Movies.Core.DTOs;

namespace CinemaBooking.Modules.Movies.Core.Services;

public interface IMovieService
{
    Task<MovieDto> GetAsync(Guid id,  CancellationToken cancellationToken);
    Task<IReadOnlyCollection<MovieDto>> GetBySearchPhraseAsync(string searchPhrase, CancellationToken cancellationToken);
    Task<MovieDto> CreateAsync(MovieCreateRequest request, CancellationToken cancellationToken);
    Task UpdateAsync(Guid id, MovieUpdateRequest request, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}