using Microsoft.EntityFrameworkCore;
using ProyectoFestivos.Dominio.Entidades;

namespace ProyectoFestivos.Infraestructura.Persistencia.Contexto
{
    public class ProyectoFestivosContext : DbContext
    {
        public ProyectoFestivosContext(DbContextOptions<ProyectoFestivosContext>options) : base(options)
        { 
        }
        public DbSet<Festivo> Festivos { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Festivo>(festivo =>
            {
                festivo.HasKey(f => f.Id);
                festivo.HasIndex(s => s.Nombre).IsUnique();
            });

            modelBuilder.Entity<Tipo>(tipo =>
            {
                tipo.HasKey(f => f.Id);
                tipo.HasIndex(s => s.Nombre).IsUnique();
            });
        }
    }
}
