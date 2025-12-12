namespace CinemaBooking.Modules.Cinemas.Core.DTOs;

public record SeatDto(
    Guid Id,
    string Row,
    int Number,
    SeatType Type);
    
public enum SeatType
{
    Vip = 1,
    Standard = 2,
    Saver = 3
}