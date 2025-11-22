using dev_backend_habitly_eixo2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace dev_backend_habitly_eixo2.Controllers
{
    public class PreferenciasController : Controller
    {
        private readonly AppDbContext _context;

        public PreferenciasController(AppDbContext context)
        {
            _context = context;
        }

        private void CarregarOpcoes()
        {
            ViewBag.Temas = new List<SelectListItem>
            {
                new SelectListItem { Text = "Claro", Value = "Claro" },
                new SelectListItem { Text = "Escuro", Value = "Escuro" }
            };

            ViewBag.Idiomas = new List<SelectListItem>
            {
                new SelectListItem { Text = "Português", Value = "pt-BR" },
                new SelectListItem { Text = "Inglês", Value = "en-US" }
            };
        }

        // GET: /Preferencias/Create
        public IActionResult Create()
        {
            CarregarOpcoes();

            int idUsuario = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var exists = _context.PreferenciasUsuario
                .Any(p => p.IdUsuario == idUsuario);

            if (exists)
                return RedirectToAction("Edit");

            var model = new PreferenciasUsuario
            {
                IdUsuario = idUsuario
            };

            return View(model);
        }

        // POST: /Preferencias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PreferenciasUsuario preferencias)
        {
            CarregarOpcoes();

            int idUsuario = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            preferencias.IdUsuario = idUsuario;

            if (ModelState.IsValid)
            {
                _context.PreferenciasUsuario.Add(preferencias);
                _context.SaveChanges();

                TempData["MensagemSucesso"] = "Preferências criadas com sucesso!";
                return RedirectToAction("Index", "Habitos");
            }

            return View(preferencias);
        }

        // GET: /Preferencias/Edit
        public IActionResult Edit()
        {
            CarregarOpcoes();

            var usuarioName = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(usuarioName))
                return RedirectToAction("Login", "Usuarios");

            int idUsuario = int.Parse(usuarioName);

            var pref = _context.PreferenciasUsuario
                .AsNoTracking() // evita entidade duplicada
                .FirstOrDefault(p => p.IdUsuario == idUsuario);

            if (pref == null)
                return RedirectToAction("Create");

            return View(pref);
        }

        // POST: /Preferencias/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PreferenciasUsuario preferencias)
        {
            CarregarOpcoes();

            int idUsuario = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var entity = _context.PreferenciasUsuario
                .FirstOrDefault(p => p.IdUsuario == idUsuario);

            if (entity == null)
                return RedirectToAction("Create");

            entity.Tema = preferencias.Tema;
            entity.Idioma = preferencias.Idioma;
            entity.NotificacoesAtivas = preferencias.NotificacoesAtivas;

            _context.SaveChanges();

            TempData["MensagemSucesso"] = "Preferências atualizadas com sucesso!";
            return RedirectToAction("Index", "Habitos");
        }
    }
}
