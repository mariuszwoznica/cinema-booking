using CinemaBooking.Common.Infrastructure.Commands;
using CinemaBooking.Common.Infrastructure.Database;
using CinemaBooking.Common.Infrastructure.Logging;
using CinemaBooking.Common.Infrastructure.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaBooking.Common.Infrastructure;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddCommands()
            .AddQueries()
            .AddLoggingDecorators()
            .AddPostgresDatabase(configuration);

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