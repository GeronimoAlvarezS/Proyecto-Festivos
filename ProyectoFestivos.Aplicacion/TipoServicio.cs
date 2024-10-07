using Festivos.Core.Interfaces.Repositorios;
using Festivos.Core.Interfaces.Servicio;
using ProyectoFestivos.Dominio.Entidades;

namespace ProyectoFestivos.Aplicacion
{
    public class TipoServicio : ITipoServicio
    {
        private readonly ITipoRepositorio repositorio;

        public TipoServicio(ITipoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public Task<Tipo> Agregar(Tipo tipo)
        {
            return repositorio.Agregar(tipo);
        }

        public Task<IEnumerable<Tipo>> Buscar(int IndiceDato, string Dato)
        {
            return repositorio.Buscar(IndiceDato, Dato);
        }

        public Task<bool> Eliminar(int id)
        {
            return repositorio.Eliminar(id);
        }

        public Task<Tipo> Modificar(Tipo tipo)
        {
            return repositorio.Modificar(tipo);
        }

        public Task<string> Obtener(string nombre)
        {
            return repositorio.Obtener(nombre);
        }

        public Task<IEnumerable<Tipo>> ObtenerTodos()
        {
            return repositorio.ObtenerTodos();
        }
    }
}