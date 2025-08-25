

using Helios.Context;

public static class Jwt
{

    public static String secret => HeliosContextExtensions.JwtSecret ?? throw new InvalidOperationException("JWT_SECRET environment variable is not set.");

    public static string issuer => Environment.GetEnvironmentVariable("JWT_ISSUER") ?? throw new InvalidOperationException("JWT_ISSUER environment variable is not set.");
    public static string audience => Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? throw new InvalidOperationException("JWT_AUDIENCE environment variable is not set.");
    public static int expireMinutes => int.TryParse(Environment.GetEnvironmentVariable("JWT_EXPIRE_MINUTES"), out var minutes) ? minutes : 60;
}

