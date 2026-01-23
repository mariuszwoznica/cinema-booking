using CinemaBooking.Modules.Movies.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaBooking.Modules.Movies.Api;

public static class MoviesModule
{
    public static IServiceCollection AddMoviesModule(this IServiceCollection services)
    {
        services
            .AddCore();

        return services;
    }
    
    public static void UseMoviesModule(this WebApplication app)
    {
        app.MapMoviesEndpoints();
    }
}