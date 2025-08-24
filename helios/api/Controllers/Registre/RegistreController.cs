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

        [HttpGet("civilites")]
        public async Task<IEnumerable<CiviliteDTO>> GetCivilties()
        {
            return await helios.Civilites.Select(x => (CiviliteDTO)x).ToListAsync();
        }   

        [HttpGet("centres")]
        public async Task<IEnumerable<CentreDTO>> GetCentres()
        {
            return (await OsContext.CentresWithRight(Modules.Registre)).Select(x => (CentreDTO)x);
        }


        [HttpGet("aspects")]
        public async Task<IEnumerable<TypeMembreDTO>> GetAspects()
        {
            return await helios.TypeMembres.Select(x => (TypeMembreDTO)x).ToListAsync();
        }

        [HttpGet("statuts")]
        public async Task<IEnumerable<StatutMembreDTO>> GetStatuts()
        {
            return await helios.StatutMembres.Select(x => (StatutMembreDTO)x).ToListAsync();
        }

        [HttpPost("membres")]
        public async Task<DataPager<MembreDTO>> Get(MembreFiltre? filtre, [FromQuery] DataPagerQueryParams pagerQueryParams)
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
                      .WhereIf(String.IsNullOrWhiteSpace(filtre?.Statut) == false, x => x.StatutMembre != null && x.StatutMembre.Description!.ToUpper().Contains(filtre!.Statut!.ToUpper()))
                      .WhereIf(filtre?.L_villes != null, x => filtre!.L_villes!.Contains(x.Ville))
                      .WhereIf(filtre?.L_pays != null, x => filtre!.L_pays!.Contains(x.Pays))
                      .WhereIf(filtre?.L_centres != null, x => filtre!.L_centres!.Contains(x.Centre!.Libelle))
                      .WhereIf(filtre?.L_aspects != null, x => filtre!.L_aspects!.Contains(x.TypeMembre.Code))
                      .WhereIf(filtre?.L_statuts != null, x => filtre!.L_statuts!.Contains(x.StatutMembre.Code))
                      .Include(x => x.TypeMembre)
                      .Include(x => x.Centre)
                      .Include(x=>x.Civilite)
                      .Include(x => x.StatutMembre)
                      .DataPage(x => x, pagerQueryParams, MembreDTO.FromMembre);




        }

        [HttpGet("membres/membre/:id")]
        public async Task<MembreDTO> GetMembreById(int id)
        {
            var centres = (await OsContext.CentresWithRight(Modules.Registre))?
                .Select(x => x.Id)
                .ToList();
            if (centres == null) throw new NotEnoughPrivilegeException("No centre found");
            var membre = await helios.Membres
                      .Where(x => centres.Contains(x.Centre!.Id))
                      .Where(x => x.Id == id)
                      .Include(x => x.TypeMembre)
                      .Include(x => x.Centre)
                      .Include(x => x.StatutMembre)
                      .Include(x=>x.Civilite)
                      .Include(x => x.Parents!).ThenInclude(x => x.TypeMembre!)
                      .Include(x => x.Enfants!).ThenInclude(x => x.TypeMembre!)
                      .FirstOrDefaultAsync();
            if (membre == null) throw new KeyNotFoundException($"Membre {id} not found or access denied");
            return membre;
        }

        [HttpGet("membres/family/:id")]
        public async Task<FamilyDTO> GetFamilyById(int id)
        {
            var centres = (await OsContext.CentresWithRight(Modules.Registre))?
                .Select(x => x.Id)
                .ToList();
            if (centres == null) throw new NotEnoughPrivilegeException("No centre found");
            var membre = await helios.Membres
                      .Where(x => centres.Contains(x.Centre!.Id))
                      .Where(x => x.Id == id)
                      .Include(x => x.Parents!).ThenInclude(x => x.StatutMembre)
                      .Include(x => x.Parents!).ThenInclude(x => x.TypeMembre)
                      .Include(x => x.Parents!).ThenInclude(x => x.Centre)
                      .Include(x => x.Enfants!).ThenInclude(x => x.StatutMembre)
                      .Include(x => x.Enfants!).ThenInclude(x => x.TypeMembre)
                      .Include(x => x.Enfants!).ThenInclude(x => x.Centre)
                      .FirstOrDefaultAsync();
            if (membre == null) throw new KeyNotFoundException($"Membre {id} not found or access denied");
            return membre;
        }

        [HttpPut("membres/membre/:id")]
        public async Task<MembreDTO> UpdateMembre(int id, MembreDTO membreDto)
        {
            var centres = (await OsContext.CentresWithRight(Modules.Registre))?
                .Select(x => x.Id)
                .ToList();
            if (centres == null) throw new NotEnoughPrivilegeException("No centre found");
            var membre = await helios.Membres
                      .Where(x => centres.Contains(x.Centre!.Id))
                      .Where(x => x.Id == id)
                      .Include(x => x.TypeMembre)
                      .Include(x => x.Centre)
                      .Include(x => x.StatutMembre)
                      .FirstOrDefaultAsync();
            if (membre == null) throw new KeyNotFoundException($"Membre {id} not found or access denied");
            membre.Nom = membreDto.Nom;
            membre.Prenom = membreDto.Prenom;
            membre.Email = membreDto.Email;
            membre.Telephone = membreDto.Telephone;
            membre.Portable = membreDto.Portable;
            membre.Adresse = membreDto.Adresse;
            membre.CodePostal = membreDto.CodePostal;
            membre.Ville = membreDto.Ville;
            membre.Pays = membreDto.Pays;
            // Update TypeMembre, Centre and StatutMembre
            if (membre.TypeMembre != null && membre.TypeMembre.Code != membreDto.TypeMembre.code)
            {
                var _typeMembre = await helios.TypeMembres.FirstOrDefaultAsync(x => x.Code == membreDto.TypeMembre.code);
                if (_typeMembre != null) membre.TypeMembre = _typeMembre;
            }
            if (membre.Centre != null && membre.Centre.Id != membreDto.Centre.Id)
                membre.Centre = await helios.Centre.FirstOrDefaultAsync(x => x.Id == membreDto.Centre.Id);

            if (membre.StatutMembre != null && membre.StatutMembre.Code != membreDto.Statut.code)
            {
                var _statutMembre = await helios.StatutMembres.FirstOrDefaultAsync(x => x.Code == membreDto.Statut.code);
                if (_statutMembre != null) membre.StatutMembre = _statutMembre;

            }
            await helios.SaveChangesAsync();
            return (MembreDTO)membre;
        }

        [HttpPost("membres/membre")]
        public async Task<MembreDTO> CreateMembre(MembreDTO membreDto)
        {
            var centres = (await OsContext.CentresWithRight(Modules.Registre))?
                .Select(x => x.Id)
                .ToList();
            if (centres == null) throw new NotEnoughPrivilegeException("No centre found");

            var membre = new Membre
            {
                Nom = membreDto.Nom,
                Prenom = membreDto.Prenom,
                DateNaissance = membreDto.DateNaissance,                
                Civilite = await getCivilite(membreDto),
                TypeMembre = await getTypeMembre(membreDto),
                Centre = await getCentre(membreDto),
                StatutMembre = await getStatut(membreDto),
                Email = membreDto.Email,
                Telephone = membreDto.Telephone,
                Portable = membreDto.Portable,
                Adresse = membreDto.Adresse,
                CodePostal = membreDto.CodePostal,
                Ville = membreDto.Ville,
                Pays = membreDto.Pays,
                Commentaires = membreDto.Commentaires,
                Connaissances = membreDto.Connaissances,
                Profession = membreDto.Profession,
                EmailValide = false,
            };
           
            await helios.Membres.AddAsync(membre);
            await helios.SaveChangesAsync();
            return (MembreDTO)membre;

            async Task<TypeMembre> getTypeMembre(MembreDTO membreDto)
            {
                if (membreDto.TypeMembre == null)
                    throw new ArgumentNullException("TypeMembre is required");
                var _typeMembre = await helios.TypeMembres.FirstOrDefaultAsync(x => x.Code == membreDto.TypeMembre.code);
                if (_typeMembre == null) throw new KeyNotFoundException($"TypeMembre {membreDto.TypeMembre.code} not found");
                return _typeMembre;

            }

            async Task<Centre> getCentre(MembreDTO membreDto)
            {
                if (membreDto.Centre == null)
                    throw new ArgumentNullException("Centre is required");
                var _centre = await helios.Centre.FirstOrDefaultAsync(x => x.Id == membreDto.Centre.Id);
                if (_centre == null) throw new KeyNotFoundException($"Centre {membreDto.Centre.Id} not found");
                return _centre;
            }

            async Task<StatutMembre> getStatut(MembreDTO membreDto)
            {
                if (membreDto.Statut == null)
                    throw new ArgumentNullException("Statut is required");
                var _statutMembre = await helios.StatutMembres.FirstOrDefaultAsync(x => x.Code == membreDto.Statut.code);
                if (_statutMembre == null) throw new KeyNotFoundException($"Statut {membreDto.Statut.code} not found");
                return _statutMembre;
            }

            async Task<Civilite> getCivilite(MembreDTO membreDto)
            {
                if (membreDto.Civilite == null)
                    throw new ArgumentNullException("Civilite is required");
                var _civilite = await helios.Civilites.FirstOrDefaultAsync(x => x.Code == membreDto.Civilite.code);
                if (_civilite == null) throw new KeyNotFoundException($"Civilite {membreDto.Civilite.code} not found");
                return _civilite;
            }
        }
    }

}
