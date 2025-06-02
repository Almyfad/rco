using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Helios.Context.Models;
using Microsoft.AspNetCore.Authentication;

namespace Helios.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : HeliosControllerBase
    {

        public UserController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }


        [HttpPost("login")]
        public async Task Login(LoginRequest request)
        {
            var claimsIdentity = await new Auth(helios, request.Email).getUserClaims(request.Password);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
        [HttpGet("infos")]
        public async Task<UserInfo> GetCurrentUserInfos()
        {
            return await OsContext.UserInfos;
        }
        /*
        

        [HttpGet("menu/:CodeCentre")]
        [Authorize]
        [Obsolete("Use GetMenuForCentre instead")]
        public async Task<IEnumerable<Module>> GetMenuForCentre(String CodeCentre)
        {

            var centre = (await OsContext.CentresWithAnyRight)?
                .FirstOrDefault(x => x.Code == CodeCentre);

            if (centre == null) throw new ForbiddenException("Privilèges insuffisant");

            var privilegedMenus = (await OsContext.PrivilegedMenusForCentre(centre));

            return privilegedMenus
                .DistinctBy(x => x.Id)
                .OrderBy(x => x.Id);

        }

        [HttpGet("mesenfants")]
        [Authorize]
        public async Task<IEnumerable<Membre>> GetMyChildren()
        {
            var user = await OsContext.CurrentUser;
            return await helios.Membres
                .Where(x => x.Parents!.Any(p => p.Id == user.MembreId))
                .ToListAsync();
        }


        [HttpPost("inscription")]
        [Authorize]
        public async Task Inscription(int ActiviteeId, String Infos)
        {
            if (ActiviteeId == 0) throw new ApiException("ActivityId is required");

            var user = await OsContext.CurrentUser;
            var activitee = await helios.Activitees
                .Include(x => x.Inscriptions!)
                .ThenInclude(x=> x.Utilisateur)
                .FirstOrDefaultAsync(x => x.Id == ActiviteeId);

            if (activitee == null) throw new ApiException("Activity not found");

            if (activitee.Inscriptions!.Any(x => x.Utilisateur?.Id == user.Id))
                throw new ApiException("Already registered");

            helios.Inscriptions.Add(new Inscription()
            {
                ActiviteeId = activitee.Id,
                UtilisateurId = user.Id,
                Infos = Infos
            });
            await helios.SaveChangesAsync();
        }
        */
    }


}
