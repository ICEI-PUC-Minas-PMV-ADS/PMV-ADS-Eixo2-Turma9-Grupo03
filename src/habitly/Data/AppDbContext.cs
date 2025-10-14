using Microsoft.EntityFrameworkCore;
using Habitly.Models;

namespace Habitly.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Habit> Habits { get; set; }
    }
}
