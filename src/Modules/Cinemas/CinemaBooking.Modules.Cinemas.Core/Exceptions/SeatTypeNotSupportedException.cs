using CinemaBooking.Common.Abstractions.Exceptions;

namespace CinemaBooking.Modules.Cinemas.Core.Exceptions;

internal class SeatTypeNotSupportedException : CinemaBookingException
{
    public string Value { get; }

    public SeatTypeNotSupportedException(string value)
        : base($"Seat type '{value}' is not supported.")
    {
        Value = value;
    }
}