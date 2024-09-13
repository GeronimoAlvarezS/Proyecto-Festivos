using ProyectoFestivos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivos.Core.Interfaces.Servicio
{
    public interface ITipoServicio
    {

        Task<IEnumerable<Tipo>> ObtenerTodos();
        Task<Tipo> ObtenerPorId(int id);
        Task<Tipo> Agregar(Tipo tipo);
        Task<Tipo> Modificar(Tipo tipo);
        Task<bool> Eliminar(int id);
        Task<bool> VerificacionTipoFestivo(DateTime fecha);
    }
}
