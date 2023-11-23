using DTOs;
using LogicaAplicacion.CasosUso;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Obligatorio2_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebAPIController : ControllerBase
    {

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Post(UsuarioDTO usu)
        {
            ManejadorJWT manejadorJWT = new ManejadorJWT();
            return Ok();
        }

        //public ActionResult Get()
        //{
        //    IEnumerable<PaisDTO> paises = null;

        //    HttpClient cliente = new HttpClient();

        //    string url = "http://localhost:5285/api/Especies";

        //    Task<HttpResponseMessage> tarea1 = cliente.GetAsync(url);
        //    tarea1.Wait();

        //    HttpResponseMessage respuesta = tarea1.Result;

        //    var contenido = respuesta.Content;

        //    Task<string> tarea2 = contenido.ReadAsStringAsync();

        //    tarea2.Wait();

        //    string body = tarea2.Result;

        //    if (respuesta.IsSuccessStatusCode)
        //    {


        //        especies = JsonConvert.DeserializeObject<List<EspecieDTO>>(body);

        //        var vms = especies.Select(e => new EspecieViewModel()
        //        {
        //            Id = e.Id,
        //            NombreCientifico = e.NombreCientifico,
        //            NombreComun = e.NombreComun,
        //            Descripcion = e.Descripcion,
        //            NombreImagenEspecie = e.ImagenEspecie
        //        });

        //        return View(vms);
        //    }
        //    else
        //    {
        //        ViewBag.Error = body;
        //        return View(new List<EspecieDTO>());
        //    }
        //}
    }
}
