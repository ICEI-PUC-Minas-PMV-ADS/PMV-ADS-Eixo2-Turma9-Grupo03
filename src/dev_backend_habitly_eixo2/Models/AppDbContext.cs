using Microsoft.EntityFrameworkCore;

namespace dev_backend_habitly_eixo2.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Habito> Habitos { get; set; }
        public DbSet<Notificacao> Notificacoes { get; set; }
        public DbSet<Metrica> Metricas { get; set; }
        public DbSet<Checkin> Checkins { get; set; }

    }
}
