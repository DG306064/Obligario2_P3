using DTOs;
using LogicaAplicacion.CasosUso;
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
    public class PaisesController : ControllerBase
    {
        IListadoPaises CUListadoPaises { get; set; }

        public PaisesController(IListadoPaises cuListadoPaises)
        {
            CUListadoPaises = cuListadoPaises;
        }


        // GET: api/<PaisesController>


        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<PaisDTO> paises = null;

            try
            {
                paises = CUListadoPaises.Listado();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocurrió un error inesperado");
            }

            return Ok(paises);
        }

        // GET api/<PaisesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PaisesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PaisesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PaisesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
