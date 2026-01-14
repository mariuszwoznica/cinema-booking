namespace CinemaBooking.Modules.Cinemas.Core.DTOs;

public record ScreenUpdateRequest(
    Guid? Id,
    string Name,
    IEnumerable<SeatUpdateRequest> Seats);