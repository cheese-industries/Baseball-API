using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Baseball1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BattingController : ControllerBase
    {
        private readonly LahmanAccessContext _context;

        public BattingController(LahmanAccessContext context)
        {
            _context = context;
        }

        [HttpGet("{PlayerId}")]
        public async Task<IActionResult> GetBattingById(string PlayerId)
        {
            var player = await _context.People.FirstOrDefaultAsync(p => p.PlayerId == PlayerId);
            if (player == null)
                return BadRequest("Player not found");
            string playerName = player.NameFirst + " " + player.NameLast;
            /*playerName == null ? NotFound() : Ok(playerName);*/

            var batting = await _context.Battings.Where(p => p.PlayerId == PlayerId).ToListAsync();
            if (batting == null)
                return BadRequest("Player not found");
            return Ok(batting);
        }

    }
}