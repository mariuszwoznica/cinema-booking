using CinemaBooking.Modules.Movies.Core.Entities;

namespace CinemaBooking.Modules.Movies.Core;

internal interface IMovieRepository
{
    Task<Movie> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task CreateAsync(Movie movie, CancellationToken cancellationToken);
    Task UpdateAsync(Movie movie, CancellationToken cancellationToken);
    Task DeleteAsync(Movie movie, CancellationToken cancellationToken);
}