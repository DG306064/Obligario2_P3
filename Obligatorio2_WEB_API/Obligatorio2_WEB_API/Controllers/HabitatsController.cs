using DTOs;
using ExcepcionesPropias;
using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Obligatorio2_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitatsController : ControllerBase
    {
        public IListadoEcosistemas CUListadoEcosistema { get; set; }
        public IAltaHabitat CUAltaHabitat { get; set; }
        public IBuscarEspeciePorId CUBuscarEspeciePorId { get; set; }
        public IBuscarHabitatPorId CUBuscarHabitatPorId { get; set; }
        public IObtenerHabitatsDeLaEspecie CUObtenerHabitatsDeLaEspecie { get; set; }
        public IAgregarHabitatEnLaEspecie CUAgregarHabitatEnLaEspecie { get; set; }
        public IBajaHabitat CUBajaHabitat { get; set; }

        public IEcosistemasSinHabitatEnUnaEspecie CUEcosistemasSinHabitatEnUnaEspecie { get; set; }




        public HabitatsController(IListadoEcosistemas cuListaEco, IAltaHabitat cuIAltaHabitat, IBuscarEspeciePorId cuBuscarEspeciePorId,
                                    IBuscarHabitatPorId CUBuscarHabitatporId, IObtenerHabitatsDeLaEspecie cuObtenerHabitatsDeLaEspecie,
                                    IAgregarHabitatEnLaEspecie cuAgregarHabitatEnLaEspecie, IEcosistemasSinHabitatEnUnaEspecie
                                    cuEcosistemasSinHabitatEnUnaEspecie, IBajaHabitat cuBajaHabitat)
        {
            CUListadoEcosistema = cuListaEco;
            CUAltaHabitat = cuIAltaHabitat;
            CUBuscarEspeciePorId = cuBuscarEspeciePorId;
            CUBuscarHabitatPorId = CUBuscarHabitatporId;
            CUObtenerHabitatsDeLaEspecie = cuObtenerHabitatsDeLaEspecie;
            CUAgregarHabitatEnLaEspecie = cuAgregarHabitatEnLaEspecie;
            CUEcosistemasSinHabitatEnUnaEspecie = cuEcosistemasSinHabitatEnUnaEspecie;
            CUBajaHabitat = cuBajaHabitat;
        }



        // GET: api/<HabitatsController>


        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<HabitatsController>/5

        [Authorize(Roles = "Admin,Usuario")]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HabitatsController>


        [HttpPost]
        public IActionResult Post(HabitatDTO habitat)
        {
            string nombreUsuario = "Daniel";//HttpContext.Session.GetString("nombre");

            if (habitat == null)
            {
                return BadRequest("La información enviada no es correcta para el alta");
            }

            try
            {
                CUAltaHabitat.Alta(habitat, nombreUsuario);
                return CreatedAtRoute("BuscarPorId", new { id = habitat.Id }, habitat);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado.");
            }
        }

        // PUT api/<HabitatsController>/5


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HabitatsController>/5
        [EnableCors]
        [Authorize(Roles = "Admin,Usuario")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest("El id debe ser un número positivo mayor a cero");
            string nombreUsuario = "Daniel";
            try
            {
                HabitatDTO habitat = CUBuscarHabitatPorId.BuscarHabitatPorId(id);
                if (habitat == null) return NotFound("El habitat con el id " + id + " no existe");

                CUBajaHabitat.Baja(habitat, nombreUsuario);
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
