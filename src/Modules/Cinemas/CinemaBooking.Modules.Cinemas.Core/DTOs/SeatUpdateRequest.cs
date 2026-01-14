namespace CinemaBooking.Modules.Cinemas.Core.DTOs;

public record SeatUpdateRequest(
    Guid? Id,
    string Row,
    int Number,
    SeatType Type);