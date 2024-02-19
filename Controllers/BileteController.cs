using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemInregistrareEvenimente.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemInregistrareEvenimente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BileteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BileteController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Bilete
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bilet>>> GetBilete()
        {
            return await _context.Bilete.Include(b => b.Eveniment).ToListAsync();
        }

        // GET: api/Bilete/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bilet>> GetBilet(int id)
        {
            var bilet = await _context.Bilete.Include(b => b.Eveniment).FirstOrDefaultAsync(b => b.Id == id);

            if (bilet == null)
            {
                return NotFound();
            }

            return bilet;
        }

        // POST: api/Bilete
        [HttpPost]
        public async Task<ActionResult<Bilet>> PostBilet(Bilet bilet)
        {
            _context.Bilete.Add(bilet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBilet", new { id = bilet.Id }, bilet);
        }

        // PUT: api/Bilete/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBilet(int id, Bilet bilet)
        {
            if (id != bilet.Id)
            {
                return BadRequest();
            }

            _context.Entry(bilet).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Bilete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBilet(int id)
        {
            var bilet = await _context.Bilete.FindAsync(id);
            if (bilet == null)
            {
                return NotFound();
            }

            _context.Bilete.Remove(bilet);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
