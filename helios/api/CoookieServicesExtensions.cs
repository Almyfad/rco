using Helios.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

public static class CoookieServicesExtensions
{
    public static void AddCookieConfiguration(this IServiceCollection services)
    {
        services
           .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
   .AddCookie(options =>
   {
#if RELEASE
       options.Cookie.HttpOnly = true;
       options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Toujours en HTTPS en production
       options.Cookie.SameSite = SameSiteMode.Strict;
#endif
       
       options.Cookie.Name = "helios";
       options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
       options.SlidingExpiration = true;
       options.Events = new CookieAuthenticationEvents
       {
           OnRedirectToLogin = context =>
           {
               context.Response.StatusCode = 401;
               return Task.CompletedTask;
           },
           OnRedirectToAccessDenied = context =>
           {
               context.Response.StatusCode = 403;
               return Task.CompletedTask;
           },
           OnValidatePrincipal = context =>
           {
               var dbContext = context.HttpContext.RequestServices.GetRequiredService<HeliosContext>();

               var claimsPrincipal = context.Principal;
               if (claimsPrincipal == null)
               {
                   context.RejectPrincipal();
                   return Task.CompletedTask;

               }
               var userIdClaim = claimsPrincipal?.FindFirst(JwtRegisteredClaimNames.UniqueName);
               if (userIdClaim == null)
               {
                   context.RejectPrincipal();
                   return Task.CompletedTask;

               }
               var userId = userIdClaim.Value;
               var auth = new Auth(dbContext, userId);
               var currentRoles = (claimsPrincipal!.FindAll(ClaimTypes.Role)?.Select(c => c.Value) ?? Enumerable.Empty<string>()).ToList();
               return Task.CompletedTask;

           }
       };
   });

    }

}