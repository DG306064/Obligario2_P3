using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.DTOs;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MVC.Models;

namespace MVC.Controllers
{
    public class EcosistemasController : Controller
    {

        private HttpClient httpClient = new HttpClient();



        public EcosistemasController()
        {

        }


        [HttpGet]
        public ActionResult Index()
        {

            IEnumerable<DTOEcosistema> ecosistemas = null;

            HttpClient cliente = new HttpClient();

            string url = "http://localhost:5285/api/ecosistemas";

            var tarea1 = cliente.GetAsync(url);
            tarea1.Wait();

            var respuesta = tarea1.Result;

            var contenido = respuesta.Content;

            var tarea2 = contenido.ReadAsStringAsync();

            tarea2.Wait();

            string json = tarea2.Result;

            if (respuesta.IsSuccessStatusCode)
            {


                ecosistemas = JsonConvert.DeserializeObject<List<DTOEcosistema>>(json);
                var vms = ecosistemas.Select(e => new EcosistemaViewModel()
                {
                    Ecosistema = new DTOEcosistema()
                    {
                        Id = e.Id,
                        Nombre = e.Nombre,
                        Latitud = e.Latitud,
                        Longitud = e.Longitud,
                        Area = e.Area,
                        Descripcion = e.Descripcion,
                        NombreImagenEcosistema = e.NombreImagenEcosistema
                    }
                });

                return View(vms);
            }
            else
            {
                ViewBag.Error = json;
                return View();
            }
        }

        // GET: EcosistemasController/Details/5
        public ActionResult Details(int id)
        {
            DTOEcosistema ecosistema = new DTOEcosistema();

            HttpClient cliente = new HttpClient();

            string url = $"http://localhost:5285/api/Ecosistema/{id}";

            var tarea1 = cliente.GetAsync(url);
            tarea1.Wait();

            var respuesta = tarea1.Result;

            var contenido = respuesta.Content;

            var tarea2 = contenido.ReadAsStringAsync();

            tarea2.Wait();

            string json = tarea2.Result;

            if (respuesta.IsSuccessStatusCode)
            {


                ecosistema = JsonConvert.DeserializeObject<DTOEcosistema>(json);

                return View(ecosistema);
            }
            else
            {
                ViewBag.Error = json;
                return View();
            }
        }

        // GET: EcosistemasController/Create
        [HttpGet]
        public ActionResult Create()
        {

            //if (HttpContext.Session.GetString("nombre") == null)
            //{
            //    return View("NoAutorizado");
            //}

            //IEnumerable<Pais> paises = CUListadoPaises.Listado();

            DTOEcosistema vm = new DTOEcosistema();

            return View(vm);
        }

