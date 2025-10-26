using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dev_backend_habitly_eixo2.Models;

namespace dev_backend_habitly_eixo2.Controllers
{
    public class EtiquetasController : Controller
    {
        private readonly AppDbContext _context;

        public EtiquetasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Etiquetas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Etiquetas.ToListAsync());
        }

        // GET: Etiquetas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Etiquetas == null)
            {
                return NotFound();
            }

            var etiqueta = await _context.Etiquetas
                .Include(e => e.Habitos)
                .FirstOrDefaultAsync(m => m.IdEtiqueta == id);
            if (etiqueta == null)
            {
                return NotFound();
            }

            return View(etiqueta);
        }

        // GET: Etiquetas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Etiquetas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEtiqueta,Nome")] Etiqueta etiqueta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(etiqueta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(etiqueta);
        }

        // GET: Etiquetas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Etiquetas == null)
            {
                return NotFound();
            }

            var etiqueta = await _context.Etiquetas.FindAsync(id);
            if (etiqueta == null)
            {
                return NotFound();
            }
            return View(etiqueta);
        }

        // POST: Etiquetas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdEtiqueta,Nome")] Etiqueta etiqueta)
        {
            if (id != etiqueta.IdEtiqueta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(etiqueta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtiquetaExists(etiqueta.IdEtiqueta))
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
            return View(etiqueta);
        }

        // GET: Etiquetas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Etiquetas == null)
            {
                return NotFound();
            }

            var etiqueta = await _context.Etiquetas
                .FirstOrDefaultAsync(m => m.IdEtiqueta == id);
            if (etiqueta == null)
            {
                return NotFound();
            }

            return View(etiqueta);
        }

        // POST: Etiquetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Etiquetas == null)
            {
                return Problem("Entity set 'AppDbContext.Etiquetas'  is null.");
            }
            var etiqueta = await _context.Etiquetas.FindAsync(id);
            if (etiqueta != null)
            {
                // remove association with habitos first
                var habitos = await _context.Habitos.Where(h => h.Etiquetas.Any(e => e.IdEtiqueta == id)).ToListAsync();
                foreach (var hab in habitos)
                {
                    hab.Etiquetas.Remove(etiqueta);
                }

                _context.Etiquetas.Remove(etiqueta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // (Removida) POST: Etiquetas/AddToHabito - a associação via checkboxes na Details foi retirada por redundância.

        // POST: Etiquetas/RemoveFromHabito
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveFromHabito(string idEtiqueta, string idHabito)
        {
            if (string.IsNullOrEmpty(idEtiqueta) || string.IsNullOrEmpty(idHabito))
                return BadRequest();

            var etiqueta = await _context.Etiquetas.FindAsync(idEtiqueta);
            var habito = await _context.Habitos.Include(h => h.Etiquetas).FirstOrDefaultAsync(h => h.IdHabito == idHabito);
            if (etiqueta == null || habito == null)
                return NotFound();

            if (habito.Etiquetas != null && habito.Etiquetas.Any(e => e.IdEtiqueta == idEtiqueta))
            {
                var toRemove = habito.Etiquetas.First(e => e.IdEtiqueta == idEtiqueta);
                habito.Etiquetas.Remove(toRemove);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Details", "Habitoes", new { id = idHabito });
        }

        // POST: Etiquetas/ArchiveHabito
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ArchiveHabito(string idHabito)
        {
            if (string.IsNullOrEmpty(idHabito))
                return BadRequest();

            var habito = await _context.Habitos.FindAsync(idHabito);
            if (habito == null)
                return NotFound();

            // Arquivar: marcar e salvar. Não remove check-ins.
            habito.IsArquivado = true;
            _context.Update(habito);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Habitoes");
        }

        // POST: Etiquetas/CreateAndAddToHabito
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAndAddToHabito(string nome, string idHabito)
        {
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrEmpty(idHabito))
                return BadRequest();

            // Cria nova etiqueta
            var nova = new Etiqueta { IdEtiqueta = Guid.NewGuid().ToString(), Nome = nome };
            _context.Etiquetas.Add(nova);

            // Recupera habito e associa
            var habito = await _context.Habitos.Include(h => h.Etiquetas).FirstOrDefaultAsync(h => h.IdHabito == idHabito);
            if (habito == null)
            {
                // se o hábito não existir, apenas salva a etiqueta
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Etiquetas");
            }

            if (habito.Etiquetas == null)
                habito.Etiquetas = new List<Etiqueta>();

            habito.Etiquetas.Add(nova);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Habitoes", new { id = idHabito });
        }

        private bool EtiquetaExists(string id)
        {
          return _context.Etiquetas.Any(e => e.IdEtiqueta == id);
        }
    }
}
