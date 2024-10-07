using Festivos.Core.Interfaces.Servicio;
using Microsoft.AspNetCore.Mvc;
using ProyectoFestivos.Dominio.Entidades;

namespace ProyectoFestivos.Presentacion.Controllers
{
    [ApiController]
    [Route("api/Tipo")]
    public class TipoController : ControllerBase
    {
        private readonly ITipoServicio servicio;
        public TipoController(ITipoServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<Tipo>>> ObtenerTodos()
        {
            return Ok(await servicio.ObtenerTodos());
        }

        [HttpGet("Obtener/{nombre}")]
        public async Task<ActionResult<IEnumerable<Tipo>>> Obtener(string nombre)
        {
            return Ok(await servicio.Obtener(nombre));
        }

        [HttpGet("buscar/{IndiceDato}/{Dato}")]
        public async Task<ActionResult<IEnumerable<Tipo>>> Buscar(int IndiceDato, string Dato)
        {
            return Ok(await servicio.Buscar(IndiceDato, Dato));
        }

        [HttpPost("agregar")]
        public async Task<ActionResult<Tipo>> Agregar(Tipo tipo)
        {
            return Ok(await servicio.Agregar(tipo));
        }

        [HttpPut("modificar")]
        public async Task<ActionResult<Tipo>> Modificar(Tipo tipo)
        {
            return Ok(await servicio.Modificar(tipo));
        }

        [HttpDelete("eliminar/{Id}")]
        public async Task<ActionResult<bool>> Eliminar(int Id)
        {
            return Ok(await servicio.Eliminar(Id));
        }
    }
}
