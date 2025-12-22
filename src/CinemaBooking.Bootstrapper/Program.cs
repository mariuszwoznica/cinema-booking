using CinemaBooking.Common.Infrastructure;
using CinemaBooking.Common.Infrastructure.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseLogging();

builder.Services.AddOpenApi();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseInfrastructure();

app.UseHttpsRedirection();

app.Run();