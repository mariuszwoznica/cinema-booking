using CinemaBooking.Common.Infrastructure;
using CinemaBooking.Common.Infrastructure.Logging;
using CinemaBooking.Modules.Cinemas.Api;
using CinemaBooking.Common.Infrastructure.Modules;
using CinemaBooking.Modules.Movies.Api;

var builder = WebApplication.CreateBuilder(args);

var assemblies = ModuleLoader.LoadAssemblies("CinemaBooking.Modules");

builder.Host.UseLogging();

builder.Services.AddOpenApi();

builder.Services
    .AddCommonInfrastructure(builder.Configuration, assemblies)
    .AddCinemasModule()
    .AddMoviesModule();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseCommonInfrastructure();

app.UseHttpsRedirection();

app.UseCinemasModule();
app.UseMoviesModule();

app.Run();