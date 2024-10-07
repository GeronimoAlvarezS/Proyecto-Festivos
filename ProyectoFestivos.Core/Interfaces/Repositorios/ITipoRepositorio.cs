using ProyectoFestivos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivos.Core.Interfaces.Repositorios
{
    public interface ITipoRepositorio
    {
        Task<IEnumerable<Tipo>> ObtenerTodos();
        Task<string> Obtener(string nombre);
        Task<Tipo> Agregar(Tipo tipo);
        Task<Tipo> Modificar(Tipo tipo);
        Task<bool> Eliminar(int id);
        Task<IEnumerable<Tipo>> Buscar(int IndiceDato, String Dato);
    }
}
