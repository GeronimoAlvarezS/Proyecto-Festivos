using Microsoft.AspNetCore.Mvc;
using Festivos.Core.Interfaces.Servicio;
using ProyectoFestivos.Dominio.Entidades;
using ProyectoFestivos.Aplicacion;
using ProyectoFestivos.Infraestructura.Repositorio;

namespace ProyectoFestivos.Presentacion.Controllers
{
    [ApiController]
    [Route("api/Festivo")]
    public class FestivoController : ControllerBase
    {
       private readonly IFestivoServicio servicio;

        public FestivoController(IFestivoServicio servicio)
        {
            this.servicio = servicio;
        }

        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<Festivo>>> ObtenerTodos()
        {
            return Ok(await servicio.ObtenerTodos());
        }

        [HttpGet("Obtener/{nombre}")]
        public async Task<ActionResult<IEnumerable<Festivo>>> Obtener(string nombre)
        {
            return Ok(await servicio.Obtener(nombre));
        }

        [HttpGet("buscar/{IndiceDato}/{Dato}")]
        public async Task<ActionResult<IEnumerable<Festivo>>> Buscar(int IndiceDato, string Dato)
        {
            return Ok(await servicio.Buscar(IndiceDato, Dato));
        }

        [HttpPost("agregar")]
        public async Task<ActionResult<Festivo>> Agregar(Festivo festivo)
        {
            return Ok(await servicio.Agregar(festivo));
        }

        [HttpPut("modificar")]
        public async Task<ActionResult<Festivo>> Modificar(Festivo festivo)
        {
            return Ok(await servicio.Modificar(festivo));
        }

        [HttpDelete("eliminar/{Id}")]
        public async Task<ActionResult<bool>> Eliminar(int Id)
        {
            return Ok(await servicio.Eliminar(Id));
        }

        [HttpGet("calcular/{año}")]
        public async Task<ActionResult<IEnumerable<Festivo>>> CalcularFestivos(int año)
        {
            var festivos = new List<Festivo>();

            DateTime DomingoRamos = await servicio.ObtenerInicioSemanaSanta(año);
            festivos.Add(new Festivo { Nombre = "Domingo de Ramos", Dia = DomingoRamos.Day, Mes = DomingoRamos.Month });

            DateTime domingoPascua = await servicio.AgregarDias(DomingoRamos, 7);
            festivos.Add(new Festivo { Nombre = "Domingo de Pascua", Dia = domingoPascua.Day, Mes = domingoPascua.Month });

            DateTime reyesMagos = await servicio.SiguienteLunes(new DateTime(año, 1, 6));
            festivos.Add(new Festivo { Nombre = "Reyes Magos", Dia = reyesMagos.Day, Mes = reyesMagos.Month });

            DateTime juevesSanto = await servicio.AgregarDias(domingoPascua, -3);
            festivos.Add(new Festivo { Nombre = "Jueves Santo", Dia = juevesSanto.Day, Mes = juevesSanto.Month });

            DateTime viernesSanto = await servicio.AgregarDias(domingoPascua, -2);
            festivos.Add(new Festivo { Nombre = "Viernes Santo", Dia = viernesSanto.Day, Mes = viernesSanto.Month });

            DateTime ascensionSenor = await servicio.SiguienteLunes(await servicio.AgregarDias(domingoPascua, 40));
            festivos.Add(new Festivo { Nombre = "Ascensión del Señor", Dia = ascensionSenor.Day, Mes = ascensionSenor.Month });

            DateTime corpusChristi = await servicio.SiguienteLunes(await servicio.AgregarDias(domingoPascua, 61));
            festivos.Add(new Festivo { Nombre = "Corpus Christi", Dia = corpusChristi.Day, Mes = corpusChristi.Month });

            DateTime sagradoCorazon = await servicio.SiguienteLunes(await servicio.AgregarDias(domingoPascua, 68));
            festivos.Add(new Festivo { Nombre = "Sagrado Corazón de Jesús", Dia = sagradoCorazon.Day, Mes = sagradoCorazon.Month });

            DateTime añoNuevo = await servicio.ObtenerFechaFija(año, 1, 1);
            festivos.Add(new Festivo { Nombre = "Año Nuevo", Dia = añoNuevo.Day, Mes = añoNuevo.Month });

            DateTime diaTrabajo = await servicio.ObtenerFechaFija(año, 5, 1);
            festivos.Add(new Festivo { Nombre = "Día del Trabajo", Dia = diaTrabajo.Day, Mes = diaTrabajo.Month });

            DateTime indepColombia = await servicio.ObtenerFechaFija(año, 7, 20);
            festivos.Add(new Festivo { Nombre = "Independencia de Colombia", Dia = indepColombia.Day, Mes = indepColombia.Month });

            DateTime batallaBoyaca = await servicio.ObtenerFechaFija(año, 8, 7);
            festivos.Add(new Festivo { Nombre = "Batalla de Boyacá", Dia = batallaBoyaca.Day, Mes = batallaBoyaca.Month });

            DateTime InmaConcepcion = await servicio.ObtenerFechaFija(año, 12, 8);
            festivos.Add(new Festivo { Nombre = "Inmaculada Concepción", Dia = InmaConcepcion.Day, Mes = InmaConcepcion.Month });

            DateTime navidad = await servicio.ObtenerFechaFija(año, 12, 25);
            festivos.Add(new Festivo { Nombre = "Navidad", Dia = navidad.Day, Mes = navidad.Month});

            return Ok(festivos);
        }
    }
}