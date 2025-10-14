using Microsoft.EntityFrameworkCore;

namespace habitly.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Adicione DbSets para suas entidades aqui, por exemplo:
        // public DbSet<Usuario> Usuarios { get; set; }
    }
}