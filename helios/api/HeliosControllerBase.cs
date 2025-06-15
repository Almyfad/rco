using Helios.Context;
using Helios.Context.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Helios.Controllers.User;
using System.Security.Claims;

namespace Helios
{
    public class HeliosControllerBase : ControllerBase
    {

        protected readonly ILogger<UserController> _logger;
        protected readonly HeliosContext helios;
        protected readonly IHttpContextAccessor _httpContextAccessor;

        protected OsmoseControllerBaseContext OsContext;
        public HeliosControllerBase(IServiceProvider serviceProvider)
        {
            OsContext = new OsmoseControllerBaseContext(serviceProvider);

            _logger = serviceProvider.GetService<ILogger<UserController>>()!;
            helios = serviceProvider.GetService<HeliosContext>()!;
            _httpContextAccessor = serviceProvider.GetService<IHttpContextAccessor>()!;
        }
    }

    public class OsmoseControllerBaseContext
    {

        protected readonly ILogger<UserController> _logger;
        protected readonly HeliosContext _helios;
        protected readonly IHttpContextAccessor _httpContextAccessor;

        public OsmoseControllerBaseContext(IServiceProvider serviceProvider)
        {
            _logger = serviceProvider.GetService<ILogger<UserController>>()!;
            _helios = serviceProvider.GetService<HeliosContext>()!;
            _httpContextAccessor = serviceProvider.GetService<IHttpContextAccessor>()!;
        }

        public OsmoseControllerBaseContext(HeliosContext context, IHttpContextAccessor httpContextAccessor, ILogger<UserController> logger)
        {
            _helios = context;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }


        public ClaimsPrincipal? LoggedUser => _httpContextAccessor.HttpContext?.User;
        public String LoggedUserEmail => LoggedUser?.FindFirst(JwtRegisteredClaimNames.UniqueName)?.Value ?? "";


        private Utilisateur? _currentUser;
        public void ResetCurrentUser() => _currentUser = null;
        private async Task<Utilisateur> GetCurrentUser()
        {
#nullable disable
            if (_currentUser == null)
                _currentUser = await _helios.Utilisateurs
                .AsNoTracking()
                .Include(x => x.Membre)
                .Include(x => x.Roles)
                .Include(x => x.Membre).ThenInclude(x => x.TypeMembre)
                .Include(x => x.Droits).ThenInclude(x => x.Centre).ThenInclude(x => x.TypeCentre)
                .Include(x => x.Droits).ThenInclude(x => x.Module).ThenInclude(s => s.SousMenus)
                .FirstOrDefaultAsync(x => x.Email == LoggedUserEmail);

            return _currentUser;

        }


        public Task<Utilisateur> CurrentUser => GetCurrentUser();

        public Task<UserInfo> UserInfos => GetUserInfos();

