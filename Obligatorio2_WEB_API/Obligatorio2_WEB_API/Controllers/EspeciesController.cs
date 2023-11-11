using DTOs;
using ExcepcionesPropias;
using LogicaAplicacion.InterfacesCU;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Obligatorio2_WEB_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    
    public class EspeciesController : ControllerBase
    {
        public IWebHostEnvironment WHE { get; set; }
        public IListadoEcosistemas CUListadoEcosistema { get; set; }
        public IListadoEspecie CUListadoEspecie { get; set; }
        public IAltaEspecie CUAltaEsp { get; set; }
        public IBajaEspecie CUBajaEspecie { get; set; }
        public IBuscarEspeciePorId CUBuscarEspeciePorid { get; set; }
        public IObtenerEstadosDeConservacion CUObtenerEstadosDeConservacion { get; set; }
        public IObtenerHabitatsDeLaEspecie CUObtenerHabitatsDeLaEspecie { get; set; }
        public IAsignarUnEcosistema CUAsignarUnEcosistema { get; set; }
        public IListadoAmenaza CUlistadoAmenazas { get; set; }
        public IObtenerAmenaza CUObtenerAmenaza { get; set; }
        public IAsignarAmenazaAEspecie CUAsignarAmenaza { get; set; }
        public IObtenerIdsDeAmenazasDeEspecies CUObtenerIdsDeAmenazasDeEspecies { get; set; }
        public IAmenazaEnComun CUAmenazaEnComun { get; set; }
        public IEstadosCompatibles CUEstadosCompatibles { get; set; }
        public IEspeciesOrdenadasPorNombreCientifico CUEspeciesOrdenadasPorNombreCientifico { get; set; }
        public IEspeciesEnPeligroDeExtincion CUEspeciesEnPeligroDeExtincion { get; set; }
        public IEspeciesFiltradasPorEcosistema CUEspeciesFiltradasPorEcosistema { get; set; }
        public IObtenerEspeciePorNombreCientifico CUObtenerEspeciePorNombreCientifico { get; set; }
        public IAmenazasDeUnaEspecie CUAmenazasDeUnaEspecie { get; set; }
        public IBuscarEspeciesPorRangoDePeso CUBuscarEspeciesPorRangoDePeso { get; set; }

        public IModificarEspecie CUModificarEspecie { get; set; }
        public IBuscarEcosistemaPorNombre CUBuscarEcosistemaPorNombre { get; set; }
        public IEcosistemasQueNoPuedeHabitarUnaEspecie CUEcosistemasQueNoPuedeHabitarUnaEspecie { get; set; }






        public EspeciesController(IWebHostEnvironment whe, IListadoEcosistemas cuListaEco, IAltaEspecie CUalta, IListadoEspecie cuListadoEspecie,
                                      IBajaEspecie cuBajaEspecie, IBuscarEspeciePorId cuBuscarPorid,
                                      IObtenerEstadosDeConservacion cuObtenerEstadosDeConservacion,
                                      IObtenerHabitatsDeLaEspecie cuObtenerHabitatsDeLaEspecie,
                                      IAsignarUnEcosistema cuAsignarUnEcosistema, IListadoAmenaza culistadoAmenazas,
                                      IObtenerAmenaza cuObtenerAmenaza, IAsignarAmenazaAEspecie cuAsignarAmenaza,
                                      IObtenerIdsDeAmenazasDeEspecies cuObtenerIdsDeAmenazasDeEspecies,
                                      IAmenazaEnComun cuAmenazaEnComun, IEstadosCompatibles cuEstadosCompatibles,
                                      IEspeciesOrdenadasPorNombreCientifico cuEspeciesOrdenadasPorNombreCientifico,
                                      IEspeciesEnPeligroDeExtincion cUEspeciesEnPeligroDeExtincion,
                                      IEspeciesFiltradasPorEcosistema cuEspeciesFiltradasPorEcosistema, IObtenerEspeciePorNombreCientifico cuObtenerEspeciePorNombreCientifico,
                                      IAmenazasDeUnaEspecie cuAmenazasDeUnaEspecie, IBuscarEspeciesPorRangoDePeso cUBuscarEspeciesPorRangoDePeso,
                                      IModificarEspecie cUModificarEspecie, IBuscarEcosistemaPorNombre cUBuscarEcosistemaPorNombre,
                                      IEcosistemasQueNoPuedeHabitarUnaEspecie cUEcosistemasQueNoPuedeHabitarUnaEspecie)
        {

            WHE = whe;
            CUListadoEcosistema = cuListaEco;
            CUAltaEsp = CUalta;
            CUListadoEspecie = cuListadoEspecie;
            CUBajaEspecie = cuBajaEspecie;
            CUBuscarEspeciePorid = cuBuscarPorid;
            CUObtenerEstadosDeConservacion = cuObtenerEstadosDeConservacion;
            CUObtenerHabitatsDeLaEspecie = cuObtenerHabitatsDeLaEspecie;
            CUAsignarUnEcosistema = cuAsignarUnEcosistema;
            CUlistadoAmenazas = culistadoAmenazas;
            CUObtenerAmenaza = cuObtenerAmenaza;
            CUAsignarAmenaza = cuAsignarAmenaza;
            CUObtenerIdsDeAmenazasDeEspecies = cuObtenerIdsDeAmenazasDeEspecies;
            CUAmenazaEnComun = cuAmenazaEnComun;
            CUEstadosCompatibles = cuEstadosCompatibles;
            CUEspeciesOrdenadasPorNombreCientifico = cuEspeciesOrdenadasPorNombreCientifico;
            CUEspeciesEnPeligroDeExtincion = cUEspeciesEnPeligroDeExtincion;
            CUEspeciesFiltradasPorEcosistema = cuEspeciesFiltradasPorEcosistema;
            CUObtenerEspeciePorNombreCientifico = cuObtenerEspeciePorNombreCientifico;
            CUAmenazasDeUnaEspecie = cuAmenazasDeUnaEspecie;
            CUBuscarEspeciesPorRangoDePeso = cUBuscarEspeciesPorRangoDePeso;
            CUModificarEspecie = cUModificarEspecie;
            CUBuscarEcosistemaPorNombre = cUBuscarEcosistemaPorNombre;
            CUEcosistemasQueNoPuedeHabitarUnaEspecie = cUEcosistemasQueNoPuedeHabitarUnaEspecie;
        }

        // GET: api/<EspeciesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EspeciesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EspeciesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EspeciesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EspeciesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest("El id debe ser un número positivo mayor a cero");
            string nombreUsuario = "Daniel";
            try
            {
                EspecieDTO especie = CUBuscarEspeciePorid.Buscar(id);
                if (especie == null) return NotFound("El ecosistema con el id " + id + " no existe");

                CUBajaEspecie.BajaEspecie(especie, nombreUsuario);
                return NoContent();
            }
            catch (EcosistemaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado");
            }
        }
    }
}
