using Helios.Context;
using Scalar.AspNetCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCookieConfiguration();
builder.Services.AddOpenApi();
builder.Services.AddControllers().AddJsonOptions(o =>
{
    o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddHeliosContext();
builder.Services.AddHttpContextAccessor();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (true || app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(o =>
    {
        o.Servers = new[] {
            new ScalarServer("https://helios-dev.rose-croix-d-or.org/"),
            new ScalarServer("https://helios-staging.rose-croix-d-or.org/"),
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
