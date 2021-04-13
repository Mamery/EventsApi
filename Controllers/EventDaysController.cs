using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventsApi.Data;
using EventsApi.Models.Entities;

namespace EventsApi.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventDaysController : ControllerBase
    {
        private readonly EventsApiContext _context;

        public EventDaysController(EventsApiContext context)
        {
            _context = context;
        }

        //// GET: api/EventDays
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<EventDay>>> GetEventDay()
        //{
        //    return await _context.EventDay.ToListAsync();
        //}

        // GET: api/EventDays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventDay>> GetEventDay(int id)
        {
            var eventDay = await _context.EventDay.FindAsync(id);

            if (eventDay == null)
            {
                return NotFound();
            }

            return eventDay;
        }

        // PUT: api/EventDays/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventDay(int id, EventDay eventDay)
        {
            if (id != eventDay.Id)
            {
                return BadRequest();
            }

            _context.Entry(eventDay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventDayExists(id))
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

        // POST: api/EventDays
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EventDay>> PostEventDay(EventDay eventDay)
        {
            _context.EventDay.Add(eventDay);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventDay", new { id = eventDay.Id }, eventDay);
        }

        // DELETE: api/EventDays/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventDay(int id)
        {
            var eventDay = await _context.EventDay.FindAsync(id);
            if (eventDay == null)
            {
                return NotFound();
            }

            _context.EventDay.Remove(eventDay);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventDayExists(int id)
        {
            return _context.EventDay.Any(e => e.Id == id);
        }
    }
}
