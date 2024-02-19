using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemInregistrareEvenimente.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemInregistrareEvenimente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvenimenteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EvenimenteController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Evenimente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Eveniment>>> GetEvenimente()
        {
            return await _context.Evenimente.Include(e => e.Locatie).Include(e => e.Bilete).ToListAsync();
        }

        // GET: api/Evenimente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Eveniment>> GetEveniment(int id)
        {
            var eveniment = await _context.Evenimente.Include(e => e.Locatie).Include(e => e.Bilete)
                            .FirstOrDefaultAsync(e => e.Id == id);

            if (eveniment == null)
            {
                return NotFound();
            }

            return eveniment;
        }

        // POST: api/Evenimente
        [HttpPost]
        public async Task<ActionResult<Eveniment>> PostEveniment(Eveniment eveniment)
        {
            _context.Evenimente.Add(eveniment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEveniment", new { id = eveniment.Id }, eveniment);
        }

        // PUT: api/Evenimente/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEveniment(int id, Eveniment eveniment)
        {
            if (id != eveniment.Id)
            {
                return BadRequest();
            }

            _context.Entry(eveniment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Evenimente.Any(e => e.Id == id))
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

        // DELETE: api/Evenimente/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEveniment(int id)
        {
            var eveniment = await _context.Evenimente.FindAsync(id);
            if (eveniment == null)
            {
                return NotFound();
            }

            _context.Evenimente.Remove(eveniment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
