using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaBooking.Common.Infrastructure.Exceptions;

internal static class ExceptionsExtensions
{
    internal static IServiceCollection AddExceptionHandling(this IServiceCollection services)
    {
        services
            .AddProblemDetails()
            .AddExceptionHandler<CinemaBookingExceptionHandler>()
            .AddExceptionHandler<GlobalExceptionHandler>();

        return services;
    }

    internal static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app)
        => app.UseExceptionHandler();
}