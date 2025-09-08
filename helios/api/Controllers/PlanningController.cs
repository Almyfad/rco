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
            .Include(a=> a.Programme)
            .Select(x => (ActivityDTO)x).ToListAsync();
        }

        [HttpGet("programmes")]
        public async Task<IEnumerable<ProgrammeDTO>> GetProgrammes()
        {
            return await helios.Programmes
            .Select(x => (ProgrammeDTO)x!).ToListAsync();
        }
    }
}