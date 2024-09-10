using ProyectoFestivos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivos.Core.Interfaces.Servicio
{
    public interface IFestivoServicio
    {
        Task<IEnumerable<Festivo>> ObtenerTodos();
        Task<Festivo> ObtenerPorId(int id);
        Task<IEnumerable<Festivo>> BuscarPorNombre(string nombre);
        Task<Festivo> Agregar(Festivo festivo);
        Task<Festivo> Modificar(Festivo festivo);
        Task<bool> Eliminar(int id);
    }
}

