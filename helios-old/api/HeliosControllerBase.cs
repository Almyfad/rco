using Helios.Context;
using Helios.Context.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Helios.Controllers.User;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

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


        private IQueryable<Utilisateur?> QueryCurrentUser()
        {
            return _helios.Utilisateurs
             .AsNoTracking()
             .Include(x => x.Membre!)
             .Include(x => x.Roles!)
             .Include(x => x.Membre!).ThenInclude(x => x.TypeMembre!)
             .Include(x => x.Droits!).ThenInclude(x => x.Centre!).ThenInclude(x => x.TypeCentre!)
             .Include(x => x.Droits!).ThenInclude(x => x.Module!).ThenInclude(s => s.SousMenus!)
             .Where(x => x.Email == LoggedUserEmail)
             .Take(1);
        }

        private Utilisateur? _CachedUser;
        private async Task<Utilisateur> LoadCurrentUser()
        {
            if (_CachedUser != null) return _CachedUser;
            var user = await QueryCurrentUser().FirstOrDefaultAsync();
            if (user == null)
                throw new Exception("[000] Accès refusé");
            return _CachedUser ??= user;
        }

        public Task<Utilisateur> CurrentUser => LoadCurrentUser();

        public Task<UserInfo> UserInfos => GetUserInfos();

        public Task<ICollection<Droit>> DroitsUser => CurrentUser.ContinueWith(x => x.Result?.Droits!);
        public Task<bool> isSYSAdmin => CurrentUser.ContinueWith(x => x.Result?.Roles?.Any(x => x.Code == Roles.SYSADMIN) ?? false);
        public Task<bool> isAdmin => CurrentUser.ContinueWith(x => x.Result?.Roles?.Any(x => x.Code == Roles.ADMIN_FULL_ACCESS) ?? false);
        public Task<bool> IsAdminOrSysAdmin => CurrentUser.ContinueWith(x => x.Result?.Roles?.Any(x => x.Code == Roles.ADMIN_FULL_ACCESS || x.Code == Roles.SYSADMIN) ?? false);
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
            retour.Nom = user.Membre?.Nom ?? user.Droits?.Count.ToString();
            retour.Prenom = user.Membre?.Prenom;
            retour.TypeMembre = user.Membre?.TypeMembre.Code;
            retour.IsConnected = true;
            return retour;

        }




        private async Task<IEnumerable<Centre>> _LoadReadCentres(params Modules[] modules)
        {
            if(_CachedCentres != null) return _CachedCentres;
            if (await IsAdminOrSysAdmin)
                return _CachedCentres ??= (await _helios.Centre.AsNoTracking()
                    .ToListAsync())
                    .DistinctBy(x => x.Id);
            var _centre = (await DroitsUser)?
             .Where(x => x.Module != null && x.Centre != null)
             .Where(x => modules.ToList().Contains(x.Module!.Code))
             .Select(x => x.Centre!)
             .DistinctBy(x => x.Id);

            if (_centre == null) 
                throw new Exception("[001] Accès refusé");
            return _CachedCentres ??= _centre;
        }
        private IEnumerable<Centre>? _CachedCentres;
        public Task<IEnumerable<Centre>> Centres => _LoadReadCentres();


        public Task<IEnumerable<Centre>> CentresWithReadRole(params Modules[] modules)=> _LoadReadCentres(modules);



        private async Task<Boolean> _ActionsIsAllowedForCentre(int centreId, Modules module, Droits droit)
        {

            if (await IsAdminOrSysAdmin) return true;

            return (await DroitsUser)?
            .Where(x => x.Module != null && x.Centre != null)
            .Any(x => module == x.Module!.Code && centreId == x.Centre!.Id && droit == x.Code) ?? false;
        }



        private async Task<Boolean> _ActionsIsAllowedForCentre(Centre centre, Modules module, Droits droit)
        {
            return await _ActionsIsAllowedForCentre(centre.Id, module, droit);
        }

        private async Task<Boolean> _ActionsIsAllowedForMembre(Membre membre, Modules module, Droits droit)
        {
            if (await IsAdminOrSysAdmin) return true;
            var _membre = await _helios.Membres.Include(x => x.Centre)
                .FirstOrDefaultAsync(x => x.Id == membre.Id);
            if (_membre == null) throw new Exception("[003] Accès refusé");
            return await _ActionsIsAllowedForCentre(_membre.Centre!, module, droit);
        }
        public async Task<Boolean> ActionsIsAllowedForMembre(Membre? membre, Modules module, Droits droit)
        {
            if (membre?.Id == null) throw new KeyNotFoundException($"Membre {membre?.Id} not found or access denied");
            var result = await _ActionsIsAllowedForMembre(membre, module, droit);
            if(result==false) throw new Exception("[002] Accès refusé");
            return result;
        }
        public async Task<Boolean> ActionsIsAllowedForCentre(int? centreId, Modules module, Droits droit)
        {
            if (centreId == null) throw new KeyNotFoundException($"Centre {centreId} not found or access denied");
            if (await IsAdminOrSysAdmin) return true;
            return await _ActionsIsAllowedForCentre(centreId.Value, module, droit);
        }

    }
}
