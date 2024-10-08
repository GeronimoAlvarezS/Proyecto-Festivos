﻿using ProyectoFestivos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festivos.Core.Interfaces.Repositorios
{
    public interface IFestivoRepositorio
    {
        Task<IEnumerable<Festivo>> ObtenerTodos();
        Task<IEnumerable<Festivo>> Obtener(string nombre);
        Task<Festivo> Agregar(Festivo festivo);
        Task<Festivo> Modificar(Festivo festivo);
        Task<bool> Eliminar(int id);
        Task<IEnumerable<Festivo>> Buscar(int IndiceDato, String Dato);
    }
}

