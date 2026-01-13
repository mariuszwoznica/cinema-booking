namespace CinemaBooking.Modules.Cinemas.Core.DTOs;

public record ScreenRequest(
    string Name,
    IEnumerable<SeatRequest> Seats);