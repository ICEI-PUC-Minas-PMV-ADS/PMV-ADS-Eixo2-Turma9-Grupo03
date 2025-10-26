using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using dev_backend_habitly_eixo2.Models;

namespace dev_backend_habitly_eixo2.Views.Preferencias
{
    public class EditModel : PageModel
    {
        private readonly dev_backend_habitly_eixo2.Models.AppDbContext _context;

        public EditModel(dev_backend_habitly_eixo2.Models.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PreferenciasUsuario PreferenciasUsuario { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PreferenciasUsuario_1 == null)
            {
                return NotFound();
            }

            var preferenciasusuario =  await _context.PreferenciasUsuario_1.FirstOrDefaultAsync(m => m.IdPreferencia == id);
            if (preferenciasusuario == null)
            {
                return NotFound();
            }
            PreferenciasUsuario = preferenciasusuario;
           ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "Email");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PreferenciasUsuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreferenciasUsuarioExists(PreferenciasUsuario.IdPreferencia))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PreferenciasUsuarioExists(int id)
        {
          return _context.PreferenciasUsuario_1.Any(e => e.IdPreferencia == id);
        }
    }
}
