using Helios.Context;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddHealthChecks();
builder.Services.AddHeliosContext();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (true || app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(o =>
    {
        o.Servers = new[] { 
            new ScalarServer("https://helios-dev.rose-croix-d-or.org/") ,
            new ScalarServer("https://helios.rose-croix-d-or.org/")
        };
        o.WithTitle("Helios")
        .WithFavicon("/favicon.png");
    });
    app.Map("/favicon.png", async context =>
    {
        context.Response.ContentType = "image/x-icon";
        await context.Response.SendFileAsync("icons/favicon-96x96.png");
    });

}

app.UseAuthorization();

app.MapControllers();

app.Run();



public static class HeliosContextExtensions
{


}
