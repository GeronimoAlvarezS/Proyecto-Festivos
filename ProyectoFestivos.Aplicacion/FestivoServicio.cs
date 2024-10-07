using Festivos.Core.Interfaces.Repositorios;
using Festivos.Core.Interfaces.Servicio;
using ProyectoFestivos.Dominio.Entidades;

namespace ProyectoFestivos.Aplicacion
{
    public class FestivoServicio : IFestivoServicio
    {
        private readonly IFestivoRepositorio repositorio;

        public FestivoServicio(IFestivoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public Task<Festivo> Agregar(Festivo festivo)
        {
            return repositorio.Agregar(festivo);
        }

        public Task<DateTime> AgregarDias(DateTime fecha, int dias)
        {
            return Task.FromResult(fecha.AddDays(dias));
        }

        public Task<IEnumerable<Festivo>> Buscar(int IndiceDato, string Dato)
        {
            return repositorio.Buscar(IndiceDato, Dato);
        }

        public Task<bool> Eliminar(int id)
        {
            return repositorio.Eliminar(id);
        }

        public Task<Festivo> Modificar(Festivo festivo)
        {
            return repositorio.Modificar(festivo);
        }

        public Task<IEnumerable<Festivo>> Obtener(string nombre)
        {
            return repositorio.Obtener(nombre);
        }

        public Task<DateTime> ObtenerFechaFija(int año, int mes, int dia)
        {
            return Task.FromResult(new DateTime(año, mes, dia));
        }

        public Task<DateTime> ObtenerInicioSemanaSanta(int año)
        {
            int a = año % 19;
            int b = año % 4;
            int c = año % 7;
            int d = (19 * a + 24) % 30;
            int dias = d + (2 * b + 4 * c + 6 * d + 5) % 7;

            int dia = 15 + dias;
            int mes = 3;

            if (dia > 31)
            {
                dia -= 31;
                mes = 4;
            }
            return Task.FromResult(new DateTime(año, mes, dia));
        }

        public Task<IEnumerable<Festivo>> ObtenerTodos()
        {
            return repositorio.ObtenerTodos();
        }

        public Task<DateTime> SiguienteLunes(DateTime fecha)
        {
            DayOfWeek diaSemana = fecha.DayOfWeek;

            if (diaSemana != DayOfWeek.Monday)
            {
                int diasParaSumar = ((int)DayOfWeek.Monday - (int)diaSemana + 7) % 7;
                if (diasParaSumar == 0) diasParaSumar = 7;
                fecha = fecha.AddDays(diasParaSumar);
            }

            return Task.FromResult(fecha);
        }
    }
}
