﻿using Baseball1.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Baseball1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly LahmanAccessContext _context;

        public PersonController(LahmanAccessContext context)
        {
            _context = context;
        }

        [HttpGet("playerlist/{page}")]
        public async Task<ActionResult<List<Person>>> GetPeople(int page)
        {
            var pageResults = 50f;
            var pageCount = Math.Ceiling(_context.People.Count() / pageResults);
            var people = await _context.People
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();
            var response = new PersonParameters
            {
                Persons = people,
                CurrentPage = page,
                Pages = (int)pageCount
            };
            return Ok(response);
        }

        [HttpGet("{BbrefId}")]
        public async Task<ActionResult<Person>> GetPersonById(string BbrefId)
        {
            var person = await _context.People.SingleOrDefaultAsync(p => p.BbrefId == BbrefId);
            if (person == null)
                return BadRequest("Player not found");
            return Ok(person);
        }

        [HttpGet("ByLastName/{NameLast}")]
        public async Task<ActionResult<List<Person>>> GetPersonsByLastName(string NameLast)
        {
            var person = await _context.People.Where(p => p.NameLast == NameLast).ToListAsync();
            if (person == null)
                return BadRequest("Player not found");
            return Ok(person);
        }

        [HttpGet("ByTeam/{TeamId}")]
        public async Task<ActionResult<List<Team>>> GetPersonsByTeamId(string TeamId, int YearId)
        {
            //var person = await _context.People.Include(p => p.BattingSeasons).Where(p => p.BattingSeasons.TeamId == TeamId).ToListAsync();
            var team = await _context.Teams
                .Include(t => t.BattingSeasons)
                .ThenInclude(b => b.Person.NameLast)
                .Where(t => t.TeamId == TeamId && t.YearId == YearId)
                .ToListAsync();
            if (team == null)
                return BadRequest("Team not found");
            return Ok(team);
        }

        [HttpGet("BattingById/{PlayerId}")]
        public async Task<ActionResult<PersonBattingDto>> GetBattingById(string PlayerId)
        {
            var person = await _context.People.Include(p => p.BattingSeasons).SingleOrDefaultAsync(p => p.PlayerId == PlayerId);
            if (person == null)
                return BadRequest("Player not found");
            return Ok(Factories.PersonBattingFactory.ToDto(person));
        }

        [HttpGet("PitchingById/{BbrefId}")]
        public async Task<ActionResult<Person>> GetPitchingById(string BbrefId)
        {
            var person = await _context.People.Include(p => p.PitchingSeasons).SingleOrDefaultAsync(p => p.BbrefId == BbrefId);
            if (person == null)
                return BadRequest("Player not found");
            return Ok(Factories.PersonPitchingFactory.ToDto(person));
        }

        [HttpGet("FieldingById/{BbrefId}")]
        public async Task<ActionResult<Person>> GetFieldingById(string BbrefId)
        {
            var person = await _context.People.Include(f => f.FieldingSeasons).SingleOrDefaultAsync(f => f.BbrefId == BbrefId);
            if (person == null)
                return BadRequest("Player not found");
            return Ok(person);
        }

    }
}
