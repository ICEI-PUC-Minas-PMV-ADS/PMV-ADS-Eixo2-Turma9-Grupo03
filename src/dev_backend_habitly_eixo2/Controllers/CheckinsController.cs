using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dev_backend_habitly_eixo2.Models;
using dev_backend_habitly_eixo2.ViewModels;


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
        // LISTA TODOS OS HÁBITOS (entrada pela aba do menu)
        public async Task<IActionResult> HistoricoGeral()
        {
            var hoje = DateTime.Now;
            var primeiroDiaMes = new DateTime(hoje.Year, hoje.Month, 1);
            var ultimoDiaMes = primeiroDiaMes.AddMonths(1).AddDays(-1);

            var habitos = await _context.Habitos
                .AsNoTracking()
                .OrderBy(h => h.TituloHabito)
                .ToListAsync();

            var lista = new List<HabitoResumoVM>();

            foreach (var h in habitos)
            {
                var checkinsMes = await _context.Checkins
                    .Where(c => c.IdHabito == h.IdHabito &&
                                c.DataCheckin >= primeiroDiaMes &&
                                c.DataCheckin <= ultimoDiaMes)
                    .GroupBy(c => c.DataCheckin.Date)
                    .CountAsync();

                int diasMes = (ultimoDiaMes - primeiroDiaMes).Days + 1;
                double percentual = diasMes == 0 ? 0 : Math.Round(checkinsMes / (double)diasMes * 100, 1);

                lista.Add(new HabitoResumoVM
                {
                    IdHabito = h.IdHabito,
                    Titulo = h.TituloHabito,
                    Total = checkinsMes,
                    Percentual = percentual   
                });
            }

            return View(lista);
        }

        // HISTÓRICO DE UM HÁBITO
        public async Task<IActionResult> Historico(int habitoId, int? mes, int? ano)
        {
            var habito = await _context.Habitos.FindAsync(habitoId);
            if (habito == null)
                return NotFound();

            var hoje = DateTime.Today;
            int mesSelecionado = mes ?? hoje.Month;
            int anoSelecionado = ano ?? hoje.Year;

            var inicioMes = new DateTime(anoSelecionado, mesSelecionado, 1);
            var fimMes = inicioMes.AddMonths(1).AddDays(-1);

            var registros = await _context.Checkins
                .AsNoTracking()
                .Where(c => c.IdHabito == habitoId &&
                            c.DataCheckin.Date >= inicioMes &&
                            c.DataCheckin.Date <= fimMes)
                .OrderBy(c => c.DataCheckin)
                .ToListAsync();

            // ✅ AGRUPA POR DIA e monta o ViewModel
            var agrupado = registros
                .GroupBy(c => c.DataCheckin.Date)
                .Select(g => new DiaCheckinsVM
                {
                    Data = g.Key,
                    Total = g.Count(),
                    Horarios = g.Select(x => x.DataCheckin.ToString("HH:mm")).ToList()
                })
                .OrderByDescending(x => x.Data)
                .ToList();

            ViewBag.Habito = habito.TituloHabito;
            ViewBag.Mes = mesSelecionado;
            ViewBag.Ano = anoSelecionado;

            return View(agrupado); // 
        }


        // GET: Checkins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var checkin = await _context.Checkins
                .Include(c => c.Habito)
                .FirstOrDefaultAsync(m => m.IdCheckin == id);

            if (checkin == null)
                return NotFound();

            return View(checkin);
        }

        // GET: Checkins/Create
        public IActionResult Create()
        {
            ViewData["IdHabito"] = new SelectList(_context.Habitos, "IdHabito", "TituloHabito");
            return View();
        }

        // POST: Checkins/Create
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

            ViewData["IdHabito"] = new SelectList(_context.Habitos, "IdHabito", "TituloHabito", checkin.IdHabito);
            return View(checkin);
        }

        // GET: Checkins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var checkin = await _context.Checkins.FindAsync(id);
            if (checkin == null)
                return NotFound();

            ViewData["IdHabito"] = new SelectList(_context.Habitos, "IdHabito", "TituloHabito", checkin.IdHabito);
            return View(checkin);
        }

        // POST: Checkins/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCheckin,IdHabito,DataCheckin")] Checkin checkin)
        {
            if (id != checkin.IdCheckin)
                return NotFound();

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
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["IdHabito"] = new SelectList(_context.Habitos, "IdHabito", "TituloHabito", checkin.IdHabito);
            return View(checkin);
        }

        // GET: Checkins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var checkin = await _context.Checkins
                .Include(c => c.Habito)
                .FirstOrDefaultAsync(m => m.IdCheckin == id);

            if (checkin == null)
                return NotFound();

            return View(checkin);
        }

        // POST: Checkins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var checkin = await _context.Checkins.FindAsync(id);
            if (checkin != null)
            {
                _context.Checkins.Remove(checkin);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CheckinExists(int id)
        {
            return _context.Checkins.Any(e => e.IdCheckin == id);
        }
    }
}
