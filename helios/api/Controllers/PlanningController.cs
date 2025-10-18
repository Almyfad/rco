using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Helios.Context.Models;
using Microsoft.AspNetCore.Authentication;
using Helios.Dto;

namespace Helios.Controllers.Planning
{

    [Route("api/[controller]")]
    [ApiController]
    public class PlanningController : HeliosControllerBase
    {

        public PlanningController(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        [HttpGet("typeactivities")]
        public async Task<IEnumerable<TypeActiviteDTO>> GetTypeActivities()
        {
            return await helios.TypeActivitees
            .Select(x => (TypeActiviteDTO)x).ToListAsync();
        }

        [HttpPost("create")]
        public async Task<ActionResult<ActivityDTO>> CreateActivity([FromBody] CreateActivityDTO activity)
        {
            var centre = await helios.Centre.FindAsync(activity.CentreId);
            if (centre == null) return BadRequest("Centre not found");
            var type = await helios.TypeActivitees.FindAsync(activity.TypeActiviteeId);
            if (type == null) return BadRequest("Type not found");
            var programme = await helios.Programmes.FindAsync(activity.ProgrammeId);
            if (programme == null) return BadRequest("Programme not found");
            var newActivity = new Activitee
            {
                Libelle = activity.Libelle,
                Description = activity.Description,
                DateDebut = activity.DateDebut,
                DateFin = activity.DateFin,
                Centre = centre,
                TypeActivitee = type,
                Programme = programme
            };
            helios.Activitees.Add(newActivity);
            await helios.SaveChangesAsync();
            return CreatedAtAction(nameof(GetActivities), new { id = newActivity.Id }, (ActivityDTO)newActivity);
        }

        [HttpPut("activitie/:id/hours")]
        public async Task<ActionResult<ActivityDTO>> UpdateActivityHours(int id, [FromBody] UpdateActivityHoursDTO hours)
        {
            var existingActivity = await helios.Activitees.FindAsync(id);
            if (existingActivity == null) return NotFound("Activity not found");
            existingActivity.DateDebut = hours.DateDebut;
            existingActivity.DateFin = hours.DateFin;
            await helios.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut("activitie/:id")]
        public async Task<ActionResult<ActivityDTO>> UpdateActivity(int id, [FromBody] CreateActivityDTO activity)
        {
            var existingActivity = await helios.Activitees
                .Include(a => a.Centre)
                .Include(a => a.TypeActivitee)
                .Include(a => a.Programme)
                .FirstOrDefaultAsync(a => a.Id == id);
            if (existingActivity == null) return NotFound("Activity not found");
            var centre = await helios.Centre.FindAsync(activity.CentreId);
            if (centre == null) return BadRequest("Centre not found");
            var type = await helios.TypeActivitees.FindAsync(activity.TypeActiviteeId);
            if (type == null) return BadRequest("Type not found");
            var programme = await helios.Programmes.FindAsync(activity.ProgrammeId);
            if (programme == null) return BadRequest("Programme not found");
            existingActivity.Libelle = activity.Libelle;
            existingActivity.Description = activity.Description;
            existingActivity.DateDebut = activity.DateDebut;
            existingActivity.DateFin = activity.DateFin;
            existingActivity.Centre = centre;
            existingActivity.TypeActivitee = type;
            existingActivity.Programme = programme;
            await helios.SaveChangesAsync();
            return Ok((ActivityDTO)existingActivity);
        }
        [HttpDelete("activitie/:id")]
        public async Task<IActionResult> DeleteActivity(int id)
        {
            var existingActivity = await helios.Activitees.FindAsync(id);
            if (existingActivity == null) return NotFound("Activity not found");
            helios.Activitees.Remove(existingActivity);
            await helios.SaveChangesAsync();
            return NoContent();
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
        [HttpGet("centres/:id/programmes")]
        public async Task<IEnumerable<ProgrammeDTO>> GetCentresProgrammes(int id)
        {
            var prog = await helios.Centre
            .Include(a => a.Programmes)
            .Where(a => a.Programmes!.Any() == true && a.Id == id)
            .SelectMany(x => x.Programmes!)
            .Select(x => (ProgrammeDTO?)x).ToListAsync();
            return prog!;

        }

    }
}