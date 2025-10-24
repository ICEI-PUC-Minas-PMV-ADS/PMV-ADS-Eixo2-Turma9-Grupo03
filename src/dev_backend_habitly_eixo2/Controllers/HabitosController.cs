using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dev_backend_habitly_eixo2.Models;

namespace dev_backend_habitly_eixo2.Controllers
{
    public class HabitosController : Controller
    {
        private readonly AppDbContext _context;

        public HabitosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Habitos
        public async Task<IActionResult> Index()
        {
              return View(await _context.Habitos.ToListAsync());
        }

        // GET: Habitos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Habitos == null)
            {
                return NotFound();
            }

            var habito = await _context.Habitos
                .FirstOrDefaultAsync(m => m.IdHabito == id);
            if (habito == null)
            {
                return NotFound();
            }

            return View(habito);
        }

        // GET: Habitos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Habitos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHabito,IdUsuario,TituloHabito,DescricaoHabito,PeriodicidadeHabito,StatusHabito")] Habito habito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(habito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(habito);
        }

        // GET: Habitos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Habitos == null)
            {
                return NotFound();
            }

            var habito = await _context.Habitos.FindAsync(id);
            if (habito == null)
            {
                return NotFound();
            }
            return View(habito);
        }

        // POST: Habitos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdHabito,IdUsuario,TituloHabito,DescricaoHabito,PeriodicidadeHabito,StatusHabito")] Habito habito)
        {
            if (id != habito.IdHabito)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(habito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabitoExists(habito.IdHabito))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(habito);
        }

        // GET: Habitos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Habitos == null)
            {
                return NotFound();
            }

            var habito = await _context.Habitos
                .FirstOrDefaultAsync(m => m.IdHabito == id);
            if (habito == null)
            {
                return NotFound();
            }

            return View(habito);
        }

        // POST: Habitos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Habitos == null)
            {
                return Problem("Entity set 'AppDbContext.Habitos'  is null.");
            }
            var habito = await _context.Habitos.FindAsync(id);
            if (habito != null)
            {
                _context.Habitos.Remove(habito);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HabitoExists(string id)
        {
          return _context.Habitos.Any(e => e.IdHabito == id);
        }
    }
}
