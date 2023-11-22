using DTOs;
using ExcepcionesPropias;
using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Data.Odbc;
using NuGet.Common;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using System.Data;

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
        public IBuscarPaisPorId CUBuscarPaisPorId { get; set; }
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
        public IObtenerAmenaza CUObtenerAmenaza { get; set; }
        public IBuscarEstadoPorId CUBuscarEstadoPorId { get; set; }




        public EcosistemasController(IWebHostEnvironment whe, IListadoEcosistemas cuListaEco, IListadoPaises cuListaPais, IAltaEcosistema CUAltaecosistema,
                                    IBuscarEcosistemaPorId CuBuscarEco, IBajaEcosistema CUbajaEco, IObtenerEstadosDeConservacion
                                 cuObtenerEstadosDeConservacion, IListadoAmenaza culistadoAmenazas, IObtenerIdsDeAmenazasDelEcosistema
                                cuObtenerIdsDeAmenazasDelEcosistema, IAsignarAmenazaAEcosistema cuAsignarAmenaza,
                                    ICantidadDeEspeciesEnEcosistema cUCantidadDeEspeciesEnEcosistema, IAmenazasDeUnEcosistema cuAmenazasDeUnEcosistema,
                                    IEcosistemasQueNoPuedeHabitarUnaEspecie cUEcosistemasQueNoPuedeHabitarUnaEspecie,
                                     IActualizarEcosistema cuActualizarEcosistema, IObtenerAmenaza cuObtenerAmenaza, IBuscarPaisPorId cuBuscarPaisPorId,
                                     IBuscarEstadoPorId cuBuscarEstadoPorId)
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
            CUObtenerAmenaza = cuObtenerAmenaza;
            CUBuscarPaisPorId = cuBuscarPaisPorId;
            CUBuscarEstadoPorId = cuBuscarEstadoPorId;
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
                return StatusCode(500, "Ocurrió un error inesperado");
            }

            return Ok(ecosistemas);
        }

        // GET api/<EcosistemasController>/5
        [HttpGet("{id}", Name = "BuscarEcosistemaPorId")]
        public IActionResult Get(int id)
        {
            if (id <= 0) return BadRequest("El id debe ser un número mayor a 0.");

            EcosistemaDTO ecosistema = null;

            try
            {
                ecosistema = CUBuscarEcosistemaPorId.BuscarEcoPorId(id);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado");
            }

            if (ecosistema == null) return NotFound($"El ecosistema con id {id} no existe en la base de datos.");

            return Ok(ecosistema);
        }

        // POST api/<EcosistemasController>
        [HttpPost()]
        public IActionResult Alta([FromBody] EcosistemaDTO eco)
        {
            if (eco == null)
            {
                return BadRequest("La información enviada no es correcta para el alta");
            }

            try
            {
                eco.Pais = CUBuscarPaisPorId.Buscar(eco.IdPaisSeleccionado);
                eco.EstadoConservacion = CUBuscarEstadoPorId.Buscar(eco.IdEstadoConservacion);
                var nombreUsuario = eco.NombreUsuario;

                CUAltaEcosistema.Alta(eco, nombreUsuario);
                return CreatedAtRoute("BuscarPorId", new { id = eco.Id }, eco);
            }
            catch (EcosistemaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DescripcionException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrión un error inesperado");
            }
        }

        // PUT api/<EcosistemasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(EcosistemaDTO e)
        {
            string nombreUsuario = "Daniel";//HttpContext.Session.GetString("nombre");

            if (e == null)
            {
                return BadRequest("No se envió información para el alta");
            }

            try
            {
                CUActualizarEcosistema.Actualizar(e);
                return Ok(e);
            }
            catch (EcosistemaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrión un error inesperado");
            }
        }

        // DELETE api/<EcosistemasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest("El id debe ser un número positivo mayor a cero");
            string nombreUsuario = "Daniel";
            try
            {
                EcosistemaDTO ecosistema = CUBuscarEcosistemaPorId.BuscarEcoPorId(id);
                if (ecosistema == null) return NotFound("El ecosistema con el id " + id + " no existe");

                CUBajaEco.BorrarEcosistema(ecosistema, nombreUsuario);
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

        [HttpGet("EcosistemaPorId")]
        public IActionResult AsignarAmenazaAUnEcosistema(int id)
        {
            if (id == 0) return BadRequest("El id debe ser un numero mayor a 0.");

            string nombreUsuario = "Daniel";

            try
            {
                var ecosistema = CUBuscarEcosistemaPorId.BuscarEcoPorId(id);
                ecosistema.Amenazas = CUlistadoAmenazas.ListadoAmenaza();
                ecosistema.IdsDeLasAmenazas = CUObtenerIdsDeAmenazasDelEcosistema.ObtenerIdsDeAmenazasDelEcosistema(ecosistema.Id);

                return Ok(ecosistema);
            }
            catch (EcosistemaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error obteniendo las amenazas");
            }
        }

        [HttpPut("AsignarAmenaza")]
        public ActionResult AsignarAmenazaAEcosistema(int idAmenaza, int idEcosistema)
        {
            if (idAmenaza == 0 || idEcosistema == 0) return BadRequest("Los ids proporcionados deben ser mayor a 0.");

            string nombreUsuario = "Daniel";

            try
            {
                CUAsignarAmenaza.AsignarAmenazaAUnEcosistema(idAmenaza, idEcosistema, nombreUsuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado");
            }
        }

        [HttpGet("AmenazasDeEcosistema/{5}")]
        public ActionResult AmenazasDelEcosistema(int idEcosistema)
        {
            if (idEcosistema == 0) return BadRequest("El id del ecosistema debe ser mayor a 0.");

            string nombreUsuario = "Daniel";

            try
            {
                var amenazas = CUAmenazasDeUnEcosistema.AmenazasDeUnEcosistema(idEcosistema);
                return Ok(amenazas);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado");
            }
        }

        [HttpGet("busqueda/{busqueda}")]
        public ActionResult Busqueda(string busqueda)
        {
            if (busqueda.IsNullOrEmpty()) return BadRequest("El nombre de la especie no puede estar vacio.");

            var nombreUsuario = "Daniel";

            try
            {
                IEnumerable<EcosistemaDTO> ecosistemas = CUEcosistemasQueNoPuedeHabitarUnaEspecie.EcosistemasQueNoPuedeHabitarUnaEspecie(busqueda);
                return Ok(ecosistemas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado");
            }
        }
    }
}
