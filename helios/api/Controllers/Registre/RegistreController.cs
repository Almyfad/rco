using Helios.Context.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Helios.Controllers.Registre
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistreController : HeliosControllerBase
    {
        public RegistreController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
        
        [HttpGet("centres")]
        public async Task<IEnumerable<CentreOutput>> GetCentres()
        {
            return (await OsContext.CentresWithRight(Modules.Registre)).Select(x => (CentreOutput)x);
        }

        [HttpGet("aspects")]
        public async Task<IEnumerable<TypeMembreOutput>> GetAspects()
        {
            return await helios.TypeMembres.Select(x => (TypeMembreOutput)x).ToListAsync();
        }

        [HttpPost("membres")]
    public async Task<DataPager<MembreOutput>> Get(MembreFiltre? filtre, [FromQuery] DataPagerQueryParams pagerQueryParams)
        {
            var centres = (await OsContext.CentresWithRight(Modules.Registre))?
                .Select(x => x.Id)
                .ToList();
            if (centres == null) throw new NotEnoughPrivilegeException("No centre found");

            return await helios.Membres
                      .Where(x => centres.Contains(x.Centre!.Id))
                      .WhereIf(String.IsNullOrWhiteSpace(filtre?.Nom) == false, x => x.Nom.ToUpper().Contains(filtre!.Nom!.ToUpper()))
                      .WhereIf(String.IsNullOrWhiteSpace(filtre?.Prenom) == false, x => x.Prenom.ToUpper().Contains(filtre!.Prenom!.ToUpper()))
                      .WhereIf(String.IsNullOrWhiteSpace(filtre?.Email) == false, x => x.Email != null && x.Email.ToUpper().Contains(filtre!.Email!.ToUpper()))
                      .WhereIf(String.IsNullOrWhiteSpace(filtre?.Ville) == false, x => x.Ville != null && x.Ville.ToUpper().Contains(filtre!.Ville!.ToUpper()))
                      .WhereIf(String.IsNullOrWhiteSpace(filtre?.Pays) == false, x => x.Pays != null && x.Pays.ToUpper().Contains(filtre!.Pays!.ToUpper()))
                      .WhereIf(String.IsNullOrWhiteSpace(filtre?.Centre) == false, x => x.Centre != null && x.Centre.Libelle.ToUpper().Contains(filtre!.Centre!.ToUpper()))
                      .WhereIf(String.IsNullOrWhiteSpace(filtre?.Aspect) == false, x => x.TypeMembre != null && x.TypeMembre.Description!.Contains(filtre!.Aspect!.ToUpper()))
                      .WhereIf(filtre?.L_villes != null, x => filtre!.L_villes!.Contains(x.Ville))
                      .WhereIf(filtre?.L_pays != null, x => filtre!.L_pays!.Contains(x.Pays))
                      .WhereIf(filtre?.L_centres != null, x => filtre!.L_centres!.Contains(x.Centre!.Libelle))
                      .WhereIf(filtre?.L_aspects != null, x => filtre!.L_aspects!.Contains(x.TypeMembre.Code))
                      .Include(x => x.TypeMembre)
                      .Include(x => x.Centre)
                      .Include(x => x.Parents!).ThenInclude(x => x.TypeMembre!)
                      .Include(x => x.Enfants!).ThenInclude(x => x.TypeMembre!)
                      .DataPage(x => x, pagerQueryParams, MembreOutput.FromMembre);




        }

    }
}
