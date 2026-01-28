using CinemaBooking.Common.Abstractions.Exceptions;
using SeatType = CinemaBooking.Modules.Cinemas.Core.Entities.SeatType;
using SeatTypeDto = CinemaBooking.Modules.Cinemas.Core.DTOs.SeatType;

namespace CinemaBooking.Modules.Cinemas.Core.Exceptions;

internal class SeatTypeNotSupportedException : CinemaBookingException
{
    public string Value { get; }

    private SeatTypeNotSupportedException(string value)
        : base($"Seat type '{value}' is not supported.")
    {
        Value = value;
    }

    public static SeatTypeNotSupportedException Create(SeatType value)
        => new(value.ToString());
    
    public static SeatTypeNotSupportedException Create(SeatTypeDto value)
        => new(value.ToString());
}