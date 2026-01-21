using CinemaBooking.Common.Abstractions.Entities;

namespace CinemaBooking.Modules.Movies.Core.Entities;

internal class Movie : Entity
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int Length { get; private set; }
    public DateTime ReleaseDate { get; private set; }
    public List<Genre> Genres { get; private set; }
    public int AgeRestriction { get; private set; }
    public List<Person> Directors { get; private set; }
    public List<Person> Cast { get; private set; }

    internal Movie(string  title, string description, int length, DateTime releaseDate, 
        IEnumerable<Genre> genres, int ageRestriction, IEnumerable<Person> directors, IEnumerable<Person> cast)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Length = length;
        ReleaseDate = releaseDate;
        Genres = genres.ToList();
        AgeRestriction = ageRestriction;
        Directors = directors.ToList();
        Cast = cast.ToList();
    }
}

internal enum Genre
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