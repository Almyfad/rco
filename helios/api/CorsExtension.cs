public static class CorsExtension
{
    public static IServiceCollection AddAppCors(this IServiceCollection col)
    {
        col.AddCors(o =>
        {
                o.AddPolicy("rco.org",
                 policy =>
                 {
                     policy
                     .SetIsOriginAllowed(origin => new Uri(origin).Host.EndsWith(".rose-croix-d-or.org"))
                           .AllowAnyHeader()
                           .AllowCredentials()
                           .AllowAnyMethod();
                 });
        });
        return col;
    }

    public static IApplicationBuilder UseAppicationAngularCors(this WebApplication app)
    {
        return app.UseCors("rco.org");
    }
}