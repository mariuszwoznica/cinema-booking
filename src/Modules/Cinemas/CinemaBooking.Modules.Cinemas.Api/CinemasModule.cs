using CinemaBooking.Modules.Cinemas.Core;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaBooking.Modules.Cinemas.Api;

public static class CinemasModule
{
    public static IServiceCollection AddCinemasModule(this IServiceCollection services)
    {
        services
            .AddCore();

        return services;
    }
}