using HomeAutomation.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace HomeAutomation.infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
       
        }

        public DbSet<Dispositivo> Dispositivos { get; set; }

    } 
}
