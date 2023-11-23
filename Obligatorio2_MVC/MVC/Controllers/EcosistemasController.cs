using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.DTOs;
using Newtonsoft.Json;
using ExcepcionesPropias;
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
        public IWebHostEnvironment WHE { get; set; }



        public EcosistemasController(IWebHostEnvironment whe)
        {
            WHE = whe;
        }


        [HttpGet]
        public ActionResult Index()
        {

            IEnumerable<EcosistemaDTO> ecosistemas = null;

            IEnumerable<EstadoConservacionDTO> estados = null;
            HttpClient cliente = new HttpClient();

            string url = "http://localhost:5285/api/ecosistemas";

            var tarea1 = cliente.GetAsync(url);
            tarea1.Wait();

            var respuesta = tarea1.Result;

            var contenido = respuesta.Content;

            var tarea2 = contenido.ReadAsStringAsync();

            tarea2.Wait();

            string json = tarea2.Result;

            string url2 = "http://localhost:5285/api/estadosconservacion";

            var tarea3 = cliente.GetAsync(url);
            tarea3.Wait();

            var respuesta2 = tarea3.Result;

            var contenido2 = respuesta2.Content;

            var tarea4 = contenido2.ReadAsStringAsync();

            tarea4.Wait();

            string json2 = tarea4.Result;

            if (respuesta.IsSuccessStatusCode && respuesta2.IsSuccessStatusCode)
            {

                estados = JsonConvert.DeserializeObject<List<EstadoConservacionDTO>>(json2);
                ecosistemas = JsonConvert.DeserializeObject<List<EcosistemaDTO>>(json);
                var vms = ecosistemas.Select(e => new EcosistemaViewModel()
                {
                    Ecosistema = new EcosistemaDTO()
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
            EcosistemaDTO ecosistema = new EcosistemaDTO();

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


                ecosistema = JsonConvert.DeserializeObject<EcosistemaDTO>(json);

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
            if (HttpContext.Session.GetString("rol") == "Usuario" || HttpContext.Session.GetString("rol") == "Admin")
            {

                var vm = new EcosistemaViewModel();
                vm.Paises = null;
                vm.EstadosDeConservacion = null;

                HttpClient cliente = new HttpClient();

                string url = $"http://localhost:5285/api/Paises";

                var tarea1 = cliente.GetAsync(url);
                tarea1.Wait();

                var respuesta = tarea1.Result;

                var contenido = respuesta.Content;

                var tarea2 = contenido.ReadAsStringAsync();

                tarea2.Wait();

                string json = tarea2.Result;

                string url2 = $"http://localhost:5285/api/estadosconservacion";

                var tarea3 = cliente.GetAsync(url2);
                tarea3.Wait();

                var respuesta2 = tarea3.Result;

                var contenido2 = respuesta2.Content;

                var tarea4 = contenido2.ReadAsStringAsync();

                tarea4.Wait();

                string json2 = tarea4.Result;



                if (respuesta.IsSuccessStatusCode && respuesta2.IsSuccessStatusCode)
                {

                    vm.Paises = JsonConvert.DeserializeObject<List<PaisDTO>>(json);
                    vm.EstadosDeConservacion = JsonConvert.DeserializeObject<List<EstadoConservacionDTO>>(json2);


                    return View(vm);
                }
                else
                {
                    ViewBag.Error = json;
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Login", "Usuarios");
            }
        }

        // POST: EcosistemasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EcosistemaViewModel vm)
        {
            if (HttpContext.Session.GetString("rol") == "Usuario" || HttpContext.Session.GetString("rol") == "Admin")
            {
                try
                {

                    FileInfo fi = new FileInfo(vm.ImagenEcosistema.FileName);
                    string ext = fi.Extension;

                    if (ext == ".png" || ext == ".jpg" || ext == ".jpeg")
                    {
                        HttpClient cliente = new HttpClient();
                        string url = "http://localhost:5285/api/ecosistemas";
                        string token = HttpContext.Session.GetString("token");
                        cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                        vm.Ecosistema.IdPaisSeleccionado = vm.IdPaisSeleccionado;
                        vm.Ecosistema.IdEstadoConservacion = vm.IdEstadoConservacion;
                        vm.Ecosistema.NombreImagenEcosistema = vm.ImagenEcosistema.FileName;
                        vm.Ecosistema.NombreUsuario = HttpContext.Session.GetString("nombre");
                        vm.Ecosistema.Amenazas = Enumerable.Empty<AmenazaDTO>();

                        Task<HttpResponseMessage> tarea1 = cliente.PostAsJsonAsync(url, vm.Ecosistema);
                        tarea1.Wait();

                        HttpResponseMessage respuesta = tarea1.Result;

                        if (respuesta.IsSuccessStatusCode)
                        {
                            //OBTENGO EL ID GENERADO
                            HttpContent contenido = respuesta.Content;
                            Task<string> tarea2 = contenido.ReadAsStringAsync();
                            tarea2.Wait();

                            string body = tarea2.Result;

                            EcosistemaDTO creado = JsonConvert.DeserializeObject<EcosistemaDTO>(body);
                            int id_generada = creado.Id;

                            //GUARDO LA IMAGEN LOCALMENTE
                            string nomImagen = $"{id_generada}_001{ext}"; ;

                            string dirRaiz = WHE.WebRootPath;
                            string rutaCompleta = Path.Combine(dirRaiz, "img\\ecosistemas", nomImagen);

                            FileStream fs = new FileStream(rutaCompleta, FileMode.Create);
                            vm.ImagenEcosistema.CopyTo(fs);
                            fs.Flush();
                            fs.Close();

                            //ACTUALIZO EL NOMBRE DE IMAGEN DEL ECOSISTEMA DADO DE ALTA
                            creado.NombreImagenEcosistema = nomImagen;
                            url = url + "/" + id_generada;
                            Task<HttpResponseMessage> tarea3 = cliente.PutAsJsonAsync(url, creado);
                            tarea3.Wait();

                            if (tarea3.Result.IsSuccessStatusCode)
                            {
                                return RedirectToAction(nameof(Index));
                            }
                            else
                            {
                                HttpContent contenido2 = tarea3.Result.Content;
                                Task<string> tarea4 = contenido2.ReadAsStringAsync();
                                tarea4.Wait();

                                string error2 = tarea4.Result;
                                ViewBag.Error = error2;
                            }
                        }
                        else
                        {
                            HttpContent contenido3 = tarea1.Result.Content;
                            Task<string> tarea5 = contenido3.ReadAsStringAsync();
                            tarea5.Wait();

                            string error = tarea5.Result;
                            ViewBag.Error = error;
                            return View(vm);
                        }
                    }
                    else
                    {
                        ViewBag.Error = "El tipo de imagen debe ser png, jpeg o jpg";
                        return View(vm);
                    }
                }
                catch (Exception)
                {
                    ViewBag.Error = "Ocurrió un error inesperado, no se realizó el alta";
                }

                return View(vm);
            }
            else
            {
                return RedirectToAction("Login", "Usuarios");
            }
        }








        // DELETE: EcosistemasController/Delete/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Borrar(int id)
        {
            if (HttpContext.Session.GetString("rol") == "Usuario" || HttpContext.Session.GetString("rol") == "Admin")
            {

                HttpClient cliente = new HttpClient();

                string url = $"http://localhost:5285/api/ecosistemas/{id}";
                string token = HttpContext.Session.GetString("token");
                string rol = HttpContext.Session.GetString("rol");
                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", rol);
                var respuesta = cliente.DeleteAsync(url);
                respuesta.Wait();

                if (respuesta.Result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "No se puedo borrar el ecosistema.";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Login", "Usuarios");
            }

        }


        public ActionResult AsignarAmenazaAUnEcosistea(AmenazaDTO vm)
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


        public ActionResult AsignarAmenazaAEcosistema(AmenazaDTO vm)
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

        public ActionResult AmenazasDelEcosistema(AmenazaDTO vm)
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
