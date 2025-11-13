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

            // Confere se o hábito é mesmo do usuário logado
            var habito = await _context.Habitos
                .FirstOrDefaultAsync(h => h.IdHabito == idHabito && h.IdUsuario == userId);

            if (habito == null)
                return NotFound();

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

            // Depois de salvar o check-in, vai calcular a sequência de dias seguidos
            // Busca todos os dias em que houve check-in para esse hábito
            var dias = await _context.Checkins
                .Where(c => c.IdHabito == idHabito)
                .Select(c => c.DataCheckin.Date)
                .Distinct()
                .OrderByDescending(d => d)
                .ToListAsync();

            int streak = 0;
            var hoje = DateTime.Today;
            var diaEsperado = hoje;

            foreach (var dia in dias)
            {
                if (dia == diaEsperado)
                {
                    streak++;
                    diaEsperado = diaEsperado.AddDays(-1);
                }
                else if (dia > diaEsperado)
                {
                    // Ignora buracos pra frente (datas futuras, etc.)
                    continue;
                }
                else
                {
                    // Quebrou a sequência
                    break;
                }
            }

            // Metas de consistência
            int[] metas = new[] { 7, 30, 100 };

            foreach (var meta in metas)
            {
                if (streak >= meta)
                {
                    bool jaTemConquista = await _context.Conquistas
                        .AnyAsync(c => c.IdHabito == idHabito && c.MetaDias == meta);

                    if (!jaTemConquista)
                    {
                        _context.Conquistas.Add(new Conquista
                        {
                            IdHabito = idHabito,
                            MetaDias = meta,
                            DataConquista = DateTime.Now
                        });
                    }
                }
            }

            await _context.SaveChangesAsync();

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
            var conquistas = await _context.Conquistas
                .Where(c => c.IdHabito == habitoId)
                .OrderBy(c => c.MetaDias)
                .ToListAsync();

            ViewBag.Conquistas = conquistas;


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
