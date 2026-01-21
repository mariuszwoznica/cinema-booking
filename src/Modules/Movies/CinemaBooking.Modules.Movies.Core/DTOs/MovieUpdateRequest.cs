namespace CinemaBooking.Modules.Movies.Core.DTOs;

public record MovieUpdateRequest(
    string Title, 
    string Description, 
    int Length, 
    DateTime ReleaseDate, 
    IEnumerable<Genre> Genres, 
    int AgeRestriction, 
    IEnumerable<PersonDto> Directors, 
    IEnumerable<PersonDto> Cast);