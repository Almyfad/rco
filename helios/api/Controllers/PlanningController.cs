using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Helios.Context.Models;
using Microsoft.AspNetCore.Authentication;

namespace Helios.Controllers.Planning
{


    [Route("api/[controller]")]
    [ApiController]
    public class PlanningController : HeliosControllerBase
    {

        public PlanningController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }


        [HttpGet("activities")]
        public async Task<IEnumerable<ActivityDTO>> GetActivities()
        {
            return await helios.Activitees
            .Include(a => a.TypeActivitee)
            .Include(a => a.Centre)
            .Include(a => a.Programme)
            .Select(x => (ActivityDTO)x).ToListAsync();
        }

        [HttpGet("programmes/flat")]
        public async Task<IEnumerable<FlatProgrammeDTO>> GetProgrammes()
        {
            var p = await helios.Programmes
            .Include(a => a.Centres)
            .Select(x => x!).ToListAsync();
            return p.SelectMany(x => x.ToFlatDTO()!);
        }


        [HttpGet("centres/programmes")]
        public async Task<IEnumerable<CentreProgrammeDTO>> GetCentresProgrammes()
        {
            var centre = await helios.Centre
            .Include(a => a.Programmes)
            .Where(a => a.Programmes!.Any() == true)
            .Select(x => (CentreProgrammeDTO?)x).ToListAsync();
            return centre.Where(c => c is not null)!;

        }

    }
}