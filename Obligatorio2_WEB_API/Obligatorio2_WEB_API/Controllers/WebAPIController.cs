using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Obligatorio2_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebAPIController : ControllerBase
    {
        [HttpPost]
        [Authorize]
        public IActionResult Post(UsuarioDTO usu)
        {
            ManejadorJWT manejadorJWT = new ManejadorJWT();
            return Ok();
        }
    }
}