        // POST: EcosistemasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DTOEcosistema vm)
        {
            var ecosistema = new DTOEcosistema();
            return View("Details", ecosistema);
            //vm.Ecosistema.Amenazas = new List<Amenaza>();

            //Pais p = new Pais() { Id = vm.idPaisSeleccionado };
            //vm.Ecosistema.Pais = p;

            //EstadoConservacion estado = new EstadoConservacion() { Id = vm.idEstadoConservacion };
            //vm.Ecosistema.EstadoConservacion = estado;



            //try
            //{

            //    vm.Ecosistema.Nombre = new Nombre(vm.NombreEcosistema);

            //    vm.Ecosistema.Descripcion = new Descripcion(vm.DescripcionEcosistema);


            //    FileInfo fi = new FileInfo(vm.ImagenEcosistema.FileName);
            //    string ext = fi.Extension;

            //    if (ext == ".png" || ext == ".jpg" || ext == ".jpeg")
            //    {
            //        vm.Ecosistema.ImagenEcosistema = "";

            //        if (HttpContext.Session.GetString("nombre") == null) throw new CambiosException("HAY QUE LOGEARSE PRIMERO");
            //        string NombreUsuario = HttpContext.Session.GetString("nombre");
            //        vm.Ecosistema.Validate();
            //        CUAltaEcosistema.Alta(vm.Ecosistema, NombreUsuario);

            //        string nomArchivo = $"{vm.Ecosistema.Id}_001{ext}";
            //        vm.Ecosistema.ImagenEcosistema = nomArchivo;
            //        CUActualizarEcosistema.Actualizar(vm.Ecosistema);

            //        string dirRaiz = Path.Combine(WHE.WebRootPath, "img");
            //        string rutaCompleta = Path.Combine(dirRaiz, "ecosistemas", nomArchivo);

            //        FileStream fs = new FileStream(rutaCompleta, FileMode.Create);
            //        vm.ImagenEcosistema.CopyTo(fs);
            //        return RedirectToAction(nameof(Index));



            //    }
            //    else
            //    {
            //        vm.Paises = CUListadoPaises.Listado();
            //        vm.EstadosDeConservacion = CUObtenerEstadosDeConservacion.ObtenerEstadosDeConservacion();
            //        ViewBag.Mensaje = "El tipo de imagen debe ser png, jpeg o jpg";
            //        return View(vm);

            //    }



            //}
            //catch (DescripcionException ex)
            //{
            //    vm.Paises = CUListadoPaises.Listado();
            //    vm.EstadosDeConservacion = CUObtenerEstadosDeConservacion.ObtenerEstadosDeConservacion();
            //    ViewBag.Error = ex.Message;
            //    return View(vm);

            //}
            //catch (NombreException ex)
            //{
            //    vm.Paises = CUListadoPaises.Listado();
            //    vm.EstadosDeConservacion = CUObtenerEstadosDeConservacion.ObtenerEstadosDeConservacion();
            //    ViewBag.Error = ex.Message;
            //    return View(vm);

            //}
            //catch (EcosistemaException ex)
            //{
            //    vm.Paises = CUListadoPaises.Listado();
            //    vm.EstadosDeConservacion = CUObtenerEstadosDeConservacion.ObtenerEstadosDeConservacion();
            //    ViewBag.Error = ex.Message;
            //    return View(vm);

            //}
            //catch (CambiosException ex)
            //{
            //    vm.Paises = CUListadoPaises.Listado();
            //    vm.EstadosDeConservacion = CUObtenerEstadosDeConservacion.ObtenerEstadosDeConservacion();
            //    ViewBag.Error = ex.Message;
            //    return View(vm);

            //}
            //catch (Exception ex)
            //{
            //    vm.Paises = CUListadoPaises.Listado();
            //    vm.EstadosDeConservacion = CUObtenerEstadosDeConservacion.ObtenerEstadosDeConservacion();
            //    ViewBag.Error = "Ocurrió un problema al intentar el alta del Ecosistema";
            //    return View(vm);
            //}


        }







        //// GET: EcosistemasController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    //if (HttpContext.Session.GetString("nombre") == null)
        //    //{
        //    //    return View("NoAutorizado");
        //    //}

        //    var eco = new DTOEcosistema();
        //    //if (eco == null)
        //    //{
        //    //    ViewBag.Error = "El Ecosistema con el id " + id + " no existe";
        //    //}
        //    return View(eco);
        //}

        // POST: EcosistemasController/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(int id)
        {
            var ecosistemas = new List<DTOEcosistema>();
            return View("Index", ecosistemas);
            //try
            //{

            //    int cantidad = CUCantidadDeEspeciesEnEcosistema.CantidadDeEspecies(obj.Id);


            //    if (cantidad == 0)
            //    {

            //        if (HttpContext.Session.GetString("nombre") == null) throw new CambiosException("HAY QUE LOGEARSE PRIMERO");

            //        string NombreUsuario = HttpContext.Session.GetString("nombre");
            //        CUBajaEco.BorrarEcosistema(obj, NombreUsuario);
            //        return RedirectToAction(nameof(Index));

            //    }
            //    else
            //    {
            //        Ecosistema eco = CUBuscarEcosistemaPorId.BuscarEcoPorId(obj.Id);
            //        ViewBag.Error = "El ecosistema aún tiene especies habitandoló, pruebe nuevamente cuando la especie se haya extinto";

            //        return View(eco);
            //    }



            //}
            //catch (CambiosException ex)
            //{
            //    ViewBag.Error = ex.Message;
            //    return View(obj);
            //}
            //catch (EcosistemaException ex)
            //{
            //    ViewBag.Error = ex.Message;
            //    return View(obj);
            //}
            //catch (Exception ex)
            //{
            //    ViewBag.Error = "Ocurrió un error al intentar eliminar el ecosistema";
            //    return View(obj);
            //}
        }


