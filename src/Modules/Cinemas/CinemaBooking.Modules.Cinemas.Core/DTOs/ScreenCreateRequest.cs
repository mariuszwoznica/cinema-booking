namespace CinemaBooking.Modules.Cinemas.Core.DTOs;

public record ScreenCreateRequest(
    string Name,
    IEnumerable<SeatCreateRequest> Seats);