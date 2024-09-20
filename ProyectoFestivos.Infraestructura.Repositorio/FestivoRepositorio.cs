using Festivos.Core.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;
using ProyectoFestivos.Dominio.Entidades;
using ProyectoFestivos.Infraestructura.Persistencia.Contexto;

namespace ProyectoFestivos.Infraestructura.Repositorio
{
    public class FestivoRepositorio : IFestivoRepositorio
    {
        private readonly ProyectoFestivosContext context;
        public FestivoRepositorio(ProyectoFestivosContext context)
        {
            this.context = context;
        }

        public async Task<Festivo> Agregar(Festivo Festivo)
        {
            context.Festivos.Add(Festivo);
            await context.SaveChangesAsync();
            return Festivo;
        }

        public async Task<IEnumerable<Festivo>>BuscarPorNombre(string Dato)
        {
            return await context.Festivos
                                            .Where(item => (item.Nombre.Contains(Dato)))
                                            .ToListAsync();
        }

        public async Task<bool> Eliminar(int Id)
        {
            var FestivoExistente = await context.Festivos.FindAsync(Id);
            if (FestivoExistente == null)
            {
                return false;
            }
            try
            {
                context.Festivos.Remove(FestivoExistente);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Festivo> Modificar(Festivo Festivo)
        {
            var FestivoExistente = await context.Festivos.FindAsync(Festivo.Id);
            if (FestivoExistente == null)
            {
                return null;
            }
            context.Entry(FestivoExistente).CurrentValues.SetValues(Festivo);
            await context.SaveChangesAsync();
            return await context.Festivos.FindAsync(Festivo.Id);
        }

        public async Task<IEnumerable<Festivo>> ObtenerTodos()
        {
            return await context.Festivos.ToArrayAsync();
        }
    }
}
