public static class CorsExtension
{
    public static IServiceCollection AddAppCors(this IServiceCollection col)
    {
        col.AddCors(o =>
        {
                o.AddPolicy("AllowLocalhost",
                 policy =>
                 {
                     policy.WithOrigins("http://localhost:4200") // ou le port de ton front Angular
                           .AllowAnyHeader()
                           .AllowCredentials()
                           .AllowAnyMethod();
                 });
        });
        return col;
    }

    public static IApplicationBuilder UseAppicationAngularCors(this WebApplication app)
    {
        return app.UseCors("AllowLocalhost");
    }
}