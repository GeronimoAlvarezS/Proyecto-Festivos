using ProyectoFestivos.Infraestructura.Persistencia.Contexto;
using ProyectoFestivos.Dominio.Entidades;
using Festivos.Core.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace ProyectoTipos.Infraestructura.Repositorio
{
    public class TipoRepositorio : ITipoRepositorio
    {
        private readonly ProyectoFestivosContext context;
        public TipoRepositorio(ProyectoFestivosContext context)
        {
            this.context = context;
        }

        public async Task<Tipo> Agregar(Tipo Tipo)
        {
            context.Tipos.Add(Tipo);
            await context.SaveChangesAsync();
            return Tipo;
        }

        public async Task<IEnumerable<Tipo>> BuscarPorNombre(string Dato)
        {
            return await context.Tipos
                                            .Where(item => (item.Nombre.Contains(Dato)))
                                            .ToListAsync();
        }

        public async Task<bool> Eliminar(int Id)
        {
            var TipoExistente = await context.Tipos.FindAsync(Id);
            if (TipoExistente == null)
            {
                return false;
            }
            try
            {
                context.Tipos.Remove(TipoExistente);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Tipo> Modificar(Tipo Tipo)
        {
            var TipoExistente = await context.Tipos.FindAsync(Tipo.Id);
            if (TipoExistente == null)
            {
                return null;
            }
            context.Entry(TipoExistente).CurrentValues.SetValues(Tipo);
            await context.SaveChangesAsync();
            return await context.Tipos.FindAsync(Tipo.Id);
        }

        public async Task<IEnumerable<Tipo>> ObtenerTodos()
        {
            return await context.Tipos.ToArrayAsync();
        }
    }
}
