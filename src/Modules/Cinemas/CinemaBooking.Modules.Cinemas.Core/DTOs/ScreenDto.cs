namespace CinemaBooking.Modules.Cinemas.Core.DTOs;

public record ScreenDto(
    Guid Id,
    string Name,
    IEnumerable<SeatDto> Seats);