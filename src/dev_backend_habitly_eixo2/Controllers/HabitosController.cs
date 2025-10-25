using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dev_backend_habitly_eixo2.Models;
using dev_backend_habitly_eixo2.Models.DTOs; // Necessário para o DTO do Calendário
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic; // Necessário para List<T>

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

        // GET: Habitos
        // Retorna uma lista de eventos diários para o calendário.
        public async Task<IActionResult> Index()
        {
            if (!TryGetUserId(out int userId))
            {
                return Challenge();
            }

            // 1. Puxa todos os hábitos do usuário
            var habitos = await _context.Habitos
                .Where(h => h.IdUsuario == userId)
                .ToListAsync();

            // 2. Cria a lista para armazenar todos os eventos diários gerados
            var eventosCalendario = new List<CalendarioEventoDTO>();

            // 3. Itera sobre cada hábito para gerar um evento para cada dia no período
            foreach (var habito in habitos)
            {
                // 🎯 Lógica para obter os dias válidos (IDs de 0 a 6)
                var diasValidos = habito.DiasDaSemana
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => int.Parse(s))
                    .ToList();

                if (habito.DataFim.Date >= habito.DataInicio.Date)
                {
                    DateTime dataAtual = habito.DataInicio.Date;
                    TimeSpan horaInicio = habito.DataInicio.TimeOfDay;
                    TimeSpan horaFim = habito.DataFim.TimeOfDay;

                    while (dataAtual <= habito.DataFim.Date)
                    {
                        // 🎯 VERIFICAÇÃO PRINCIPAL: Checa se o dia da semana atual está na lista
                        // DayOfWeek retorna um Enum, onde 0=Domingo, 1=Segunda, etc.
                        int diaDaSemana = (int)dataAtual.DayOfWeek;

                        // Se a lista de dias estiver vazia OU se o dia atual for um dia selecionado:
                        if (diasValidos.Count == 0 || diasValidos.Contains(diaDaSemana))
                        {
                            // Restante da lógica de criação do CalendarioEventoDTO...
                            DateTime dataHoraInicio = dataAtual.Date.Add(horaInicio);
                            DateTime dataHoraFim = dataAtual.Date.Add(horaFim);

                            if (dataHoraFim < dataHoraInicio)
                            {
                                dataHoraFim = dataHoraFim.AddDays(1);
                            }

                            eventosCalendario.Add(new CalendarioEventoDTO
                            {
                                IdHabito = habito.IdHabito,
                                TituloHabito = habito.TituloHabito,
                                DataHoraInicio = dataHoraInicio,
                                DataHoraFim = dataHoraFim,
                                Cor = "#4CAF50"
                            });
                        }

                        // Avança para o próximo dia
                        dataAtual = dataAtual.AddDays(1);
                    }
                }
            }

            return View(eventosCalendario);
        }

        // GET: Habitos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var habito = await _context.Habitos.FirstOrDefaultAsync(m => m.IdHabito == id);

            if (habito == null)
                return NotFound();

            // Segurança: Verifica se o hábito pertence ao usuário logado
            if (!TryGetUserId(out int userId) || habito.IdUsuario != userId)
            {
                return Forbid(); // Retorna 403 - Acesso Negado
            }

            return View(habito);
        }

        // GET: Habitos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Habitos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("TituloHabito,DescricaoHabito,PeriodicidadeHabito,StatusHabito,DataInicio,DataFim,DiasDaSemana")] Habito habito) // 🎯 Inclui DiasDaSemana
        {
            if (!TryGetUserId(out int userId)) return Challenge();

            ColetarDiasDaSemana(habito); // 🎯 COLETAR AQUI!

            if (habito.DataFim.Date < habito.DataInicio.Date)
            {
                ModelState.AddModelError(nameof(Habito.DataFim), "A Data Fim não pode ser anterior à Data Início.");
            }

            if (ModelState.IsValid)
            {
                habito.IdUsuario = userId;
                _context.Add(habito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(habito);
        }

        // GET: Habitos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var habito = await _context.Habitos.FindAsync(id);

            if (habito == null)
                return NotFound();

            // Segurança: Verifica se o hábito pertence ao usuário logado
            if (!TryGetUserId(out int userId) || habito.IdUsuario != userId)
            {
                return Forbid();
            }

            return View(habito);
        }

        // POST: Habitos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("IdHabito,IdUsuario,TituloHabito,DescricaoHabito,PeriodicidadeHabito,StatusHabito,DataInicio,DataFim,DiasDaSemana")] Habito habito) // 🎯 Inclui DiasDaSemana
        {
            if (id != habito.IdHabito)
                return NotFound();

            // Lógica de segurança: Impede que um usuário edite o hábito de outro.
            if (!TryGetUserId(out int userId) || habito.IdUsuario != userId)
            {
                return Forbid();
            }

            ColetarDiasDaSemana(habito); // 🎯 COLETAR AQUI!

            if (habito.DataFim.Date < habito.DataInicio.Date)
            {
                ModelState.AddModelError(nameof(Habito.DataFim), "A Data Fim não pode ser anterior à Data Início.");
            }

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

        // GET: Habitos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var habito = await _context.Habitos
                .FirstOrDefaultAsync(m => m.IdHabito == id);

            if (habito == null)
                return NotFound();

            // Segurança: Verifica se o hábito pertence ao usuário logado
            if (!TryGetUserId(out int userId) || habito.IdUsuario != userId)
            {
                return Forbid();
            }

            return View(habito);
        }

        // POST: Habitos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var habito = await _context.Habitos.FindAsync(id);

            if (habito != null)
            {
                // Segurança: Verificação final antes de deletar
                if (!TryGetUserId(out int userId) || habito.IdUsuario != userId)
                {
                    return Forbid();
                }

                _context.Habitos.Remove(habito);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // --- MÉTODOS PRIVADOS ---

        private bool HabitoExists(int id)
        {
            return _context.Habitos.Any(e => e.IdHabito == id);
        }

        // Método utilitário para obter e validar o ID do usuário logado
        private bool TryGetUserId(out int userId)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.TryParse(userIdStr, out userId) && userId > 0;
        }

        private void ColetarDiasDaSemana(Habito habito)
        {
            // Obtém os valores dos checkboxes (todos os valores de 'DiasDaSemanaCheckbox')
            var diasSelecionados = Request.Form["DiasDaSemanaCheckbox"];

            // Converte e salva como uma string separada por vírgulas (ex: "1,5")
            habito.DiasDaSemana = string.Join(",", diasSelecionados.ToArray());
        }
    }
}