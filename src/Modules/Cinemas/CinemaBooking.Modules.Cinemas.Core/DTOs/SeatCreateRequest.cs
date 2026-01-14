namespace CinemaBooking.Modules.Cinemas.Core.DTOs;

public record SeatCreateRequest(
    string Row,
    int Number,
    SeatType Type);