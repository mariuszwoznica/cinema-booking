using CinemaBooking.Modules.Movies.Core.Entities;

namespace CinemaBooking.Modules.Movies.Core;

internal interface IMovieRepository
{
    Task<Movie> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> ExistsAsync(string title, IEnumerable<Person> directors, CancellationToken cancellationToken);
    Task<IReadOnlyCollection<Movie>> GetListAsync(string searchPhrase, CancellationToken cancellationToken);
    Task CreateAsync(Movie movie, CancellationToken cancellationToken);
    Task UpdateAsync(Movie movie, CancellationToken cancellationToken);
    Task DeleteAsync(Movie movie, CancellationToken cancellationToken);
}