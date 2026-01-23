using CinemaBooking.Modules.Movies.Core.DTOs;
using FluentValidation;

namespace CinemaBooking.Modules.Movies.Core.Validators;

internal class MovieUpdateRequestValidator : AbstractValidator<MovieUpdateRequest>
{
    public MovieUpdateRequestValidator()
    {
        RuleFor(m => m.Title)
            .NotEmpty()
            .WithMessage("Title is required.");

        RuleFor(m => m.Description)
            .NotEmpty()
            .WithMessage("Description is required.");

        RuleFor(x => x.Length)
            .GreaterThan(0)
            .LessThanOrEqualTo(600)
            .WithMessage("Movie length must be between 1 and 600 minutes.");

        RuleFor(x => x.ReleaseDate)
            .NotEmpty()
            .GreaterThan(DateTime.UtcNow)
            .LessThanOrEqualTo(DateTime.UtcNow.AddYears(1))
            .WithMessage("Release date is not valid.");

        RuleFor(x => x.Genres)
            .NotNull()
            .Must(g => g.Any())
            .WithMessage("At least one genre is required.");

        RuleForEach(x => x.Genres)
            .IsInEnum()
            .WithMessage("Genre is not valid.");

        RuleFor(x => x.AgeRestriction)
            .InclusiveBetween(0, 18);

        RuleFor(x => x.Directors)
            .NotNull()
            .Must(d => d.Any())
            .WithMessage("At least one director is required.");

        RuleForEach(x => x.Directors)
            .SetValidator(new PersonDtoValidator());

        RuleFor(x => x.Cast)
            .NotNull()
            .Must(c => c.Any())
            .WithMessage("Cast cannot be empty.");

        RuleForEach(x => x.Cast)
            .SetValidator(new PersonDtoValidator());
    }
}