using CinemaBooking.Common.Abstractions.Exceptions;

namespace CinemaBooking.Modules.Movies.Core.Exceptions;

public class MovieNotFoundException : CinemaBookingException
{
    public Guid Id { get; }

    public MovieNotFoundException(Guid id)
        : base($"Movie with id: '{id}' was not found.")
    {
        Id = id;
    }
}