using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using dev_backend_habitly_eixo2.Models;

namespace dev_backend_habitly_eixo2.Views.Preferencias
{
    public class CreateModel : PageModel
    {
        private readonly dev_backend_habitly_eixo2.Models.AppDbContext _context;

        public CreateModel(dev_backend_habitly_eixo2.Models.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "Email");
            return Page();
        }

        [BindProperty]
        public PreferenciasUsuario PreferenciasUsuario { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PreferenciasUsuario_1.Add(PreferenciasUsuario);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
