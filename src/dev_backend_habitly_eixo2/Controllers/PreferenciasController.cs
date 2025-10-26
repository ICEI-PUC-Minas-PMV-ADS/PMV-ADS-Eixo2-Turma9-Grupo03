using Microsoft.AspNetCore.Mvc;
using dev_backend_habitly_eixo2.Models;


namespace dev_backend_habitly_eixo2.Controllers
{
    public class PreferenciasController : Controller
    {
        private readonly AppDbContext _context;

        public PreferenciasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Preferencias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Preferencias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PreferenciasUsuario preferencias)
        {
            int? idUsuario = HttpContext.Session.GetInt32("IdUsuario");

            if (idUsuario == null)
            {
                TempData["MensagemErro"] = "Usuário não identificado. Faça login novamente.";
                return RedirectToAction("Login", "Usuarios");
            }

            preferencias.IdUsuario = idUsuario.Value;

            if (ModelState.IsValid)
            {
                _context.PreferenciasUsuario.Add(preferencias);
                _context.SaveChanges();
                TempData["MensagemSucesso"] = "Preferências salvas com sucesso!";
                return RedirectToAction("Index", "Home");
            }

            return View(preferencias);
        }

        // GET: /Preferencias/Edit
        public IActionResult Edit()
        {
            int? idUsuario = HttpContext.Session.GetInt32("IdUsuario");

            if (idUsuario == null)
                return RedirectToAction("Login", "Usuarios");

            var pref = _context.PreferenciasUsuario.FirstOrDefault(p => p.IdUsuario == idUsuario);
            if (pref == null)
                return RedirectToAction("Create");

            return View(pref);
        }

        // POST: /Preferencias/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PreferenciasUsuario preferencias)
        {
            int? idUsuario = HttpContext.Session.GetInt32("IdUsuario");

            if (idUsuario == null)
                return RedirectToAction("Login", "Usuarios");

            preferencias.IdUsuario = idUsuario.Value;

            if (ModelState.IsValid)
            {
                _context.PreferenciasUsuario.Update(preferencias);
                _context.SaveChanges();
                TempData["MensagemSucesso"] = "Preferências atualizadas com sucesso!";
                return RedirectToAction("Index", "Home");
            }

            return View(preferencias);
        }
    }
}
