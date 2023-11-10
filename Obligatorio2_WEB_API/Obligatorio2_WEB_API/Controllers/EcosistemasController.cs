using DTOs;
using LogicaAplicacion.InterfacesCU;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Obligatorio2_Web_API.Controllers
{
    [Route("api/ecosistemas")]
    [ApiController]
    public class EcosistemasController : ControllerBase
    {
        public IWebHostEnvironment WHE { get; set; }
        public IListadoEcosistemas CUListadoEcosistema { get; set; }
        public IListadoPaises CUListadoPaises { get; set; }
        public IBuscarEcosistemaPorId CUBuscarEcosistemaPorId { get; set; }
        public IAltaEcosistema CUAltaEcosistema { get; set; }
        public IBajaEcosistema CUBajaEco { get; set; }
        public IObtenerEstadosDeConservacion CUObtenerEstadosDeConservacion { get; set; }
        public IListadoAmenaza CUlistadoAmenazas { get; set; }
        public IObtenerIdsDeAmenazasDelEcosistema CUObtenerIdsDeAmenazasDelEcosistema { get; set; }
        public IAsignarAmenazaAEcosistema CUAsignarAmenaza { get; set; }
        public ICantidadDeEspeciesEnEcosistema CUCantidadDeEspeciesEnEcosistema { get; set; }
        public IAmenazasDeUnEcosistema CUAmenazasDeUnEcosistema { get; set; }
        public IActualizarEcosistema CUActualizarEcosistema { get; set; }

        public IEcosistemasQueNoPuedeHabitarUnaEspecie CUEcosistemasQueNoPuedeHabitarUnaEspecie { get; set; }




        public EcosistemasController(IWebHostEnvironment whe, IListadoEcosistemas cuListaEco, IListadoPaises cuListaPais, IAltaEcosistema CUAltaecosistema,
                                    IBuscarEcosistemaPorId CuBuscarEco, IBajaEcosistema CUbajaEco, IObtenerEstadosDeConservacion
                                 cuObtenerEstadosDeConservacion, IListadoAmenaza culistadoAmenazas, IObtenerIdsDeAmenazasDelEcosistema
                                cuObtenerIdsDeAmenazasDelEcosistema, IAsignarAmenazaAEcosistema cuAsignarAmenaza,
                                    ICantidadDeEspeciesEnEcosistema cUCantidadDeEspeciesEnEcosistema, IAmenazasDeUnEcosistema cuAmenazasDeUnEcosistema,
                                    IEcosistemasQueNoPuedeHabitarUnaEspecie cUEcosistemasQueNoPuedeHabitarUnaEspecie,
                                     IActualizarEcosistema cuActualizarEcosistema)
        {



            CUListadoEcosistema = cuListaEco;
            CUListadoPaises = cuListaPais;
            CUAltaEcosistema = CUAltaecosistema;
            CUBuscarEcosistemaPorId = CuBuscarEco;
            CUBajaEco = CUbajaEco;
            CUObtenerEstadosDeConservacion = cuObtenerEstadosDeConservacion;
            CUlistadoAmenazas = culistadoAmenazas;
            CUObtenerIdsDeAmenazasDelEcosistema = cuObtenerIdsDeAmenazasDelEcosistema;
            CUAsignarAmenaza = cuAsignarAmenaza;
            CUCantidadDeEspeciesEnEcosistema = cUCantidadDeEspeciesEnEcosistema;
            WHE = whe;
            CUAmenazasDeUnEcosistema = cuAmenazasDeUnEcosistema;
            CUEcosistemasQueNoPuedeHabitarUnaEspecie = cUEcosistemasQueNoPuedeHabitarUnaEspecie;
            CUActualizarEcosistema = cuActualizarEcosistema;

        }
        // GET: api/<EcosistemasController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<EcosistemaDTO> ecosistemas = null;

            try
            {
                ecosistemas = CUListadoEcosistema.Listado();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrión un error inesperado");
            }

            return Ok(ecosistemas);
        }

        // GET api/<EcosistemasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EcosistemasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EcosistemasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EcosistemasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
