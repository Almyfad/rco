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
            o.AddPolicy("localhost",
             policy =>
             {
                 policy
                 .WithOrigins("http://localhost:4200") // ou le port de ton front Angular
                       .AllowAnyHeader()
                       .AllowCredentials()
                       .AllowAnyMethod();
             });
        });
        return col;
    }


    public static IApplicationBuilder UseAppicationAngularCors(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
            return app.UseCors("localhost");
        return app.UseCors("rco.org");

    }
}