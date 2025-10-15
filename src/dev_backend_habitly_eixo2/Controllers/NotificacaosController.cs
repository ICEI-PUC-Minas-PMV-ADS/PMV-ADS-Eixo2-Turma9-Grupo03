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
    public class NotificacaosController : Controller
    {
        private readonly AppDbContext _context;

        public NotificacaosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Notificacaos
        public async Task<IActionResult> Index()
        {
              return View(await _context.Notificacoes.ToListAsync());
        }

        // GET: Notificacaos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Notificacoes == null)
            {
                return NotFound();
            }

            var notificacao = await _context.Notificacoes
                .FirstOrDefaultAsync(m => m.IdNotificacao == id);
            if (notificacao == null)
            {
                return NotFound();
            }

            return View(notificacao);
        }

        // GET: Notificacaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Notificacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNotificacao,IdUsuario,Mensagem,DataHora")] Notificacao notificacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notificacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(notificacao);
        }

        // GET: Notificacaos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Notificacoes == null)
            {
                return NotFound();
            }

            var notificacao = await _context.Notificacoes.FindAsync(id);
            if (notificacao == null)
            {
                return NotFound();
            }
            return View(notificacao);
        }

        // POST: Notificacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdNotificacao,IdUsuario,Mensagem,DataHora")] Notificacao notificacao)
        {
            if (id != notificacao.IdNotificacao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notificacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotificacaoExists(notificacao.IdNotificacao))
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
            return View(notificacao);
        }

        // GET: Notificacaos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Notificacoes == null)
            {
                return NotFound();
            }

            var notificacao = await _context.Notificacoes
                .FirstOrDefaultAsync(m => m.IdNotificacao == id);
            if (notificacao == null)
            {
                return NotFound();
            }

            return View(notificacao);
        }

        // POST: Notificacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Notificacoes == null)
            {
                return Problem("Entity set 'AppDbContext.Notificacoes'  is null.");
            }
            var notificacao = await _context.Notificacoes.FindAsync(id);
            if (notificacao != null)
            {
                _context.Notificacoes.Remove(notificacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotificacaoExists(string id)
        {
          return _context.Notificacoes.Any(e => e.IdNotificacao == id);
        }
    }
}
