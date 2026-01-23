using CinemaBooking.Modules.Movies.Core.DTOs;
using CinemaBooking.Modules.Movies.Core.Entities;
using CinemaBooking.Modules.Movies.Core.Exceptions;
using Genre = CinemaBooking.Modules.Movies.Core.Entities.Genre;
using GenreDto = CinemaBooking.Modules.Movies.Core.DTOs.Genre;

namespace CinemaBooking.Modules.Movies.Core;

internal static class MappingExtensions
{
    internal static MovieDto ToDto(this Movie movie)
        => new(
            Id: movie.Id,
            Title: movie.Title,
            Description: movie.Description,
            Length: movie.Length,
            ReleaseDate: movie.ReleaseDate,
            Genres: movie.Genres.Select(genre => genre.ToDto()),
            AgeRestriction: movie.AgeRestriction,
            Directors: movie.Directors.Select(director => new PersonDto(
                FirstName: director.FirstName,
                LastName: director.LastName)),
            Cast: movie.Cast.Select(cast => new PersonDto(
                FirstName: cast.FirstName,
                LastName: cast.LastName))
        );

    internal static Person ToEntity(this PersonDto person)
        => new(
            FirstName: person.FirstName,
            LastName: person.LastName
        );

    internal static Movie ToEntity(this MovieCreateRequest movieDto)
        => new(
            title: movieDto.Title,
            description: movieDto.Description,
            length: movieDto.Length,
            releaseDate: movieDto.ReleaseDate,
            genres: movieDto.Genres.Select(genre => genre.ToEntity()),
            ageRestriction: movieDto.AgeRestriction,
            directors: movieDto.Directors.Select(director => director.ToEntity()),
            cast: movieDto.Cast.Select(cast => cast.ToEntity())
        );

    internal static Genre ToEntity(this GenreDto genre)
        => genre switch
        {
            GenreDto.Action => Genre.Action,
            GenreDto.Adventure => Genre.Adventure,
            GenreDto.Comedy => Genre.Comedy,
            GenreDto.Drama => Genre.Drama,
            GenreDto.Historical => Genre.Historical,
            GenreDto.Fantasy => Genre.Fantasy,
            GenreDto.SciFi => Genre.SciFi,
            GenreDto.Thriller => Genre.Thriller,
            GenreDto.Horror => Genre.Horror,
            GenreDto.Musical => Genre.Musical,
            GenreDto.Romance => Genre.Romance,
            GenreDto.Western => Genre.Western,
            GenreDto.Documentary => Genre.Documentary,
            GenreDto.Crime => Genre.Crime,
            GenreDto.Family => Genre.Family,
            GenreDto.Other => Genre.Other,
            _ => throw new GenreNotSupportedException(genre.ToString())
        };

    private static GenreDto ToDto(this Genre genre)
        => genre switch
        {
            Genre.Action => GenreDto.Action,
            Genre.Adventure => GenreDto.Adventure,
            Genre.Comedy => GenreDto.Comedy,
            Genre.Drama => GenreDto.Drama,
            Genre.Historical => GenreDto.Historical,
            Genre.Fantasy => GenreDto.Fantasy,
            Genre.SciFi => GenreDto.SciFi,
            Genre.Thriller => GenreDto.Thriller,
            Genre.Horror => GenreDto.Horror,
            Genre.Musical => GenreDto.Musical,
            Genre.Romance => GenreDto.Romance,
            Genre.Western => GenreDto.Western,
            Genre.Documentary => GenreDto.Documentary,
            Genre.Crime => GenreDto.Crime,
            Genre.Family => GenreDto.Family,
            Genre.Other => GenreDto.Other,
            _ => throw new GenreNotSupportedException(genre.ToString())
        };
}