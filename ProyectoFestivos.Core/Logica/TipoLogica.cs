using Festivos.Core.Interfaces.Repositorios;
using Festivos.Core.Interfaces.Servicio;
using ProyectoFestivos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFestivos.Core.Logica
{
    public class TipoLogica : ITipoServicio
    {
        private readonly ITipoRepositorio _tipoRepositorio;

        public TipoLogica(ITipoRepositorio tipoRepositorio)
        {
            _tipoRepositorio = tipoRepositorio;
        }

        public async Task<IEnumerable<Tipo>> ObtenerTodos()
        {
            return await _tipoRepositorio.ObtenerTodos();
        }

        public async Task<Tipo> ObtenerPorId(int id)
        {
            return await _tipoRepositorio.ObtenerPorId(id);
        }

        public async Task<Tipo> Agregar(Tipo tipo)
        {
            return await _tipoRepositorio.Agregar(tipo);
        }

        public async Task<Tipo> Modificar(Tipo tipo)
        {
            return await _tipoRepositorio.Modificar(tipo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _tipoRepositorio.Eliminar(id);
        }

        public Task<bool> VerificacionTipoFestivo(DateTime fecha)
        {
            throw new NotImplementedException();
        }
    }
}
