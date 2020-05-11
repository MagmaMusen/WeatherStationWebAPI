using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherStationWebAPI.Data;
using WeatherStationWebAPI.Models;

namespace WeatherStationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherObservationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WeatherObservationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/WeatherObservations
        // Gets last 3 observations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherObservation>>> GetObservations()
        {
            return await _context.Observations.OrderByDescending(o => o.Date).Take(3).ToListAsync();
        }

        // GET: api/WeatherObservations/{date}
        [HttpGet("{date}")]
        public async Task<ActionResult<IEnumerable<WeatherObservation>>> GetObservations(DateTime date)
        {
            return await _context.Observations.Where(o => o.Date == date).OrderByDescending(o => o.Date).ToListAsync();
        }

        // GET: api/WeatherObservations/{date}
        [HttpGet("{startTime}/{endTime}")]
        public async Task<ActionResult<IEnumerable<WeatherObservation>>> GetObservations(DateTime startTime, DateTime endTime)
        {
            return await _context.Observations.Where(o => o.Date >= startTime && o.Date <= endTime).OrderByDescending(o => o.Date).ToListAsync();
        }

        // GET: api/WeatherObservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherObservation>> GetWeatherObservation(long id)
        {
            var weatherObservation = await _context.Observations.FindAsync(id);

            if (weatherObservation == null)
            {
                return NotFound();
            }

            return weatherObservation;
        }

        // PUT: api/WeatherObservations/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeatherObservation(long id, WeatherObservation weatherObservation)
        {
            if (id != weatherObservation.Id)
            {
                return BadRequest();
            }

            _context.Entry(weatherObservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherObservationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/WeatherObservations
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<WeatherObservation>> PostWeatherObservation(WeatherObservation weatherObservation)
        {
            _context.Observations.Add(weatherObservation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeatherObservation", new { id = weatherObservation.Id }, weatherObservation);
        }

        // DELETE: api/WeatherObservations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WeatherObservation>> DeleteWeatherObservation(long id)
        {
            var weatherObservation = await _context.Observations.FindAsync(id);
            if (weatherObservation == null)
            {
                return NotFound();
            }

            _context.Observations.Remove(weatherObservation);
            await _context.SaveChangesAsync();

            return weatherObservation;
        }

        private bool WeatherObservationExists(long id)
        {
            return _context.Observations.Any(e => e.Id == id);
        }
    }
}
