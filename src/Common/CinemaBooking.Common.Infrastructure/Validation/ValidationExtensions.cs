using System.Reflection;
using CinemaBooking.Common.Infrastructure.Validation.Filters;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaBooking.Common.Infrastructure.Validation;

public static class ValidationExtensions
{
    public static RouteHandlerBuilder WithRequestValidation<TRequest>(this RouteHandlerBuilder builder)  
        where TRequest : class
    {
        return builder.AddEndpointFilter<ValidationFilter<TRequest>>()
            .ProducesValidationProblem();
    }

    public static IServiceCollection AddFluentValidation(this IServiceCollection services, IEnumerable<Assembly> assemblies)
    {
        services.AddValidatorsFromAssemblies(assemblies);

        return services;
    }
}