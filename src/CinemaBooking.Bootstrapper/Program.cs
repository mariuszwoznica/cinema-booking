using CinemaBooking.Common.Infrastructure;
using CinemaBooking.Common.Infrastructure.Logging;
using CinemaBooking.Modules.Cinemas.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseLogging();

builder.Services.AddOpenApi();

builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddCinemasModule();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseInfrastructure();

app.UseHttpsRedirection();

app.Run();