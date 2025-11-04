using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using dev_backend_habitly_eixo2.Models;

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
}
