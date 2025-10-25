using dev_backend_habitly_eixo2.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace dev_backend_habitly_eixo2.Controllers
{
    [Authorize(Roles = "Admin")] // Somente admin pode acessar
    public class UsuariosController : Controller
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        //Página de acesso negado
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        //Login
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(Usuarios usuarios)
        {
            // IdUsuario agora é int
            var dados = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == usuarios.Email);
            if (dados == null)
            {
                ViewBag.Mensagem = "Usuário e/ou senha inválidos!";
                return View();
            }

            bool senhaOk = BCrypt.Net.BCrypt.Verify(usuarios.Senha, dados.Senha);
            if (senhaOk)
            {
                var claims = new List<Claim>
                {
                    new(ClaimTypes.Name, dados.Nome),
                    new(ClaimTypes.NameIdentifier, dados.IdUsuario.ToString()),
                    new(ClaimTypes.Role, dados.Perfil.ToString()),
                };

                var usuarioIdentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new(usuarioIdentity);

                var props = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.UtcNow.ToLocalTime().AddHours(8),
                    IsPersistent = true,
                };

                await HttpContext.SignInAsync(principal, props);
                return RedirectToAction("Index", "Habitos");
            }
            else
            {
                ViewBag.Mensagem = "Usuário e/ou senha inválidos!";
                return View();
            }
        }

        //Logout
        [AllowAnonymous] // para que o usuário possa sair mesmo sem ser Admin
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Usuarios");
        }

        // GET: Usuarios/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int id)
        {
            if (_context.Usuarios == null)
                return NotFound();

            var usuarios = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuarios == null)
                return NotFound();

            return View(usuarios);
        }

        // GET: Usuarios/Create
        [AllowAnonymous] // permitir acesso à tela sem estar autenticado
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Create([Bind("Nome,Email,Senha,Perfil")] Usuarios usuarios)
        {
            // Verifica se o e-mail já existe no banco de dados
            if (await _context.Usuarios.AnyAsync(u => u.Email == usuarios.Email))
            {
                // Adiciona um erro específico para o campo "Email"
                ModelState.AddModelError("Email", "Este e-mail já está em uso. Por favor, escolha outro.");
            }

            if (ModelState.IsValid)
            {
                usuarios.Senha = BCrypt.Net.BCrypt.HashPassword(usuarios.Senha);
                _context.Add(usuarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // Se o ModelState não for válido (ou se o e-mail já existir), retorna para a mesma view
            return View(usuarios);
        }

        // GET: Usuarios/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            if (_context.Usuarios == null)
                return NotFound();

            var usuarios = await _context.Usuarios.FindAsync(id);
            if (usuarios == null)
                return NotFound();

            return View(usuarios);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,Email,Senha,Perfil")] Usuarios usuarios)
        {
            if (id != usuarios.IdUsuario)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    usuarios.Senha = BCrypt.Net.BCrypt.HashPassword(usuarios.Senha);
                    _context.Update(usuarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuariosExists(usuarios.IdUsuario))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuarios);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (_context.Usuarios == null)
                return NotFound();

            var usuarios = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuarios == null)
                return NotFound();

            return View(usuarios);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuarios == null)
                return Problem("Entity set 'AppDbContext.Usuarios' is null.");

            var usuarios = await _context.Usuarios.FindAsync(id);
            if (usuarios != null)
                _context.Usuarios.Remove(usuarios);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuariosExists(int id)
        {
            return _context.Usuarios.Any(e => e.IdUsuario == id);
        }
    }
}
