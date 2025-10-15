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
    public class CheckinsController : Controller
    {
        private readonly AppDbContext _context;

        public CheckinsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Checkins
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Checkins.Include(c => c.Habito);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Checkins/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Checkins == null)
            {
                return NotFound();
            }

            var checkin = await _context.Checkins
                .Include(c => c.Habito)
                .FirstOrDefaultAsync(m => m.IdCheckin == id);
            if (checkin == null)
            {
                return NotFound();
            }

            return View(checkin);
        }

        // GET: Checkins/Create
        public IActionResult Create()
        {
            ViewData["IdHabito"] = new SelectList(_context.Habitos, "IdHabito", "IdHabito");
            return View();
        }

        // POST: Checkins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCheckin,IdHabito,DataCheckin")] Checkin checkin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checkin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHabito"] = new SelectList(_context.Habitos, "IdHabito", "IdHabito", checkin.IdHabito);
            return View(checkin);
        }

        // GET: Checkins/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Checkins == null)
            {
                return NotFound();
            }

            var checkin = await _context.Checkins.FindAsync(id);
            if (checkin == null)
            {
                return NotFound();
            }
            ViewData["IdHabito"] = new SelectList(_context.Habitos, "IdHabito", "IdHabito", checkin.IdHabito);
            return View(checkin);
        }

        // POST: Checkins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdCheckin,IdHabito,DataCheckin")] Checkin checkin)
        {
            if (id != checkin.IdCheckin)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checkin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckinExists(checkin.IdCheckin))
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
            ViewData["IdHabito"] = new SelectList(_context.Habitos, "IdHabito", "IdHabito", checkin.IdHabito);
            return View(checkin);
        }

        // GET: Checkins/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Checkins == null)
            {
                return NotFound();
            }

            var checkin = await _context.Checkins
                .Include(c => c.Habito)
                .FirstOrDefaultAsync(m => m.IdCheckin == id);
            if (checkin == null)
            {
                return NotFound();
            }

            return View(checkin);
        }

        // POST: Checkins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Checkins == null)
            {
                return Problem("Entity set 'AppDbContext.Checkins'  is null.");
            }
            var checkin = await _context.Checkins.FindAsync(id);
            if (checkin != null)
            {
                _context.Checkins.Remove(checkin);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckinExists(string id)
        {
          return _context.Checkins.Any(e => e.IdCheckin == id);
        }
    }
}
