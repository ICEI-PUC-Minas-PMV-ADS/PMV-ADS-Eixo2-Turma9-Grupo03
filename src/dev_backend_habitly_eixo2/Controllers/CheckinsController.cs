using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using dev_backend_habitly_eixo2.Models;
using dev_backend_habitly_eixo2.ViewModels;

namespace dev_backend_habitly_eixo2.Controllers
{
    [Authorize]
    public class CheckinsController : Controller
    {
        private readonly AppDbContext _context;

        public CheckinsController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ Check-in rápido via botão
        [HttpPost]
        public async Task<IActionResult> CreateQuick(int idHabito)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            bool jaExiste = await _context.Checkins
                .AnyAsync(c => c.IdHabito == idHabito && c.DataCheckin.Date == DateTime.Today);

            if (!jaExiste)
            {
                _context.Checkins.Add(new Checkin
                {
                    IdHabito = idHabito,
                    DataCheckin = DateTime.Now
                });

                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Calendario", "Habitos");
        }


        // ✅ HISTÓRICO POR HÁBITO
        public async Task<IActionResult> Historico(int habitoId, int? mes, int? ano)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var habito = await _context.Habitos
                .Where(h => h.IdUsuario == userId && h.IdHabito == habitoId)
                .FirstOrDefaultAsync();

            if (habito == null)
                return NotFound();

            ViewBag.Habito = habito.TituloHabito;

            mes ??= DateTime.Now.Month;
            ano ??= DateTime.Now.Year;

            ViewBag.Mes = mes;
            ViewBag.Ano = ano;

            var checkins = await _context.Checkins
                .Where(c => c.IdHabito == habitoId &&
                            c.DataCheckin.Month == mes &&
                            c.DataCheckin.Year == ano)
                .ToListAsync();

            var listaDias = checkins
                .GroupBy(c => c.DataCheckin.Date)
                .Select(g => new DiaCheckinsVM
                {
                    Data = g.Key,
                    Total = g.Count(),
                    Horarios = g.Select(x => x.DataCheckin.ToString("HH:mm")).ToList()
                })
                .OrderByDescending(x => x.Data)
                .ToList();

            return View(listaDias);
        }


        // ✅ HISTÓRICO GERAL
        public async Task<IActionResult> HistoricoGeral()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var lista = await _context.Habitos
                .Where(h => h.IdUsuario == userId)
                .Select(h => new HabitoResumoVM
                {
                    IdHabito = h.IdHabito,
                    Titulo = h.TituloHabito,
                    Total = h.Checkins.Count()
                })
                .ToListAsync();

            return View(lista);
        }
    }
}
