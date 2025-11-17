using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dev_backend_habitly_eixo2.Models;


namespace dev_backend_habitly_eixo2.Controllers
{


    public class MetricaHabitoViewModel
    {
        public int IdHabito { get; set; }
        public string TituloHabito { get; set; } = string.Empty;
        public int StreakAtual { get; set; }
        public int StreakMaximo { get; set; }
        // Novos campos para o dashboard:
        public int TotalCheckins { get; set; } // Total de Check-ins
        public double TaxaConclusao { get; set; } // Taxa de Conclusão (%)
        public int DiasAteHoje { get; set; } // Dias desde o início para cálculo da taxa
    }

    public class MetricasController : Controller
    {
        private readonly AppDbContext _context;

        public MetricasController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {


            int idUsuarioLogado = 1; // ID fixo, ajuste se estiver usando autenticação real

            // 1. Buscar todos os Hábitos do usuário, incluindo seus Checkins
            var habitos = await _context.Habitos
                .Include(h => h.Checkins)
                .Where(h => h.IdUsuario == idUsuarioLogado)
                .ToListAsync();

            var metricasParaView = new List<MetricaHabitoViewModel>();


            foreach (var habito in habitos)
            {

                var (streakAtual, streakMaximo) = CalcularStreaks(habito.Checkins);


                // Total de Check-ins
                int totalCheckins = habito.Checkins.Count();

                // Dias desde o início do hábito (usado para o cálculo da Taxa de Conclusão
                int diasAteHoje = (int)(DateTime.Today.Date - habito.DataInicio.Date).TotalDays + 1;

                double taxaConclusao = (diasAteHoje > 0)
                    ? Math.Round(((double)totalCheckins / diasAteHoje) * 100, 2)
                    : 0;

                metricasParaView.Add(new MetricaHabitoViewModel
                {
                    IdHabito = habito.IdHabito,
                    TituloHabito = habito.TituloHabito,
                    StreakAtual = streakAtual,
                    StreakMaximo = streakMaximo,
                    TotalCheckins = totalCheckins,
                    TaxaConclusao = taxaConclusao,
                    DiasAteHoje = diasAteHoje
                });
            }

            // 4. Retorna a View com a lista de métricas calculadas
            return View(metricasParaView);
        }


        // FUNÇÃO AUXILIAR PARA CALCULAR STREAKS (MANTIDA IGUAL)

        private (int currentStreak, int maxStreak) CalcularStreaks(ICollection<Checkin> checkins)
        {

            var datasUnicas = checkins
                .Select(c => c.DataCheckin.Date)
                .Distinct()
                .OrderByDescending(d => d)
                .ToList();

            if (!datasUnicas.Any())
            {
                return (0, 0); // Sem check-ins
            }


            int streakAtual = 0;
            DateTime hoje = DateTime.Today.Date;


            if (datasUnicas.Contains(hoje))
            {
                streakAtual = 1;
            }


            DateTime dataEsperada = hoje.AddDays(-1);


            var datasParaLoop = datasUnicas.Where(d => d < hoje).ToList();


            foreach (var dataCheckin in datasParaLoop)
            {

                if (dataCheckin == dataEsperada)
                {
                    streakAtual++;
                    dataEsperada = dataEsperada.AddDays(-1); // Volta 1 dia
                }
                else if (dataCheckin < dataEsperada)
                {
                    break;
                }
            }


            int maxStreak = 0;
            int currentRun = 0;


            var datasCrescente = datasUnicas.OrderBy(d => d).ToList();

            if (datasCrescente.Any())
            {
                currentRun = 1;
                maxStreak = 1;
            }

            for (int i = 1; i < datasCrescente.Count; i++)
            {

                if (datasCrescente[i] == datasCrescente[i - 1].AddDays(1))
                {
                    currentRun++;
                }
                else
                {
                    currentRun = 1;
                }

                if (currentRun > maxStreak)
                {
                    maxStreak = currentRun;
                }
            }

            return (streakAtual, maxStreak);
        }


        public async Task<IActionResult> Details(string id) { /* ... */ return NotFound(); }
        public IActionResult Create() { /* ... */ return View(); }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMetrica,IdUsuario,StreakAtual,StreakMaximo")] Metrica metrica) { /* ... */ return View(metrica); }
        public async Task<IActionResult> Edit(string id) { /* ... */ return NotFound(); }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdMetrica,IdUsuario,StreakAtual,StreakMaximo")] Metrica metrica) { /* ... */ return View(metrica); }
        public async Task<IActionResult> Delete(string id) { /* ... */ return NotFound(); }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id) { /* ... */ return RedirectToAction(nameof(Index)); }
        private bool MetricaExists(string id) { return _context.Metricas.Any(e => e.IdMetrica == id); }
    }
}