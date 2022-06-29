using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Baseball1.Dtos;

namespace Baseball1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FranchiseController : ControllerBase
    {
        private readonly LahmanAccessContext _context;

        public FranchiseController(LahmanAccessContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public async Task<ActionResult<List<TeamsFranchise>>> Get()
        {
            var franchises = await _context.TeamsFranchises.ToListAsync();
            return Ok(franchises);
        }
    }
}
