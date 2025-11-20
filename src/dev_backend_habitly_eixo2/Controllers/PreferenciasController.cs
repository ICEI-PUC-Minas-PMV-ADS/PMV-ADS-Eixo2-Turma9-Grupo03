using Microsoft.AspNetCore.Mvc;
using dev_backend_habitly_eixo2.Models;
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

        // GET: /Preferencias/Create
        public IActionResult Create()
        {
            int idUsuario = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var exists = _context.PreferenciasUsuario
                    .Any(p => p.IdUsuario == idUsuario);
            //int idUsuario = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));


            if (exists)
            {
                return RedirectToAction("Edit");
            }

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

            //int? idUsuario = HttpContext.Session.GetInt32("IdUsuario");
            int? idUsuario = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

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
            else
            {
                TempData["MensagemErro"] = string.Join(" | ",
                    ModelState.Where(e => e.Value.Errors.Count > 0)
                              .Select(e => $"{e.Key}: {string.Join(",", e.Value.Errors.Select(er => er.ErrorMessage))}"));
            };


                return View(preferencias);
        }

        // GET: /Preferencias/Edit
        public IActionResult Edit()
        {
            var usuarioName = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(usuarioName))
                return RedirectToAction("Login", "Usuarios");

            int idUsuario = int.Parse(usuarioName);

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
            int? idUsuario = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

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
