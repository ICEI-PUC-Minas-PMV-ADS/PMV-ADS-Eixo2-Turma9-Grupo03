using Microsoft.EntityFrameworkCore;

namespace habitly.Models
{
    public class AppDbContext : DbContext //Gestão de dependências
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }   

        public DbSet<Habito> Habito { get; set; } //Criação da tabela Habits
        public DbSet<Checkin> Checkin { get; set; } //Criação da tabela Checkins
        public DbSet<Usuario> Usuario { get; set; } //Criação da tabela Usuarios
        public DbSet<Notificacao> Notificacao { get; set; } //Criação da tabela Notificacoes
        public DbSet<Metrica> Metrica { get; set; } //Criação da tabela Metricas

    }
}
