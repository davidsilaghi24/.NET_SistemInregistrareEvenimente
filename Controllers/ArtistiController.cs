using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemInregistrareEvenimente.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemInregistrareEvenimente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ArtistiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Artisti
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtisti()
        {
            return await _context.Artisti.ToListAsync();
        }

        // GET: api/Artisti/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(int id)
        {
            var artist = await _context.Artisti.FindAsync(id);

            if (artist == null)
            {
                return NotFound();
            }

            return artist;
        }

        // POST: api/Artisti
        [HttpPost]
        public async Task<ActionResult<Artist>> PostArtist(Artist artist)
        {
            _context.Artisti.Add(artist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArtist", new { id = artist.Id }, artist);
        }

        // PUT: api/Artisti/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtist(int id, Artist artist)
        {
            if (id != artist.Id)
            {
                return BadRequest();
            }

            _context.Entry(artist).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Artisti/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            var artist = await _context.Artisti.FindAsync(id);
            if (artist == null)
            {
                return NotFound();
            }

            _context.Artisti.Remove(artist);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
