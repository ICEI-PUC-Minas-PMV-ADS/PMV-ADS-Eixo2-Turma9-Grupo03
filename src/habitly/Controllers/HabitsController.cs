using Habitly.Data;
using Habitly.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Habitly.Controllers
{
    public class HabitsController : Controller
    {
        private readonly AppDbContext _context;

        public HabitsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Habits
        public async Task<IActionResult> Index(string? search)
        {
            var habits = from h in _context.Habits select h;

            if (!string.IsNullOrEmpty(search))
                habits = habits.Where(h => h.Name.Contains(search));

            return View(await habits.ToListAsync());
        }

        // GET: Habits/Create
        public IActionResult Create() => View();

        // POST: Habits/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Habit habit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(habit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(habit);
        }

        // GET: Habits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var habit = await _context.Habits.FindAsync(id);
            if (habit == null) return NotFound();

            return View(habit);
        }

        // POST: Habits/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Habit habit)
        {
            if (id != habit.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(habit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(habit);
        }

        // GET: Habits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var habit = await _context.Habits.FirstOrDefaultAsync(h => h.Id == id);
            if (habit == null) return NotFound();

            return View(habit);
        }

        // POST: Habits/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var habit = await _context.Habits.FindAsync(id);
            if (habit != null)
                _context.Habits.Remove(habit);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // ✅ Marcar como concluído
        public async Task<IActionResult> MarkAsDone(int id)
        {
            var habit = await _context.Habits.FindAsync(id);
            if (habit == null) return NotFound();

            habit.IsCompleted = true;
            habit.Progress = 100;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> IncreaseProgress(int id)
        {
            var habit = await _context.Habits.FindAsync(id);
            if (habit == null) return NotFound();

            habit.Progress = Math.Min(habit.Progress + 10, 100);
            if (habit.Progress == 100) habit.IsCompleted = true;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
