using Microsoft.AspNetCore.Mvc;
using dev_backend_habitly_eixo2.Models;


namespace dev_backend_habitly_eixo2.Controllers
{
    public class HabitosControllerCompartilha : Controller
    {
        private readonly AppDbContext _context;

        public HabitosControllerCompartilha(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Habitos
        public IActionResult Index()
        {
            var habitos = _context.Habitos.ToList();
            return View(habitos);
        }
    }
}
