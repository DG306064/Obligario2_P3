using DTOs;
using ExcepcionesPropias;
using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCU;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Obligatorio2_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametrosController : ControllerBase
    {
        
        public IModificarParametro CUModificarParametro { get; set; }
        public IBuscarParametroPorNombre CUBuscarParametroPorNombre { get; set; }
        public IVOModificarMaxLargoNombre CUVOModificarMaxLargoNombre { get; set; }
        public IVOModificarMinLargoNombre CUVOModificarMinLargoNombre { get; set; }
        public IVOModificarMaxLargoDescripcion CUVOModificarMaxLargoDescripcion { get; set; }
        public IVOModificarMinLargoDescripcion CUVOModificarMinLargoDescripcion { get; set; }



        public ParametrosController(IBuscarParametroPorNombre cuBuscarParametroPorNombre,
                                        IModificarParametro cuModificarParametro
                                        , IVOModificarMaxLargoNombre cuVOModificarMaxLargoNombre, IVOModificarMinLargoNombre cuVOModificarMinLargoNombre,
                                         IVOModificarMaxLargoDescripcion cuVOModificarMaxLargoDescripcion,
                                        IVOModificarMinLargoDescripcion cuVOModificarMinLargoDescripcion)
        {

            
            CUBuscarParametroPorNombre = cuBuscarParametroPorNombre;
            CUModificarParametro = cuModificarParametro;
            CUVOModificarMaxLargoNombre = cuVOModificarMaxLargoNombre;
            CUVOModificarMinLargoNombre = cuVOModificarMinLargoNombre;
            CUVOModificarMaxLargoDescripcion = cuVOModificarMaxLargoDescripcion;
            CUVOModificarMinLargoDescripcion = cuVOModificarMinLargoDescripcion;
        }


        // GET: api/<ParametrosController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ParametrosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("nombre/{nombre}",Name ="BuscarParametroPorNombre")]
        public IActionResult BuscarParametroPorNombre(string nombre)
        {
            if (nombre.IsNullOrEmpty()) return BadRequest("El nombre no puede estar vacio.");

            ParametroDTO parametro = null;

            try
            {
                parametro = CUBuscarParametroPorNombre.BuscarParametroPorNombre(nombre);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado.");
            }

            if (parametro == null) return NotFound($"El parametro con el nombre {nombre} no existe en la base de datos");

            return Ok(parametro);
        }

        // POST api/<ParametrosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ParametrosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(ParametroDTO p)
        {
            string nombreUsuario = "Daniel";
            if (p == null)
            {
                return BadRequest("No se envió información para el alta");
            }

            try
            {
                CUModificarParametro.Modificar(p, nombreUsuario);
                return Ok(p);
            }
            catch (PaisException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrión un error inesperado");
            }
        }

        // DELETE api/<ParametrosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
