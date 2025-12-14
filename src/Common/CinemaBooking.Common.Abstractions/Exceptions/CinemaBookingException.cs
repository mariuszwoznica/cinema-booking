namespace CinemaBooking.Common.Abstractions.Exceptions;

/// <summary>
/// Base class to represent domain exceptions in the system.
/// </summary>
public abstract class CinemaBookingException : Exception
{
    protected CinemaBookingException(string message) : base(message)
    {
    }

    protected CinemaBookingException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}