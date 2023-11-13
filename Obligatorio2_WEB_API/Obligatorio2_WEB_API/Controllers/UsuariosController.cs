using DTOs;
using ExcepcionesPropias;
using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Obligatorio2_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public IAltaUsuario CUAltaUsuario { get; set; }
        public IListadoUsuario CUListadoUsuario { get; set; }
        public IObtenerUsuarioParaLogear CUObtenerUsuarioParaLogear { get; set; }
        public IVerSiExisteUsuario CUVerSiExisteUsuario { get; set; }
        public IBuscarUsuarioPorId CUBuscarUsuarioPorId { get; set; }
        public IBajaUsuario CUBajaUsuario { get; set; }
        public IModificarUsuario CUModificarUsuario { get; set; }

        public UsuariosController(IAltaUsuario CUAltaUsu, IListadoUsuario CUListUsu,
                                    IObtenerUsuarioParaLogear CUobtenerUsuarioParaLogear, IVerSiExisteUsuario CUverSiExisteUsu,
                                    IBuscarUsuarioPorId cuBuscarUsuarioPorId, IBajaUsuario cuBajaUsuario, IModificarUsuario
                                    cuModificarUsuario)
        {
            CUAltaUsuario = CUAltaUsu;
            CUListadoUsuario = CUListUsu;
            CUObtenerUsuarioParaLogear = CUobtenerUsuarioParaLogear;
            CUVerSiExisteUsuario = CUverSiExisteUsu;
            CUBuscarUsuarioPorId = cuBuscarUsuarioPorId;
            CUBajaUsuario = cuBajaUsuario;
            CUModificarUsuario = cuModificarUsuario;
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<UsuarioDTO> usuarios = null;

            try
            {
                usuarios = CUListadoUsuario.Listado();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado");
            }

            return Ok(usuarios);
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0) return BadRequest("El id debe ser mayor a 0");

            UsuarioDTO usuario = null;

            try
            {
                usuario = CUBuscarUsuarioPorId.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado.");
            }

            if (usuario == null) return NotFound($"El usuario con el id {id} no existe en la base de datos");

            return Ok(usuario);
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public IActionResult Post(UsuarioDTO usuario)
        {
            string nombreUsuario = "Daniel";//HttpContext.Session.GetString("nombre");

            if (usuario == null)
            {
                return BadRequest("La información enviada no es correcta para el alta");
            }

            try
            {
                CUAltaUsuario.AltaUsuario(usuario, nombreUsuario);
                return CreatedAtRoute("BuscarPorId", new { id = usuario.Id }, usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado.");
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest("El id debe ser un número positivo mayor a cero");
            string nombreUsuario = "Daniel";
            try
            {
                UsuarioDTO usuario = CUBuscarUsuarioPorId.BuscarPorId(id);
                if (usuario == null) return NotFound("El usuario con el id " + id + " no existe");

                CUBajaUsuario.BajaUsuario(usuario, nombreUsuario);
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
