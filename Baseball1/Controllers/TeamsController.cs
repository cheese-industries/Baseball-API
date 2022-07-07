using Microsoft.AspNetCore.Mvc;

namespace Baseball1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly LahmanAccessContext _context;

        public TeamsController(LahmanAccessContext context)
        {
            _context = context;
        }

        [HttpGet("season")]
        public async Task<ActionResult<List<Team>>> GetTeams(int yearID)
        {
            //var teams = await _context.Teams.Include(t => t.TeamSeasons).SingleOrDefaultAsync(p => p.YearId == yearId);
            var teams = await _context.Teams.ToListAsync();
            if (teams == null)
                return NotFound();
            return Ok(teams);
        }
    }
}
