using Microsoft.EntityFrameworkCore;
using dev_backend_habitly_eixo2.Models;

namespace dev_backend_habitly_eixo2.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Habito> Habitos { get; set; }
        public DbSet<Notificacao> Notificacoes { get; set; }
        public DbSet<Metrica> Metricas { get; set; }

        public DbSet<Checkin> Checkins { get; set; }
        public DbSet <PreferenciasUsuario> PreferenciasUsuario { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuarios>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }

        public DbSet<dev_backend_habitly_eixo2.Models.PreferenciasUsuario> PreferenciasUsuario_1 { get; set; }


    }
}
