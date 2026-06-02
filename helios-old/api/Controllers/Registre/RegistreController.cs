using Helios.Context.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;

namespace Helios.Controllers.Registre
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistreController : HeliosControllerBase, IAsyncActionFilter
    {
        IEnumerable<Centre> centresAutorises = [];

        public RegistreController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        [NonAction]
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            centresAutorises = await OsContext.CentresWithReadRole(Modules.Registre);
            await next();
        }

        private IEnumerable<int> centresAutorisesLectureId => centresAutorises.Select(x => x.Id);
        private IQueryable<Membre> MembreAutoriseLecture => helios.Membres.Where(x => centresAutorisesLectureId.Contains(x.Centre!.Id));




        [HttpGet("civilites")]
        public async Task<IEnumerable<CiviliteDTO>> GetCivilties()
        {
            return await helios.Civilites.Select(x => (CiviliteDTO)x).ToListAsync();
        }

        [HttpGet("centres")]
        public async Task<IEnumerable<CentreDTO>> GetCentres()
        {
            return (await OsContext.CentresWithReadRole(Modules.Registre)).Select(x => (CentreDTO)x);
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

        private IQueryable<Membre> Search(MembreFiltre? filtre) =>
                     MembreAutoriseLecture
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
                      .Include(x => x.Civilite)
                      .Include(x => x.StatutMembre);

        [HttpPost("membres/search")]
        public async Task<DataPager<MembreDTO>> SearchMembre(MembreFiltre? filtre, [FromQuery] DataPagerQueryParams pagerQueryParams)
        {
            return await Search(filtre).DataPage(x => x, pagerQueryParams, MembreDTO.FromMembre);
        }

        [HttpPost("membres/parvis/search")]
        public  Task<DataPager<MembreDTO>> SearchMembreParvis(MembreFiltre? filtre, [FromQuery] DataPagerQueryParams pagerQueryParams)
        {
            TypesMembres[] parvisFiltre = [TypesMembres.Contact, TypesMembres.PremierAspect, TypesMembres.DeuxiemeAspect];
            return Search(filtre)
            .Where(x => parvisFiltre.Contains(x.TypeMembre.Code))
            .DataPage(x => x, pagerQueryParams, MembreDTO.FromMembre);
        }
        [HttpPost("membres/contacts/search")]
        public Task<DataPager<MembreDTO>> SearchMembreContacts(MembreFiltre? filtre, [FromQuery] DataPagerQueryParams pagerQueryParams)
        {
            TypesMembres[] contactsFiltre = [TypesMembres.Contact];
            return Search(filtre)
            .Where(x => contactsFiltre.Contains(x.TypeMembre.Code))
            .DataPage(x => x, pagerQueryParams, MembreDTO.FromMembre);
        }
        [HttpPost("membres/jeunesse/search")]
        public Task<DataPager<MembreDTO>> SearchMembreJeunesse(MembreFiltre? filtre, [FromQuery] DataPagerQueryParams pagerQueryParams)
        {
            TypesMembres[] jeunesseFiltre = [TypesMembres.Jeunesse];
            return Search(filtre)
            .Where(x => jeunesseFiltre.Contains(x.TypeMembre.Code))
            .DataPage(x => x, pagerQueryParams, MembreDTO.FromMembre);
        }
        [HttpPost("membres/jeunes/rosicruciens/search")]
        public Task<DataPager<MembreDTO>> SearchMembreJeunesRosicruciens(MembreFiltre? filtre, [FromQuery] DataPagerQueryParams pagerQueryParams)
        {
            TypesMembres[] jeunesRosicruciensFiltre = [
                TypesMembres.EnfantGroupeA,
                TypesMembres.EnfantGroupeB,
                TypesMembres.EnfantGroupeC,
                TypesMembres.EnfantGroupeD,
                TypesMembres.EnfantGroupePreA,
                TypesMembres.Jeunesse,
                TypesMembres.GroupeD,
                TypesMembres.GroupeDPlus,
                TypesMembres.EnfantHorsGroupe
                ];
            return Search(filtre)
            .Where(x => jeunesRosicruciensFiltre.Contains(x.TypeMembre.Code))
            .DataPage(x => x, pagerQueryParams, MembreDTO.FromMembre);
        }

        [HttpGet("membres/simplesearch")]
        public async Task<IEnumerable<SearchMembreDTO>> SimpleSearchMembres([FromQuery] string query)
        {
            return await helios.Membres
                      .Where(x => (x.Nom.Trim() + " " + x.Prenom.Trim()).ToUpper().Contains(query.ToUpper()) || (x.Prenom.Trim() + " " + x.Nom.Trim()).ToUpper().Contains(query.ToUpper()))
                      .OrderBy(x => x.Nom)
                      .ThenBy(x => x.Prenom)
                      .Take(10)
                      .Select(x => (SearchMembreDTO)x)
                      .ToListAsync();
        }

        [HttpGet("membres/{id}")]
        public async Task<MembreDTO> GetMembreById(int id)
        {
            var membre = await MembreAutoriseLecture
                      .Where(x => x.Id == id)
                      .Include(x => x.TypeMembre)
                      .Include(x => x.Centre)
                      .Include(x => x.StatutMembre)
                      .Include(x => x.Civilite)
                      .Include(x => x.Parents!).ThenInclude(x => x.TypeMembre!)
                      .Include(x => x.Enfants!).ThenInclude(x => x.TypeMembre!)
                      .FirstOrDefaultAsync();
            if (membre == null) throw new KeyNotFoundException($"Membre {id} not found or access denied");
            return membre;
        }

        [HttpGet("membres/{id}/family")]
        public async Task<FamilyDTO> GetFamilyById(int id)
        {
            var membre = await MembreAutoriseLecture
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

        [HttpPut("membres/{id}/update")]
        public async Task<MembreDTO> UpdateMembre(int id, MembreDTO membreDto)
        {

            var membre = await MembreAutoriseLecture
                      .Where(x => x.Id == id)
                      .Include(x => x.TypeMembre)
                      .Include(x => x.Centre)
                      .Include(x => x.StatutMembre)
                      .FirstOrDefaultAsync();
            await OsContext.ActionsIsAllowedForMembre(membre, Modules.Registre, Droits.MODIFICATION);

            membre!.Nom = membreDto.Nom;
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

        [HttpPost("membres/create")]
        public async Task<MembreDTO> CreateMembre(MembreDTO membreDto)
        {
            await OsContext.ActionsIsAllowedForCentre(membreDto.Centre.Id, Modules.Registre, Droits.AJOUT);

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

        [HttpPost("membres/{id}/family/update")]
        public async Task<MembreDTO> UpdateFamily(int id, FamilyUpdateDTO family)
        {
            var membre = await MembreAutoriseLecture
                      .Where(x => x.Id == id)
                      .Include(x => x.TypeMembre)
                      .Include(x => x.Centre)
                      .Include(x => x.StatutMembre)
                      .Include(x => x.Civilite)
                      .Include(x => x.Parents!)
                      .Include(x => x.Enfants!)
                      .FirstOrDefaultAsync();
            await OsContext.ActionsIsAllowedForMembre(membre, Modules.Registre, Droits.MODIFICATION);


            membre!.Parents = await getParents(family);
            membre.Enfants = await getEnfants(family);



            await helios.SaveChangesAsync();
            return (MembreDTO)membre;



            async Task<List<Membre>> getParents(FamilyUpdateDTO family)
            {
                if (family.ParentsIds == null || family.ParentsIds.Count() == 0)
                    return new List<Membre>();
                var parents = await helios.Membres
                    .Where(x => family.ParentsIds.Contains(x.Id))
                    .ToListAsync();
                if (parents.Count != family.ParentsIds.Count())
                    throw new KeyNotFoundException($"One or more parents not found");
                return parents;
            }

            async Task<List<Membre>> getEnfants(FamilyUpdateDTO family)
            {
                if (family.EnfantsIds == null || family.EnfantsIds.Count() == 0)
                    return new List<Membre>();
                var enfants = await helios.Membres
                    .Where(x => family.EnfantsIds.Contains(x.Id))
                    .ToListAsync();
                if (enfants.Count != family.EnfantsIds.Count())
                    throw new KeyNotFoundException($"One or more enfants not found");
                return enfants;
            }
        }

        [HttpGet("timeline/types")]
        public async Task<IEnumerable<TimelineMembreType>> GetTypesActivitees()
        {
            return await helios.TimelineMembreTypes.Select(x => (TimelineMembreType)x).ToListAsync();
        }

        [HttpGet("membres/{id}/timeline")]
        public async Task<IEnumerable<TimelineMembreDTO>> GetTimelineByMembreId(int id)
        {
            var membre = await MembreAutoriseLecture
                      .Where(x => x.Id == id)
                      .FirstOrDefaultAsync();
            if (membre == null) throw new KeyNotFoundException($"Membre {id} not found or access denied");
            return await helios.TimelineMembres
                      .Where(x => x.Membre!.Id == id)
                      .Include(x => x.Type)
                      .OrderByDescending(x => x.Date)
                      .Select(x => (TimelineMembreDTO)x)
                      .ToListAsync();
        }
        [HttpDelete("membres/{id}/timeline/{timelineId}")]
        public async Task<IActionResult> DeleteTimeline(int id, int timelineId)
        {

            var membre = await MembreAutoriseLecture
                      .Where(x => x.Id == id)
                      .FirstOrDefaultAsync();
            await OsContext.ActionsIsAllowedForMembre(membre, Modules.Registre, Droits.MODIFICATION);


            var timeline = await helios.TimelineMembres
                .Where(x => x.Id == timelineId && x.Membre!.Id == id)
                .FirstOrDefaultAsync();
            if (timeline == null) throw new KeyNotFoundException($"Timeline {timelineId} not found or access denied");

            helios.TimelineMembres.Remove(timeline);
            await helios.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("membres/{id}/timeline/add")]
        public async Task<IActionResult> AddTimeline(int id, TimelineMembreDTO timelineDto)
        {
            var membre = await MembreAutoriseLecture
                      .Where(x => x.Id == id)
                      .FirstOrDefaultAsync();
            await OsContext.ActionsIsAllowedForMembre(membre, Modules.Registre, Droits.MODIFICATION);

            var timeline = new TimelineMembre
            {
                Membre = membre!,
                Date = timelineDto.Date,
                Type = await getTimeline(),
                Commentaires = timelineDto.Commentaire
            };

            helios.TimelineMembres.Add(timeline);
            await helios.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTimelineByMembreId), new { id = membre!.Id }, (TimelineMembreDTO)timeline);
            async Task<TimelineMembreType> getTimeline()
            {
                return await helios.TimelineMembreTypes.FirstOrDefaultAsync(x => x.Id == timelineDto.Type.Id)
                        ?? throw new KeyNotFoundException($"Timeline type {timelineDto.Type.Id} not found");
            }
        }

        [HttpPut("membres/{id}/timeline/{timelineId}/update")]
        public async Task<IActionResult> UpdateTimeline(int id, int timelineId, TimelineMembreDTO timelineDto)
        {
            var membre = await MembreAutoriseLecture
                      .Where(x => x.Id == id)
                      .FirstOrDefaultAsync();
            await OsContext.ActionsIsAllowedForMembre(membre, Modules.Registre, Droits.MODIFICATION);

            var timeline = await helios.TimelineMembres
                .Where(x => x.Id == timelineId && x.Membre!.Id == id)
                .FirstOrDefaultAsync();
            if (timeline == null) throw new KeyNotFoundException($"Timeline {timelineId} not found or access denied");

            timeline.Date = timelineDto.Date;
            timeline.Type = timelineDto.Type;
            timeline.Commentaires = timelineDto.Commentaire;

            await helios.SaveChangesAsync();
            return NoContent();
        }

    }

}
