using Microsoft.EntityFrameworkCore;

namespace RegistroGastos.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Gasto> Gastos { get; set; }
    }
}
