using CinemaBooking.Common.Abstractions.Exceptions;
using CinemaBooking.Common.Infrastructure.Utilities;
using CinemaBooking.Modules.Movies.Core.Entities;

namespace CinemaBooking.Modules.Movies.Core.Exceptions;

internal class MovieAlreadyExistsException : CinemaBookingException
{
    public string Title { get; }
    public string Director { get; }

    private MovieAlreadyExistsException(string title, string director)
        : base($"Movie with title: '{title}' and director: '{director}' already exists.")
    {
        Title = title;
        Director = director;
    }

    public static MovieAlreadyExistsException Create(string title, IEnumerable<Person> director)
        => new(title, director.ToDelimitedString(d => d.FirstName + " " + d.LastName));
}