using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemInregistrareEvenimente.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemInregistrareEvenimente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocatiiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LocatiiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Locatii
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Locatie>>> GetLocatii()
        {
            return await _context.Locatii.ToListAsync();
        }

        // GET: api/Locatii/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Locatie>> GetLocatie(int id)
        {
            var locatie = await _context.Locatii.FindAsync(id);

            if (locatie == null)
            {
                return NotFound();
            }

            return locatie;
        }

        // POST: api/Locatii
        [HttpPost]
        public async Task<ActionResult<Locatie>> PostLocatie(Locatie locatie)
        {
            _context.Locatii.Add(locatie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocatie", new { id = locatie.Id }, locatie);
        }

        // PUT: api/Locatii/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocatie(int id, Locatie locatie)
        {
            if (id != locatie.Id)
            {
                return BadRequest();
            }

            _context.Entry(locatie).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Locatii/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocatie(int id)
        {
            var locatie = await _context.Locatii.FindAsync(id);
            if (locatie == null)
            {
                return NotFound();
            }

            _context.Locatii.Remove(locatie);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
