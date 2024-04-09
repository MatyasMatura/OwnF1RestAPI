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
    public class DriversController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DriversController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/drivers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Driver>>> GetDrivers(int? points, int? wins, int? titles, int? podiums, string teamname, string alphabetOrder)
        {
            IQueryable<Driver> teams = _context.Drivers;
            if (points != null)
                teams = teams.Where(t => t.Points == points);
            if (wins != null)
                teams = teams.Where(t => t.Wins == wins);
            if (titles != null)
                teams = teams.Where(t => t.Titles == titles);
            if (podiums != null)
                teams = teams.Where(t => t.Podiums == podiums);
            if (!String.IsNullOrEmpty(teamname))
                teams = teams.Where(t => t.TeamName.Contains(teamname));
            if (!String.IsNullOrEmpty(alphabetOrder))
            {
                if (alphabetOrder.ToLower() == "descending")
                    teams = teams.OrderByDescending(t => t.Name);
            }


            return await teams.ToListAsync<Driver>();
        }
        // GET: api/drivers/Alfons
        [HttpGet("{name}")]
        public async Task<ActionResult<Driver>> GetDriver(string name)
        {
            Driver driver = await _context.Drivers.FindAsync(name);
            if (driver == null)
                return NotFound("Driver not found!");
            else
                return Ok(driver);
        }
        // PUT: api/drivers/Alfons
        [HttpPut("{name}")]
        public async Task<IActionResult> EditDriver(string name, Driver driver)
        {
            if (name != driver.Name)
                return BadRequest("Cannot change the name!");
            if (!(_context.Teams.Any(t => t.Name == driver.TeamName)))
                return NotFound("This team doesnt exist");
            if (!(_context.Drivers.Any(t => t.Name == name)))
                return NotFound("Driver not found!");
            else
            {
                _context.Entry(driver).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return Ok(driver);
            }
        }
        // PUT: api/drivers/Alfons/points
        [HttpPut("{name}/points")]
        public async Task<IActionResult> EditDriverPoints(string name, int? points)
        {
            if (points == null)
                return BadRequest("You have to assign a value");

            if (!(_context.Drivers.Any(t => t.Name == name)))
                return NotFound("Driver not found!");
            else
            {
                Driver driver = await _context.Drivers.FindAsync(name);
                driver.Points = points.Value;
                _context.Entry(driver).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return Ok(driver);
            }
        }
        // PUT: api/drivers/Alfons/wins
        [HttpPut("{name}/wins")]
        public async Task<IActionResult> EditDriverWins(string name, int? wins)
        {
            if (wins == null)
                return BadRequest("You have to assign a value");

            if (!(_context.Drivers.Any(t => t.Name == name)))
                return NotFound("Driver not found!");
            else
            {
                Driver driver = await _context.Drivers.FindAsync(name);
                driver.Wins = wins.Value;
                _context.Entry(driver).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return Ok(driver);
            }
        }
        // PUT: api/drivers/Alfons/podiums
        [HttpPut("{name}/podiums")]
        public async Task<IActionResult> EditDriverPodiums(string name, int? podiums)
        {
            if (podiums == null)
                return BadRequest("You have to assign a value");

            if (!(_context.Drivers.Any(t => t.Name == name)))
                return NotFound("Driver not found!");
            else
            {
                Driver driver = await _context.Drivers.FindAsync(name);
                driver.Podiums = podiums.Value;
                _context.Entry(driver).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return Ok(driver);
            }
        }
        // PUT: api/drivers/Alfons/titles
        [HttpPut("{name}/titles")]
        public async Task<IActionResult> EditDriverTitles(string name, int? titles)
        {
            if (titles == null)
                return BadRequest("You have to assign a value");

            if (!(_context.Drivers.Any(t => t.Name == name)))
                return NotFound("Driver not found!");
            else
            {
                Driver driver = await _context.Drivers.FindAsync(name);
                driver.Titles = titles.Value;
                _context.Entry(driver).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return Ok(driver);
            }
        }
        // PUT: api/drivers/Alfons/teamname
        [HttpPut("{name}/teamname")]
        public async Task<IActionResult> EditDriverTeamname(string name, string teamname)
        {
            if (String.IsNullOrEmpty(teamname))
                return BadRequest("You have to assign a value");
            if (!(_context.Teams.Any(t => t.Name == teamname)))
                return NotFound("This team doesnt exist");
            if (!(_context.Drivers.Any(t => t.Name == name)))
                return NotFound("Driver not found!");
            else
            {
                Driver driver = await _context.Drivers.FindAsync(name);
                driver.TeamName = teamname;
                _context.Entry(driver).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return Ok(driver);
            }
        }
        // POST: api/drivers
        [HttpPost]
        public async Task<ActionResult<Driver>> CreateDriver(Driver driver)
        {
            if (!(_context.Teams.Any(t => t.Name == driver.TeamName)))
                return BadRequest("This team doesnt exist!");

            _context.Drivers.Add(driver);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDriver", new { name = driver.Name }, driver);
        }
        // DELETE: api/drivers/Alfons
        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteDriver(string name)
        {
            Driver driver = await _context.Drivers.FindAsync(name);
            if (driver == null)
                return NotFound();

            _context.Drivers.Remove(driver);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        // GET: api/drivers/count
        [HttpGet("count")]
        public int GetDriversCount()
        {
            return _context.Drivers.Count();
        }

    }
}
