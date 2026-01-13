namespace CinemaBooking.Modules.Cinemas.Core.DTOs;

public record SeatRequest(
    string Row,
    int Number,
    SeatType Type);