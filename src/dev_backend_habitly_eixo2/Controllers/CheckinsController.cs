using dev_backend_habitly_eixo2.Models;
using dev_backend_habitly_eixo2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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

        //  Check-in rápido via botão
        [HttpPost]
        public async Task<IActionResult> CreateQuick(int idHabito)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            // Já existe check-in hoje?
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

        //  Histórico Geral — resumo por hábito
        public async Task<IActionResult> HistoricoGeral()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            // Lista de hábitos + total de check-ins no mês
            var hoje = DateTime.Today;
            int mes = hoje.Month;
            int ano = hoje.Year;

            var dados = await _context.Habitos
                .Where(h => h.IdUsuario == userId)
                .Select(h => new HabitoResumoVM
                {
                    IdHabito = h.IdHabito,
                    Titulo = h.TituloHabito,
                    Total = h.Checkins
                        .Where(c => c.DataCheckin.Month == mes && c.DataCheckin.Year == ano)
                        .Count()
                })
                .ToListAsync();

            return View(dados);
        }

        //  Histórico detalhado por hábito
        public async Task<IActionResult> Historico(int habitoId, int? mes, int? ano)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var habito = await _context.Habitos
                .FirstOrDefaultAsync(h => h.IdHabito == habitoId && h.IdUsuario == userId);

            if (habito == null)
                return NotFound();

            ViewBag.TituloHabito = habito.TituloHabito;

            mes ??= DateTime.Today.Month;
            ano ??= DateTime.Today.Year;

            var checkins = await _context.Checkins
                .Where(c => c.IdHabito == habitoId
                         && c.DataCheckin.Month == mes
                         && c.DataCheckin.Year == ano)
                .ToListAsync();

            var lista = checkins
                .GroupBy(c => c.DataCheckin.Date)
                .Select(g => new DiaCheckinsVM
                {
                    Data = g.Key,
                    Total = g.Count(),
                    Horarios = g
                        .OrderBy(x => x.DataCheckin)
                        .Select(x => x.DataCheckin.ToString("HH:mm"))
                        .ToList()
                })
                .OrderByDescending(x => x.Data)
                .ToList();

            ViewBag.Mes = mes;
            ViewBag.Ano = ano;
            ViewBag.Habito = habito.TituloHabito;

            return View(lista);
        }

    }
}
