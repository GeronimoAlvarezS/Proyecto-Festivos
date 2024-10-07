using ProyectoFestivos.Dominio.Entidades;

namespace Festivos.Core.Interfaces.Servicio
{
    public interface IFestivoServicio
    {
        Task<IEnumerable<Festivo>> ObtenerTodos();
        Task<IEnumerable<Festivo>> Obtener(string nombre);
        Task<Festivo> Agregar(Festivo festivo);
        Task<Festivo> Modificar(Festivo festivo);
        Task<bool> Eliminar(int id);
        Task<DateTime> ObtenerInicioSemanaSanta(int año);
        Task<DateTime> AgregarDias(DateTime fecha, int dias);
        Task<DateTime> SiguienteLunes(DateTime fecha);
        Task<DateTime> ObtenerFechaFija(int año, int mes, int dia);
        Task<IEnumerable<Festivo>> Buscar(int IndiceDato, String Dato);
    }

}

