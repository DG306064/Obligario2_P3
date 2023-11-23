using DTOs;
using LogicaAplicacion.InterfacesCU;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Obligatorio2_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosConservacionController : ControllerBase
    {
        IObtenerEstadosDeConservacion CUObtenerEstadosConservacion { get; set; }

        public EstadosConservacionController(IObtenerEstadosDeConservacion cuEstadosConservacion)
        {
            CUObtenerEstadosConservacion = cuEstadosConservacion;
        }

        // GET: api/<EstadosConservacionController>
        [EnableCors]

        [HttpGet]
        public IActionResult Get()
        {

            IEnumerable<EstadoConservacionDTO> estadosConservacion = null;
            try
            {
                estadosConservacion = CUObtenerEstadosConservacion.ObtenerEstadosDeConservacion();
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrio un error inesperado");
            }
            return Ok(estadosConservacion);
        }

        // GET api/<EstadosConservacionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EstadosConservacionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EstadosConservacionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EstadosConservacionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
