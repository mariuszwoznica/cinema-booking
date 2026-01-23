using CinemaBooking.Modules.Movies.Core.DTOs;
using FluentValidation;

namespace CinemaBooking.Modules.Movies.Core.Validators;

internal class PersonDtoValidator : AbstractValidator<PersonDto>
{
    public PersonDtoValidator()
    {
        RuleFor(p => p.FirstName)
            .NotEmpty()
            .WithMessage("First name is required.");
        
        RuleFor(p => p.LastName)
            .NotEmpty()
            .WithMessage("Last name is required.");
    }
}