        public ActionResult AsignarAmenazaAUnEcosistea(DTOAmenaza vm)
        {
            return View(vm);
            //if (HttpContext.Session.GetString("nombre") == null)
            //{
            //    return View("NoAutorizado");
            //}

            //try
            //{
            //    vm.amenazas = CUlistadoAmenazas.ListadoAmenaza();
            //    vm.IdsDeLasAmenazas = CUObtenerIdsDeAmenazasDelEcosistema.ObtenerIdsDeAmenazasDelEcosistema(vm.IdEcosistema);

            //    return View(vm);


            //}
            //catch (AmenazaException ex)
            //{
            //    vm.amenazas = new List<Amenaza>();
            //    vm.IdsDeLasAmenazas = new List<int>();
            //    ViewBag.error = ex.Message;
            //    return View(vm);
            //}
            //catch (EcosistemaException ex)
            //{
            //    vm.amenazas = new List<Amenaza>();
            //    vm.IdsDeLasAmenazas = new List<int>();
            //    ViewBag.error = ex.Message;
            //    return View(vm);
            //}
            //catch (Exception ex)
            //{
            //    vm.amenazas = new List<Amenaza>();
            //    vm.IdsDeLasAmenazas = new List<int>();
            //    ViewBag.error = "Ocurrió un error obteniendo las amenaza";
            //    return View(vm);


            //}


        }

       
        public ActionResult AsignarAmenazaAEcosistema(DTOAmenaza vm)
        {
            return View(vm);
            //try
            //{
            //    if (HttpContext.Session.GetString("nombre") == null) throw new CambiosException("HAY QUE LOGEARSE PRIMERO");

            //    string NombreUsuario = HttpContext.Session.GetString("nombre");
            //    CUAsignarAmenaza.AsignarAmenazaAUnEcosistema(vm.IdEcosistema, vm.IdAmenaza, NombreUsuario);


            //    return RedirectToAction("AsignarAmenazaAUnEcosistea", vm);

            //}
            //catch (CambiosException ex)
            //{
            //    vm.amenazas = CUlistadoAmenazas.ListadoAmenaza();

            //    vm.IdsDeLasAmenazas = CUObtenerIdsDeAmenazasDelEcosistema.ObtenerIdsDeAmenazasDelEcosistema(vm.IdEcosistema);

            //    ViewBag.Error = ex.Message;
            //    return View("AsignarAmenazaAUnEcosistea", vm);


            //}
            //catch (AmenazaException ex)
            //{
            //    vm.amenazas = CUlistadoAmenazas.ListadoAmenaza();

            //    vm.IdsDeLasAmenazas = CUObtenerIdsDeAmenazasDelEcosistema.ObtenerIdsDeAmenazasDelEcosistema(vm.IdEcosistema);

            //    ViewBag.Error = ex.Message;
            //    return View("AsignarAmenazaAUnEcosistea", vm);


            //}
            //catch (EcosistemaException ex)
            //{
            //    vm.amenazas = CUlistadoAmenazas.ListadoAmenaza();
            //    vm.IdsDeLasAmenazas = CUObtenerIdsDeAmenazasDelEcosistema.ObtenerIdsDeAmenazasDelEcosistema(vm.IdEcosistema);

            //    ViewBag.Error = ex.Message;
            //    return View("AsignarAmenazaAUnEcosistea", vm);


            //}
            //catch (Exception ex)
            //{
            //    vm.amenazas = CUlistadoAmenazas.ListadoAmenaza();
            //    vm.IdsDeLasAmenazas = CUObtenerIdsDeAmenazasDelEcosistema.ObtenerIdsDeAmenazasDelEcosistema(vm.IdEcosistema);

            //    ViewBag.Error = "Ocurrió un error al asignar la amenaza";
            //    return View("AsignarAmenazaAUnEcosistea", vm);


            //}



        }

        public ActionResult AmenazasDelEcosistema(DTOAmenaza vm)
        {
            return View(vm);

            //Ecosistema eco = CUBuscarEcosistemaPorId.BuscarEcoPorId(vm.IdEcosistema);


            //if (eco != null)
            //{
            //    IEnumerable<Amenaza> amenazaS = CUAmenazasDeUnEcosistema.AmenazasDeUnEcosistema(vm.IdEcosistema);

            //    if (amenazaS.Count() == 0) ViewBag.Error = "EL ECOSISTEMA NO SUFRE AMENAZAS POR EL MOMENTO";

            //    vm.amenazas = amenazaS;
            //    vm.Ecosistema = eco;




            //    return View(vm);

            //}
            //else
            //{
            //    ViewBag.Error = "NO SE ENCONTRÓ EL ECOSISTEMA";
            //    return View("Index");

            //}


        }

        public ActionResult Busqueda()
        {
            //if (TempData["MiTexto"] is string busqueda)
            //{
            //    IEnumerable<Ecosistema> ecosistemas = CUEcosistemasQueNoPuedeHabitarUnaEspecie.EcosistemasQueNoPuedeHabitarUnaEspecie(busqueda);
            //    if (ecosistemas.Count() == 0)
            //    {
            //        TempData["Error"] = "LA ESPECIE NO CONTIENE ECOSISTEMA QUE NO PUEDE HABITAR";
            //        return RedirectToAction("Index", "Especies");
            //    }
            //    else
            //    {
            //        return View(ecosistemas);
            //    }
            //}
            return View();
        }





    }
}
