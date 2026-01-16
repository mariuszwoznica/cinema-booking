using System.Reflection;
using CinemaBooking.Common.Infrastructure.Validation.Filters;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaBooking.Common.Infrastructure.Validation;

public static class ValidationExtensions
{
    /// <summary>
    /// Registers a request validation filter for the route handler.
    /// </summary>
    /// <param name="builder">The route handler builder</param>
    /// <typeparam name="TRequest">The request to validate</typeparam>
    /// <returns>A <see cref="RouteHandlerBuilder"/> that can be used to further customize the route handler.</returns>
    public static RouteHandlerBuilder WithRequestValidation<TRequest>(this RouteHandlerBuilder builder)
        where TRequest : class
        => builder.AddEndpointFilter<RequestValidationFilter<TRequest>>()
            .ProducesValidationProblem();

    public static IServiceCollection AddFluentValidation(
        this IServiceCollection services,
        IEnumerable<Assembly> assemblies)
    {
        services.AddValidatorsFromAssemblies(assemblies, includeInternalTypes: true);

        return services;
    }
}