        public Task<ICollection<Droit>> DroitsUser => CurrentUser.ContinueWith(x => x.Result?.Droits);
        public Task<bool> isSYSAdmin => CurrentUser.ContinueWith(x => x.Result?.Roles?.Any(x => x.Code == Roles.SYSADMIN) ?? false);
        public Task<bool> isAdmin => CurrentUser.ContinueWith(x => x.Result?.Roles?.Any(x => x.Code == Roles.ADMIN_FULL_ACCESS) ?? false);
        public Task<bool> isNotSysAdmin => isSYSAdmin.ContinueWith(x => !x.Result);
        public Task<IEnumerable<Centre>> CentresWithAnyRight => _CentresWithAnyRight();
        private async Task<UserInfo> GetUserInfos()
        {
            var retour = new UserInfo();
            if (String.IsNullOrEmpty(LoggedUserEmail))
                return retour;

            var user = await CurrentUser;
            if (user == null)
                return retour;

            var _isSYSAdmin = await isSYSAdmin;
            var _isAdmin = await isAdmin;

            if (_isSYSAdmin)
                retour.SysAdminModules = _helios.Modules
                    .Include(x => x.SousMenus)
                    .Where(x => x.Code == Modules.SysAdmin);

            if (_isAdmin || _isSYSAdmin)
            {
                retour.AdminModules = _helios.Modules
                .Include(x => x.SousMenus)
                .Where(x => x.Code == Modules.Administation);

                var allModcules = await _helios.Modules
                .Where(m => m.Parent == null && m.Code != Modules.SysAdmin && m.Code != Modules.Administation)
                .Include(x => x.SousMenus)
                .ToListAsync();

                retour.CentreModules = (await _helios.Centre
                    .Include(x => x.TypeCentre)
                    .AsNoTracking().
                ToListAsync())
                .Select(x => new CentreModule
                (
                    x,
                    allModcules.OrderBy(x => x.Id)
                ));
            }
            else
            {
                var publicModules = await _helios.Droits
                    .Include(x => x.Module).ThenInclude(x => x.SousMenus)
                    .Where(x => x.Code == Droits.PUBLIC)
                    .Select(x => x.Module)
                    .ToListAsync();

                retour.CentreModules = user.Droits?.GroupBy(x => x.Centre, x => x.Module, new CentreEqualityComparer())
                    .Select(x => new CentreModule
                    (
                         (CentreInfos)x.Key!,
                        x.Union(publicModules).DistinctBy(x => x!.Id).OrderBy(x => x!.Id)
                    ));
            }

            retour.Id = user.Id;
            retour.Email = user.Email;
            retour.Nom = user.Membre?.Nom ?? user.Droits.Count.ToString();
            retour.Prenom = user.Membre?.Prenom;
            retour.TypeMembre = user.Membre?.TypeMembre.Code;
            retour.IsConnected = true;
            return retour;

        }
        public Task<IEnumerable<Module>> PrivilegedMenus => _PrivilegedMenus();
        private async Task<IEnumerable<Module>> _PrivilegedMenus() => (await DroitsUser).Select(x => x.Module!);
        public async Task<IEnumerable<Module>> PrivilegedMenusForCentre(Centre centre) => (await DroitsUser)
            .Where(x => x.Centre != null && x.Centre.Id == centre.Id)
            .Select(x => x.Module!);

        protected async Task<bool> _IsAdminOrSysAdmin()
        {
            if (await isSYSAdmin)
                return true;
            if (await isAdmin)
                return true;
            return false;
        }

        public Task<bool> IsAdminOrSysAdmin => _IsAdminOrSysAdmin();

        public async Task<IEnumerable<Centre>> CentresWithRight(params Modules[] modules)
        {

            if (await IsAdminOrSysAdmin)
                return (await _helios.Centre.AsNoTracking()
                    .ToListAsync())
                    .DistinctBy(x => x.Id);
            return (await DroitsUser)?
             .Where(x => x.Module != null && x.Centre != null)
             .Where(x => modules.ToList().Contains(x.Module!.Code))
             .Select(x => x.Centre!)
             .DistinctBy(x => x.Id);

        }
        private async Task<IEnumerable<Centre>> _CentresWithAnyRight()
        {

            if (await IsAdminOrSysAdmin)
                return (await _helios.Centre.AsNoTracking()
                    .ToListAsync())
                    .DistinctBy(x => x.Id);
            return (await DroitsUser)?
                .Where(x => x.Module != null && x.Centre != null)
                .Select(x => x.Centre!)
                .DistinctBy(x => x.Id);
        }
        public async Task<Boolean> ActionsIsAllowed(Centre centre, Modules module, Droits droit)
        {

            if (await IsAdminOrSysAdmin)
                return true;

            return (await DroitsUser)?
            .Where(x => x.Module != null && x.Centre != null)
            .Any(x => module == x.Module!.Code && centre.Id == x.Centre!.Id && droit == x.Code) ?? false;


        }
        public async Task<Boolean> ActionsIsAllowed(int centreId, Modules module, Droits droit)
        {

            if (await IsAdminOrSysAdmin)
                return true;

            return (await DroitsUser)?
            .Where(x => x.Module != null && x.Centre != null)
            .Any(x => module == x.Module!.Code && centreId == x.Centre!.Id && droit == x.Code) ?? false;


        }


    }
}
