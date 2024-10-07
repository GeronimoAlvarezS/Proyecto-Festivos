using ProyectoFestivos.Infraestructura.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;
using Festivos.Core.Interfaces.Repositorios;
using ProyectoFestivos.Infraestructura.Repositorio;
using ProyectoTipos.Infraestructura.Repositorio;
using Festivos.Core.Interfaces.Servicio;
using ProyectoFestivos.Aplicacion;

namespace ProyectoFestivos.Presentacion.InyeccionDependencias
{
    public static class InyeccionDependencias
    {
       public static IServiceCollection AgregarDependencias(this IServiceCollection servicios, IConfiguration configuration)
        {
            servicios.AddDbContext<ProyectoFestivosContext>(opciones =>
            {
                opciones.UseSqlServer(configuration.GetConnectionString("Festivos"));
            });

            servicios.AddTransient<IFestivoRepositorio, FestivoRepositorio>();
            servicios.AddTransient<ITipoRepositorio, TipoRepositorio>();

            servicios.AddTransient<IFestivoServicio, FestivoServicio>();
            servicios.AddTransient<ITipoServicio, TipoServicio>();

            return servicios;
        }
    }
}
