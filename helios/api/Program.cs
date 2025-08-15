using Helios.Context;
using Microsoft.Extensions.Options;
using Scalar.AspNetCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCookieConfiguration();
builder.Services.AddOpenApi(options =>
{
    options.AddSchemaTransformer<EnumSchemaTransformer>();
});
builder.Services.AddControllers().AddJsonOptions(o =>
{
    o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    o.JsonSerializerOptions.MaxDepth = 256;
});
builder.Services.AddHeliosContext();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAppCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseAppicationAngularCors();
    app.MapOpenApi();
    app.MapScalarApiReference(o =>
    {
        o.Servers = new[] {
            new ScalarServer("http://localhost:32769/"),
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
