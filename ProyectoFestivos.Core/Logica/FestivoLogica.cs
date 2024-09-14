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
    public class FestivoLogica : IFestivoServicio
    {
        private readonly IFestivoRepositorio _festivoRepositorio;

        public FestivoLogica (IFestivoRepositorio festivoRepositorio)
        {
            _festivoRepositorio = festivoRepositorio;
        }

        public async Task<IEnumerable<Festivo>>ObtenerTodos()
        {
            return await _festivoRepositorio.ObtenerTodos();
        }
        public async Task<Festivo>ObtenerPorId(int Id)
        {
            return await _festivoRepositorio.ObtenerPorId(Id);
        }

        public async Task<IEnumerable<Festivo>>BuscarPorNombre(string nombre)
        {
            return await _festivoRepositorio.BuscarPorNombre(nombre);
        }
        public async Task<Festivo> Agregar(Festivo festivo)
        {
            return await _festivoRepositorio.Agregar(festivo);
        }
        public async Task<Festivo> Modificar(Festivo festivo)
        {
            return await _festivoRepositorio.Modificar(festivo);
        }
        public async Task<bool> Eliminar(int Id)
        {
            return await _festivoRepositorio.Eliminar(Id);
        }
        public async Task<bool> VerificacionFestivo(DateTime fecha)
        {
            var festivos = await _festivoRepositorio.ObtenerTodos();
            return festivos.Any(f => f.Dia == fecha.Day && f.Mes == fecha.Month);
        }
    }
}
