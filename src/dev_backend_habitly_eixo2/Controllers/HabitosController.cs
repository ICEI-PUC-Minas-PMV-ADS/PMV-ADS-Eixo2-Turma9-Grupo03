using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dev_backend_habitly_eixo2.Models;
using dev_backend_habitly_eixo2.Models.DTOs;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace dev_backend_habitly_eixo2.Controllers
{
    [Authorize]
    public class HabitosController : Controller
    {
        private readonly AppDbContext _context;

        public HabitosController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ INDEX — Lista de hábitos com botão de check-in
        public async Task<IActionResult> Index()
        {
            if (!TryGetUserId(out int userId))
                return Challenge();

            var habitos = await _context.Habitos
                .Where(h => h.IdUsuario == userId && !h.IsArquivado)
                .ToListAsync();

            return View(habitos);
        }


        // ✅ DETALHES
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var habito = await _context.Habitos.FirstOrDefaultAsync(m => m.IdHabito == id);

            if (habito == null)
                return NotFound();

            if (!TryGetUserId(out int userId) || habito.IdUsuario != userId)
                return Forbid();

            return View(habito);
        }

        // ✅ CRIAR HÁBITO — GET
        public IActionResult Create()
        {
            return View();
        }

        // ✅ CRIAR HÁBITO — POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("TituloHabito,DescricaoHabito,StatusHabito,DataInicio,DataFim,DiasDaSemana,TagsCsv")] Habito habito)
        {
            if (!TryGetUserId(out int userId)) return Challenge();

            ColetarDiasDaSemana(habito);

            if (habito.DataFim.Date < habito.DataInicio.Date)
                ModelState.AddModelError(nameof(Habito.DataFim), "A Data Fim não pode ser anterior à Data Início.");

            if (ModelState.IsValid)
            {
                habito.IdUsuario = userId;
                _context.Add(habito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(habito);
        }

        // ✅ EDITAR HÁBITO — GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var habito = await _context.Habitos.FindAsync(id);

            if (habito == null)
                return NotFound();

            if (!TryGetUserId(out int userId) || habito.IdUsuario != userId)
                return Forbid();

            return View(habito);
        }

        // ✅ EDITAR HÁBITO — POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("IdHabito,IdUsuario,TituloHabito,DescricaoHabito,StatusHabito,DataInicio,DataFim,DiasDaSemana,TagsCsv,IsArquivado")] Habito habito)
        {
            if (id != habito.IdHabito)
                return NotFound();

            if (!TryGetUserId(out int userId) || habito.IdUsuario != userId)
                return Forbid();

            ColetarDiasDaSemana(habito);

            if (habito.DataFim.Date < habito.DataInicio.Date)
                ModelState.AddModelError(nameof(Habito.DataFim), "A Data Fim não pode ser anterior à Data Início.");

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
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(habito);
        }

        // ✅ APAGAR HÁBITO — GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var habito = await _context.Habitos
                .FirstOrDefaultAsync(m => m.IdHabito == id);

            if (habito == null)
                return NotFound();

            if (!TryGetUserId(out int userId) || habito.IdUsuario != userId)
                return Forbid();

            return View(habito);
        }

        // ✅ APAGAR HÁBITO — POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var habito = await _context.Habitos.FindAsync(id);

            if (habito != null)
            {
                if (!TryGetUserId(out int userId) || habito.IdUsuario != userId)
                    return Forbid();

                _context.Habitos.Remove(habito);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // ====================
        // ✅ CALENDÁRIO
        // ====================
        public async Task<IActionResult> Calendario()
        {
            if (!TryGetUserId(out int userId))
                return Challenge();

            var habitos = await _context.Habitos
                .Where(h => h.IdUsuario == userId && !h.IsArquivado)
                .ToListAsync();

            var eventosCalendario = new List<CalendarioEventoDTO>();
            var checkins = await _context.Checkins.ToListAsync();

            foreach (var habito in habitos)
            {
                var diasValidos = habito.DiasDaSemana
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                DateTime data = habito.DataInicio.Date;
                TimeSpan inicio = habito.DataInicio.TimeOfDay;
                TimeSpan fim = habito.DataFim.TimeOfDay;

                while (data <= habito.DataFim.Date)
                {
                    int diaSemana = (int)data.DayOfWeek;

                    if (diasValidos.Count == 0 || diasValidos.Contains(diaSemana))
                    {
                        bool concluido = checkins.Any(c =>
                            c.IdHabito == habito.IdHabito &&
                            c.DataCheckin.Date == data.Date
)                       ;

                        eventosCalendario.Add(new CalendarioEventoDTO
                        {
                            IdHabito = habito.IdHabito,
                            TituloHabito = habito.TituloHabito,
                            DataHoraInicio = data.Add(inicio),
                            DataHoraFim = data.Add(fim),
                            Cor = concluido ? "#1B5E20" : "#4CAF50"  // ✅ Verde escuro = completado
                        });

                    }

                    data = data.AddDays(1);
                }
            }

            return View(eventosCalendario);
        }


        // ====================
        // ✅ MÉTODOS PRIVADOS
        // ====================
        private bool HabitoExists(int id)
        {
            return _context.Habitos.Any(e => e.IdHabito == id);
        }

        private bool TryGetUserId(out int userId)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.TryParse(userIdStr, out userId) && userId > 0;
        }

        private void ColetarDiasDaSemana(Habito habito)
        {
            var diasSelecionados = Request.Form["DiasDaSemanaCheckbox"];
            habito.DiasDaSemana = string.Join(",", diasSelecionados.ToArray());
        }

        // ====================
        // Arquivamento
        // ====================
        public async Task<IActionResult> Arquivados()
        {
            if (!TryGetUserId(out int userId))
                return Challenge();

            var habitos = await _context.Habitos
                .Where(h => h.IdUsuario == userId && h.IsArquivado)
                .ToListAsync();

            return View(habitos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Arquivar(int id)
        {
            var habito = await _context.Habitos.FindAsync(id);
            if (habito == null) return NotFound();
            if (!TryGetUserId(out int userId) || habito.IdUsuario != userId) return Forbid();

            habito.IsArquivado = true;
            _context.Update(habito);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Desarquivar(int id)
        {
            var habito = await _context.Habitos.FindAsync(id);
            if (habito == null) return NotFound();
            if (!TryGetUserId(out int userId) || habito.IdUsuario != userId) return Forbid();

            habito.IsArquivado = false;
            _context.Update(habito);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Arquivados));
        }
    }
}
