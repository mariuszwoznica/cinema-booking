namespace CinemaBooking.Modules.Cinemas.Core.Exceptions;

internal class SeatTypeNotSupportedException : Exception
{
    public string Value { get; }

    public SeatTypeNotSupportedException(string value)
        : base($"Seat type {value} is not supported.")
        => Value = value;
}