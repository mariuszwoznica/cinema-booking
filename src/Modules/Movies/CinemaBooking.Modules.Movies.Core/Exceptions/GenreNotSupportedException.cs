using CinemaBooking.Common.Abstractions.Exceptions;

namespace CinemaBooking.Modules.Movies.Core.Exceptions;

public class GenreNotSupportedException : CinemaBookingException
{
    public string Value { get; }

    public GenreNotSupportedException(string value)
        : base($"Genre '{value}' is not supported.")
    {
        Value = value;
    }
}