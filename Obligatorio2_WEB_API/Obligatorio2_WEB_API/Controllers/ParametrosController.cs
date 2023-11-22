using DTOs;
using ExcepcionesPropias;
using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCU;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;

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
        public IListadoParametros CUListadoParametros { get; set; }
        public IBuscarParametroPorId CUBuscarParametroPorId { get; set; }



        public ParametrosController(IBuscarParametroPorNombre cuBuscarParametroPorNombre,
                                        IModificarParametro cuModificarParametro
                                        , IVOModificarMaxLargoNombre cuVOModificarMaxLargoNombre, IVOModificarMinLargoNombre cuVOModificarMinLargoNombre,
                                         IVOModificarMaxLargoDescripcion cuVOModificarMaxLargoDescripcion,
                                        IVOModificarMinLargoDescripcion cuVOModificarMinLargoDescripcion, IListadoParametros cuListadoParametros,
                                        IBuscarParametroPorId cuBuscarParametroPorId)
        {

            
            CUBuscarParametroPorNombre = cuBuscarParametroPorNombre;
            CUModificarParametro = cuModificarParametro;
            CUVOModificarMaxLargoNombre = cuVOModificarMaxLargoNombre;
            CUVOModificarMinLargoNombre = cuVOModificarMinLargoNombre;
            CUVOModificarMaxLargoDescripcion = cuVOModificarMaxLargoDescripcion;
            CUVOModificarMinLargoDescripcion = cuVOModificarMinLargoDescripcion;
            CUListadoParametros = cuListadoParametros;
            CUBuscarParametroPorId = cuBuscarParametroPorId;
        }


        // GET: api/<ParametrosController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<ParametroDTO> parametros = null;

            try
            {
                parametros = CUListadoParametros.Listado();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado");
            }

            return Ok(parametros);
        }

        // GET api/<ParametrosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0) return BadRequest("El id debe ser mayor a 0");

            ParametroDTO parametro = null;

            try
            {
                parametro = CUBuscarParametroPorId.Buscar(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado.");
            }

            if (parametro == null) return NotFound($"El parametro con el id {id} no existe en la base de datos");

            return Ok(parametro);
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
        [Authorize(Roles = "Admin,Usuario")]
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
