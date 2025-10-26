using Microsoft.EntityFrameworkCore;
using HabitlyApp.Models;

namespace HabitlyApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Lembrete> Lembretes { get; set; }
    }
}