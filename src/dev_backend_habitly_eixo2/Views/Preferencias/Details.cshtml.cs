using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using dev_backend_habitly_eixo2.Models;

namespace dev_backend_habitly_eixo2.Views.Preferencias
{
    public class DetailsModel : PageModel
    {
        private readonly dev_backend_habitly_eixo2.Models.AppDbContext _context;

        public DetailsModel(dev_backend_habitly_eixo2.Models.AppDbContext context)
        {
            _context = context;
        }

      public PreferenciasUsuario PreferenciasUsuario { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PreferenciasUsuario_1 == null)
            {
                return NotFound();
            }

            var preferenciasusuario = await _context.PreferenciasUsuario_1.FirstOrDefaultAsync(m => m.IdPreferencia == id);
            if (preferenciasusuario == null)
            {
                return NotFound();
            }
            else 
            {
                PreferenciasUsuario = preferenciasusuario;
            }
            return Page();
        }
    }
}
