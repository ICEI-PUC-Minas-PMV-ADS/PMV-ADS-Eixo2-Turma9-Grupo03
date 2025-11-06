using HabitlyApp.Data;
using HabitlyApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HabitlyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LembretesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LembretesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/lembretes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lembrete>>> GetLembretes()
        {
            return await _context.Lembretes.ToListAsync();
        }

        // POST: api/lembretes
        [HttpPost]
        public async Task<ActionResult<Lembrete>> AddLembrete(Lembrete lembrete)
        {
            _context.Lembretes.Add(lembrete);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetLembretes), new { id = lembrete.Id }, lembrete);
        }

        // DELETE: api/lembretes/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLembrete(int id)
        {
            var lembrete = await _context.Lembretes.FindAsync(id);
            if (lembrete == null)
                return NotFound();

            _context.Lembretes.Remove(lembrete);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // ✅ PUT: api/lembretes/1  ← ADICIONE ESTE BLOCO
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLembrete(int id, Lembrete lembrete)
        {
            if (id != lembrete.Id)
                return BadRequest();

            _context.Entry(lembrete).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Lembretes.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return Ok(lembrete);
        }
    }
}