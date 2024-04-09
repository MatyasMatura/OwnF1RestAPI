using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OwnRestAPI.Data;
using OwnRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OwnRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TeamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/teams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams(int? points, int? wins, int? tChampionships, string carname, string alphabetOrder)
        {
            IQueryable<Team> teams = _context.Teams;
            if (points != null)
                teams = teams.Where(t => t.Points == points);
            if (wins != null)
                teams = teams.Where(t => t.Wins == wins);
            if (tChampionships != null)
                teams = teams.Where(t => t.TeamChampionships == tChampionships);
            if (!String.IsNullOrEmpty(carname))
                teams = teams.Where(t => t.CarName.Contains(carname));
            if (!String.IsNullOrEmpty(alphabetOrder))
            {
                if (alphabetOrder.ToLower() == "descending")
                    teams = teams.OrderByDescending(t => t.Name);
            }

            return await teams.ToListAsync<Team>();
        }
        // GET: api/teams/Ferrari
        [HttpGet("{name}")]
        public async Task<ActionResult<Team>> GetTeam(string name)
        {
            Team team = await _context.Teams.FindAsync(name);
            if (team == null)
                return NotFound("Team not found!");
            else
                return Ok(team);
        }
        // PUT: api/teams/Ferrari
        [HttpPut("{name}")]
        public async Task<IActionResult> EditTeam(string name, Team team)
        {
            if (name != team.Name)
                return BadRequest("Cannot change the name!");

            if (!(_context.Teams.Any(t => t.Name == name)))
                return NotFound("Team not found!");
            else
            {
                _context.Entry(team).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return Ok(team);
            }
        }
        // PUT: api/teams/Ferrari/points
        [HttpPut("{name}/points")]
        public async Task<IActionResult> EditTeamPoints(string name, int? points)
        {
            if (points == null)
                return BadRequest("You have to assign a value");

            if (!(_context.Teams.Any(t => t.Name == name)))
                return NotFound("Team not found!");
            else
            {
                Team team = await _context.Teams.FindAsync(name);
                team.Points = points.Value;
                _context.Entry(team).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return Ok(team);
            }
        }
        // PUT: api/teams/Ferrari/wins
        [HttpPut("{name}/wins")]
        public async Task<IActionResult> EditTeamWins(string name, int? wins)
        {
            if (wins == null)
                return BadRequest("You have to assign a value");

            if (!(_context.Teams.Any(t => t.Name == name)))
                return NotFound("Team not found!");
            else
            {
                Team team = await _context.Teams.FindAsync(name);
                team.Wins = wins.Value;
                _context.Entry(team).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return Ok(team);
            }
        }
        // PUT: api/teams/Ferrari/teamchampionships
        [HttpPut("{name}/teamchampionships")]
        public async Task<IActionResult> EditTeamChampionships(string name, int? tchamps)
        {
            if (tchamps == null)
                return BadRequest("You have to assign a value");

            if (!(_context.Teams.Any(t => t.Name == name)))
                return NotFound("Team not found!");
            else
            {
                Team team = await _context.Teams.FindAsync(name);
                team.TeamChampionships = tchamps.Value;
                _context.Entry(team).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return Ok(team);
            }
        }
        // PUT: api/teams/Ferrari/carname
        [HttpPut("{name}/carname")]
        public async Task<IActionResult> EditTeamCarname(string name, string carname)
        {
            if (String.IsNullOrEmpty(carname))
                return BadRequest("You have to assign a value");

            if (!(_context.Teams.Any(t => t.Name == name)))
                return NotFound("Team not found!");
            else
            {
                Team team = await _context.Teams.FindAsync(name);
                team.CarName = carname;
                _context.Entry(team).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return Ok(team);
            }
        }
        // POST: api/teams
        [HttpPost]
        public async Task<ActionResult<Team>> CreateTeam(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeam", new { name = team.Name }, team);
        }
        // DELETE: api/teams/Ferrari
        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteTeam(string name)
        {
            Team team = await _context.Teams.FindAsync(name);
            if (team == null)
                return NotFound();

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        // GET: api/teams/Ferrari/drivers
        [HttpGet("{name}/drivers")]
        public ActionResult<ICollection<Driver>> GetTeamDrivers(string name)
        {
            Team team = _context.Teams.Include(t => t.Drivers).SingleOrDefault(t => t.Name == name);
            if (team == null)
            {
                return NotFound();
            }

            return team.Drivers.ToList();
        }
        // GET: api/teams/count
        [HttpGet("count")]
        public int GetTeamsCount()
        {
            return _context.Teams.Count();
        }

    }
}