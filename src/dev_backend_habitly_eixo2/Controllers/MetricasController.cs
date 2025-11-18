using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims; // Necessário para acessar o ClaimTypes
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization; // Necessário para o [Authorize]
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dev_backend_habitly_eixo2.Models;


namespace dev_backend_habitly_eixo2.Controllers
{

    // ViewModel para transportar os dados das métricas para a View
    public class MetricaHabitoViewModel
    {
        public int IdHabito { get; set; }
        public string TituloHabito { get; set; } = string.Empty;
        public int StreakAtual { get; set; }
        public int StreakMaximo { get; set; }
        public int TotalCheckins { get; set; }
        public double TaxaConclusao { get; set; }
        public int DiasAteHoje { get; set; }
    }

    // O atributo [Authorize] garante que apenas usuários logados podem acessar este Controller.
    [Authorize]
    public class MetricasController : Controller
    {
        private readonly AppDbContext _context;

        public MetricasController(AppDbContext context)
        {
            _context = context;
        }

        // Ação Index - Mostra as métricas do usuário logado
        public async Task<IActionResult> Index()
        {
            // 1. Obter o ID do usuário logado de forma segura
            var idUsuarioString = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Tenta converter o ID (que é uma string) para o tipo int esperado
            if (!int.TryParse(idUsuarioString, out int idUsuarioLogado))
            {
                // Se não conseguir obter ou converter o ID (usuário não autenticado ou Claim ausente/inválida),
                // retorne um erro (ou Unauthorized)
                return Unauthorized();
            }

            // 2. Buscar todos os Hábitos DO USUÁRIO LOGADO, incluindo seus Checkins
            var habitos = await _context.Habitos
                .Include(h => h.Checkins)
                .Where(h => h.IdUsuario == idUsuarioLogado) // AGORA FILTRA PELO ID REAL DO USUÁRIO
                .ToListAsync();

            var metricasParaView = new List<MetricaHabitoViewModel>();


            foreach (var habito in habitos)
            {

                var (streakAtual, streakMaximo) = CalcularStreaks(habito.Checkins);


                // Total de Check-ins
                int totalCheckins = habito.Checkins.Count();

                // Dias desde o início do hábito 
                int diasAteHoje = (int)(DateTime.Today.Date - habito.DataInicio.Date).TotalDays + 1;

                // Cálculo da Taxa de Conclusão (Total de Check-ins / Dias desde o início)
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

            // 3. Retorna a View com a lista de métricas calculadas
            return View(metricasParaView);
        }


        // FUNÇÃO AUXILIAR PARA CALCULAR STREAKS (Corrigida e mantida)
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


        // Outras ações (mantidas como estavam)

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