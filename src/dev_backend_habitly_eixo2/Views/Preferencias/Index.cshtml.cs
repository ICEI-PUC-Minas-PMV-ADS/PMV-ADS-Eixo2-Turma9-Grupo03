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
    public class IndexModel : PageModel
    {
        private readonly dev_backend_habitly_eixo2.Models.AppDbContext _context;

        public IndexModel(dev_backend_habitly_eixo2.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<PreferenciasUsuario> PreferenciasUsuario { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.PreferenciasUsuario_1 != null)
            {
                PreferenciasUsuario = await _context.PreferenciasUsuario_1
                .Include(p => p.Usuario).ToListAsync();
            }
        }
    }
}
