namespace CinemaBooking.Modules.Movies.Core.DTOs;

public record MovieDto(
    Guid Id,
    string Title, 
    string Description, 
    int Length, 
    DateTime ReleaseDate, 
    IEnumerable<Genre> Genres, 
    int AgeRestriction, 
    IEnumerable<PersonDto> Directors, 
    IEnumerable<PersonDto> Cast);
    
public enum Genre
{
    Action = 1,
    Adventure = 2,
    Comedy = 3,
    Drama = 4,
    Historical = 5,
    Fantasy = 6,
    SciFi = 7,
    Thriller = 8,
    Horror = 9,
    Musical = 10,
    Romance = 11,
    Western = 12,
    Documentary = 13,
    Crime = 14,
    Family = 15,
    Other = 16
}