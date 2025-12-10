using CinemaBooking.Common.Infrastructure.Commands;
using CinemaBooking.Common.Infrastructure.Logging;
using CinemaBooking.Common.Infrastructure.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaBooking.Common.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddCommands();
        services.AddQueries();
        services.AddLoggingDecorators();

        return services;
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
    {
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/openapi/v1.json", "CinemaBooking API");
        });

        return app;
    }
}