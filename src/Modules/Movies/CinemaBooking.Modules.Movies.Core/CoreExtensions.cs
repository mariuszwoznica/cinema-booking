using CinemaBooking.Modules.Movies.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaBooking.Modules.Movies.Core;

public static class CoreExtensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services
            .AddScoped<IMovieService, MovieService>();
        
        return services;
    }
}