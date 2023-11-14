//using ExcepcionesPropias;
//using LogicaAplicacion.CasosUso;
//using LogicaAplicacion.InterfacesCU;
//using LogicaNegocio;
//using LogicaNegocio.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
using MVC.Models;
using Newtonsoft.Json;

namespace MVC.Controllers
{
    public class EspeciesController : Controller
    {

       public IWebHostEnvironment WHE { get; set; }
       






        public EspeciesController(IWebHostEnvironment whe)
        {
            WHE = whe;
        }



        public ActionResult Index()
        {
            
            IEnumerable<EspecieDTO> especies = null;

            HttpClient cliente = new HttpClient();

            string url = "url del index de la api";

            var tarea1 = cliente.GetAsync(url);
            tarea1.Wait();

            var respuesta = tarea1.Result;

            var contenido = respuesta.Content;

            var tarea2 = contenido.ReadAsStringAsync();

            tarea2.Wait();

            string json = tarea2.Result;

            if (respuesta.IsSuccessStatusCode)
            {
                

                var paises = JsonConvert.DeserializeObject<List<EspecieDTO>>(json);

                return View(paises);
            }
            else
            {
                ViewBag.Error = json;
                return View();
            }
            return View(especies);
        }

        public ActionResult Details(EspecieViewModel vm)
        {
            vm.Especie = CUBuscarEspeciePorid.Buscar(vm.idEspecie);

            return View(vm);
        }

        // GET: EspeciesController/Create
        [HttpGet]
        public ActionResult Create()
        {
            if (HttpContext.Session.GetString("nombre") == null)
            {
                return View("NoAutorizado");
            }


            EspecieViewModel vm = new EspecieViewModel()
            {
                Especie = new Especie(),
                EstadosDeConservacion = CUObtenerEstadosDeConservacion.ObtenerEstadosDeConservacion()

            };


            return View(vm);
        }

        // POST: EspeciesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EspecieViewModel vm)
        {
           

            vm.Especie.habitats = new List<Habitat>();
            vm.Especie.Amenazas = new List<Amenaza>();

            try
            {
                EstadoConservacion estado = new EstadoConservacion() { Id = vm.idEstadoConservacion };
                vm.Especie.EstadoCons = estado;


                vm.Especie.NombreComun = new Nombre(vm.NombreComunEspecie);
                vm.Especie.Descripcion = new Descripcion(vm.DescripcionEspecie);


                FileInfo fi = new FileInfo(vm.ImagenEspecie.FileName);
                string ext = fi.Extension;

                if (ext == ".png" || ext == ".jpg" || ext == ".jpeg")
                {

                    vm.Especie.Validate();
                    vm.Especie.ImagenEspecie = "";
                    if (HttpContext.Session.GetString("nombre") == null) throw new CambiosException("HAY QUE LOGEARSE PRIMERO");

                    string NombreUsuario = HttpContext.Session.GetString("nombre");
                    CUAltaEsp.Add(vm.Especie, NombreUsuario);

                    string nomArchivo = $"{vm.Especie.Id}_001{ext}";
                    vm.Especie.ImagenEspecie = nomArchivo;
                    CUModificarEspecie.ModificarEspecie(vm.Especie);

                    string dirRaiz = Path.Combine(WHE.WebRootPath, "img");
                    string rutaCompleta = Path.Combine(dirRaiz, "especies", nomArchivo);

                    FileStream fs = new FileStream(rutaCompleta, FileMode.Create);

                    vm.ImagenEspecie.CopyTo(fs);




                    return RedirectToAction("Create", "Habitats", vm.Especie);


                }
                else
                {
                    vm.EstadosDeConservacion = CUObtenerEstadosDeConservacion.ObtenerEstadosDeConservacion();
                    ViewBag.Error = "El tipo de imagen debe ser png o jpg";
                    return View(vm);
                }


            }
            catch (NombreException ex)
            {
                vm.EstadosDeConservacion = CUObtenerEstadosDeConservacion.ObtenerEstadosDeConservacion();
                ViewBag.Error = ex.Message;

                return View(vm);
            }
            catch (DescripcionException ex)
            {
                vm.EstadosDeConservacion = CUObtenerEstadosDeConservacion.ObtenerEstadosDeConservacion();
                ViewBag.Error = ex.Message;

                return View(vm);
            }
            catch (CambiosException ex)
            {
                vm.EstadosDeConservacion = CUObtenerEstadosDeConservacion.ObtenerEstadosDeConservacion();
                ViewBag.Error = ex.Message;
                return View(vm);

            }
            catch (EspecieException ex)
            {
                vm.EstadosDeConservacion = CUObtenerEstadosDeConservacion.ObtenerEstadosDeConservacion();
                ViewBag.Error = ex.Message;
                return View(vm);

            }
            catch (Exception ex)
            {
                vm.EstadosDeConservacion = CUObtenerEstadosDeConservacion.ObtenerEstadosDeConservacion();
                ViewBag.Error = "Ocurrió un error realizando el alta de una especie";

                return View(vm);
            }

        }





        // GET: EspeciesController/Delete/5
        public ActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("nombre") == null)
            {
                return View("NoAutorizado");
            }

            Especie especie = CUBuscarEspeciePorid.Buscar(id);

            if (especie == null)
            {
                ViewBag.Error = "La especie con el id " + id + " no existe";
            }
            return View(especie);
        }

        // POST: EspeciesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Especie especie)
        {
            try
            {
                if (HttpContext.Session.GetString("nombre") == null) throw new CambiosException("HAY QUE LOGEARSE PRIMERO");

                string NombreUsuario = HttpContext.Session.GetString("nombre");
                CUBajaEspecie.BajaEspecie(especie, NombreUsuario);

                return RedirectToAction(nameof(Index));
            }
            catch (CambiosException ex)
            {
                Especie especiE = CUBuscarEspeciePorid.Buscar(especie.Id);
                ViewBag.Error = ex.Message;
                return View(especiE);
            }
            catch (EspecieException ex)
            {
                Especie especiE = CUBuscarEspeciePorid.Buscar(especie.Id);
                ViewBag.Error = ex.Message;
                return View(especiE);
            }
            catch (Exception ex)
            {
                Especie especiE = CUBuscarEspeciePorid.Buscar(especie.Id);

                ViewBag.Error = "Ocurrió un error al intentar eliminar la especie";
                return View(especiE);
            }
        }


        public ActionResult AsignarEcosistemas(HabitatViewModel vm)
        {
            if (HttpContext.Session.GetString("nombre") == null)
            {
                return View("NoAutorizado");
            }

            try
            {
                
                vm.Habitats = CUObtenerHabitatsDeLaEspecie.ObtenerHabitatsDeLaEspecie(vm.IdEspecie);

                if (vm.Habitats == null) throw new EspecieException("ocurrió un problema obteniendo los ecosistemas de esa especie");
                if (vm.Habitats.Count() == 0) throw new EspecieException("La especie no tiene ningun ecosistemas para poder habitar");



                return View(vm);
            }
            catch (EspecieException ex)
            {
                vm.Especies = CUListadoEspecie.Listado();
                ViewBag.Error = ex.Message;
                return View("Index", vm.Especies);


            }
            catch (Exception ex)
            {
                vm.Especies = CUListadoEspecie.Listado();
                ViewBag.Error = "Ocurrió un error obteniendo los ecosistema";
                return View("Index", vm.Especies);

            }

        }


   
        public ActionResult AsignarElEcosistema(HabitatViewModel vm)
        {

            try
            {

                Amenaza amenaza = CUAmenazaEnComun.AmenazaENComun(vm.IdEspecie, vm.IdEcosistema);


                if (amenaza == null)
                {


                    if(CUEstadosCompatibles.Compatibles(vm.IdEspecie, vm.IdEcosistema))
                    {
                        if (HttpContext.Session.GetString("nombre") == null) throw new CambiosException("HAY QUE LOGEARSE PRIMERO");

                        string NombreUsuario = HttpContext.Session.GetString("nombre");
                        CUAsignarUnEcosistema.AsignarUnEcosistema(vm.IdEspecie, vm.IdEcosistema, NombreUsuario);
                        return RedirectToAction("AsignarEcosistemas", vm);

                    }
                    else
                    {
                        vm.Habitats = CUObtenerHabitatsDeLaEspecie.ObtenerHabitatsDeLaEspecie(vm.IdEspecie);
                        ViewBag.Error = "El estado de conservacion del ecosistema es peor que él de la especie";
                        return View("AsignarEcosistemas", vm);

                    }


                }
                else
                {
                    vm.Habitats = CUObtenerHabitatsDeLaEspecie.ObtenerHabitatsDeLaEspecie(vm.IdEspecie);
                    ViewBag.Error = "El ecosistema sufre las mismas amenazas que la especie";
                    return View("AsignarEcosistemas", vm);
                }



            }
            catch (CambiosException ex)
            {
                vm.Habitats = CUObtenerHabitatsDeLaEspecie.ObtenerHabitatsDeLaEspecie(vm.IdEspecie);
                ViewBag.Error = ex.Message;
                return View("AsignarEcosistemas", vm);
            }
            catch (EspecieException ex)
            {
                vm.Habitats = CUObtenerHabitatsDeLaEspecie.ObtenerHabitatsDeLaEspecie(vm.IdEspecie);
                ViewBag.Error = ex.Message;
                return View("AsignarEcosistemas", vm);
            }
            catch (Exception ex)
            {

                vm.Habitats = CUObtenerHabitatsDeLaEspecie.ObtenerHabitatsDeLaEspecie(vm.IdEspecie);
                ViewBag.Error = "Ocurrió un error al asignar el ecosistema";
                return View("AsignarEcosistemas", vm);

            }

        }



        public ActionResult AsignarAmenazaAUnaEspecie(AmenazaViewModel vm)
        {

            if (HttpContext.Session.GetString("nombre") == null)
            {
                return View("NoAutorizado");
            }

            try
            {
                vm.amenazas = CUlistadoAmenazas.ListadoAmenaza();
                vm.IdsDeLasAmenazas =  CUObtenerIdsDeAmenazasDeEspecies.ObtenerIdsDeAmenazasDeEspecies(vm.IdEspecie);

                return View(vm);


            }
            catch (AmenazaException ex)
            {
                vm.amenazas = new List<Amenaza>();
                vm.IdsDeLasAmenazas = new List<int>();
                ViewBag.error = ex.Message;
                return View(vm);
            }
            catch (EspecieException ex)
            {
                vm.amenazas = new List<Amenaza>();
                vm.IdsDeLasAmenazas = new List<int>();
                ViewBag.error = ex.Message;
                return View(vm);
            }
            catch (Exception ex)
            {
                vm.amenazas = new List<Amenaza>();
                vm.IdsDeLasAmenazas =  new List<int>();
                ViewBag.error = "Ocurrió un error obteniendo las amenaza";
                return View(vm);
            }



        }

       
        public ActionResult AsignarAmenaza(AmenazaViewModel vm)
        {
            try
            {
                if (HttpContext.Session.GetString("nombre") == null) throw new CambiosException("HAY QUE LOGEARSE PRIMERO");

                string NombreUsuario = HttpContext.Session.GetString("nombre");
                CUAsignarAmenaza.AsignarLaAmenaza(vm.IdEspecie, vm.IdAmenaza, NombreUsuario);


                return RedirectToAction("AsignarAmenazaAUnaEspecie", vm);

            }
            catch (CambiosException ex)
            {
                vm.amenazas = CUlistadoAmenazas.ListadoAmenaza();
                vm.IdsDeLasAmenazas = CUObtenerIdsDeAmenazasDeEspecies.ObtenerIdsDeAmenazasDeEspecies(vm.IdEspecie);

                ViewBag.Error = ex.Message;
                return View("AsignarAmenazaAUnaEspecie", vm);


            }
            catch (AmenazaException ex)
            {
                vm.amenazas = CUlistadoAmenazas.ListadoAmenaza();
                vm.IdsDeLasAmenazas = CUObtenerIdsDeAmenazasDeEspecies.ObtenerIdsDeAmenazasDeEspecies(vm.IdEspecie);

                ViewBag.Error = ex.Message;
                return View("AsignarAmenazaAUnaEspecie", vm);


            }
            catch (EspecieException ex)  
            {
                vm.amenazas = CUlistadoAmenazas.ListadoAmenaza();
                vm.IdsDeLasAmenazas = CUObtenerIdsDeAmenazasDeEspecies.ObtenerIdsDeAmenazasDeEspecies(vm.IdEspecie);

                ViewBag.Error = ex.Message;
                return View("AsignarAmenazaAUnaEspecie", vm);


            }
            catch (Exception ex) 
            {
                vm.amenazas = CUlistadoAmenazas.ListadoAmenaza();
                vm.IdsDeLasAmenazas = CUObtenerIdsDeAmenazasDeEspecies.ObtenerIdsDeAmenazasDeEspecies(vm.IdEspecie);

                ViewBag.Error = "Ocurrió un error al asignar la amenaza";
                return View("AsignarAmenazaAUnaEspecie", vm);


            }



        }

        public ActionResult AmenazasDeLaEspecie(AmenazaViewModel vm)
        {

            Especie especie = CUBuscarEspeciePorid.Buscar(vm.IdEspecie);

            if(especie != null) 
            {
                IEnumerable<Amenaza> amenazaS = CUAmenazasDeUnaEspecie.AmenazasDeLaEspecie(vm.IdEspecie);
                if (amenazaS.Count() == 0) ViewBag.Error = "LA ESPECIE NO SUFRE AMENAZAS POR EL MOMENTO";
                vm.amenazas = amenazaS;
                vm.Especie = especie;
                return View(vm);

            }
            else
            {
                ViewBag.Error = "NO SE ENCONTRÓ LA ESPECIE";
                return View("Index");
            }


        
        
        }

        ////////////////////////////////////////
        




        [HttpPost]
         public ActionResult Buscador(int filtro, string busqueda)
        {
            try
            {
                IEnumerable<Especie> especies = CUListadoEspecie.Listado();
                switch (filtro)
                {
                    
                    case 0:

                        return RedirectToAction("Index");

                        break;

                    case 1:
                        //POR NOMBRE CIENTÍFICO

                        if (busqueda == null || busqueda == "" || busqueda == " ")
                        {
                            IEnumerable<Especie> especiesPorNombre = CUEspeciesOrdenadasPorNombreCientifico.EspeciesORdenadasPorNombreCientifico();

                            return View("Index", especiesPorNombre);
                        }
                        else
                        {

                            Especie ESpECIE = CUObtenerEspeciePorNombreCientifico.IObtenerEspeciePorNombreCientifico(busqueda);

                            if (ESpECIE == null) ViewBag.Error = "NO HAY UNA ESPECIE CON EL NOMBRE " + busqueda;
                            IEnumerable<Especie> eSpecies = CUListadoEspecie.Listado();
                            return View("Index", eSpecies);
                        }


                        break;


                    case 2:
                        //ESPECIES EN PELIGRO DE EXTINCIÓN

                        IEnumerable<Especie> especiesEnPeligroExtincion = CUEspeciesEnPeligroDeExtincion.EspeciesENPeligroDeExtincion();
                        if (especiesEnPeligroExtincion.Count() == 0) throw new EspecieException("POR EL MOMENTO NO HAY ESPECIES EN PELIGRO DE EXTINCIÓN");
                        return View("Index", especiesEnPeligroExtincion);


                        break;

                    case 3:
                        //ESPECIES POR RANGO DE PESO
                        
                        if (busqueda.IsNullOrEmpty()) throw new EspecieException("EL RANGO INGRESADO NO PUEDE ESTAR VACÍO");
                       
                        string[] pesos = busqueda.Split("-");
                        if (pesos.Length == 1) throw new EspecieException("EL RANGO INGRESADO DEBE ESTAR SEPARADO CON -");

                        string pesoMin = pesos[0];
                        string pesoMax = pesos[1];

                        int PesoMinimo;
                        int PesoMaximo;

                        if (!int.TryParse(pesoMin, out PesoMinimo)) throw new EspecieException("DEBES INGRESAR VALORES NUMÉRICOS POSITIVOS");
                        if(!int.TryParse(pesoMax, out PesoMaximo)) throw new EspecieException("DEBES INGRESAR VALORES NUMÉRICOS POSITIVOS");

                        if (PesoMaximo == 0) throw new EspecieException("EL VALOR INGRESADO COMO PESO MÁXIMO NO PUEDE SER 0.");
                        if (PesoMaximo <= PesoMinimo) throw new EspecieException("EL PESO MÁXIMO DEBE SER MAYOR AL PESO MÍNIMO");
                        if (PesoMaximo < 0 || PesoMinimo < 0) throw new EspecieException("LOS VALORES NUMÉRICOS DEBEN SER POSITÍVOS");


                        IEnumerable<Especie> especiesPorRangoDePeso = CUBuscarEspeciesPorRangoDePeso.BuscarEspeciesPorRangoDePeso(PesoMinimo, PesoMaximo);
                        return View("Index", especiesPorRangoDePeso);


                        break;

                    case 4:
                        //POR ECOSISTEMA

                        if (string.IsNullOrEmpty(busqueda)) throw new EspecieException("DEBE INGRESAR UN ECOSISTEMA");

                        Ecosistema eco = CUBuscarEcosistemaPorNombre.BuscarEcosistemaPorNombre(busqueda);

                        if (eco == null) throw new EspecieException("NO EXISTE UN ECOSISTEMA CON EL NOMBRE "+ busqueda);

                        IEnumerable <Especie> ESpecies = CUEspeciesFiltradasPorEcosistema.EspeciesFIltradasPorEcosistema(busqueda);

                        if (ESpecies == null || ESpecies.Count() == 0)
                        {
                            ViewBag.Error = "EL ECOSISTEMA NO TIENE ESPECIES HABITÁNDOLO";
                            
                            return View("Index", especies);

                        }
                        else
                        {
                            return View("Index", ESpecies);
                        }
                        break;

                    case 5:

                        //Ecosistemas en los que no puede habitar una especie

                        if (string.IsNullOrEmpty(busqueda)) throw new EspecieException("DEBE INGRESAR EL NOMBRE CIENTÍFICO DE LA ESPECIE");

                        Especie especie = CUObtenerEspeciePorNombreCientifico.IObtenerEspeciePorNombreCientifico(busqueda);

                        if (especie == null) throw new EspecieException("NO SE ENCONTRÓ UNA ESPECIE CON ESE NOMBRE CIENTÍFICO");

                        TempData["MiTexto"] = busqueda;
                                  

                        return RedirectToAction("Busqueda", "Ecosistemas");

                                break;
                    default:

                        return View();
                        break;
                }




            }
            catch(EspecieException ex)
            {
                IEnumerable<Especie> especies = CUListadoEspecie.Listado();
                ViewBag.Error = ex.Message;
                return View("Index", especies);
            }
            catch(Exception ex)
            {
                IEnumerable<Especie> especies = CUListadoEspecie.Listado();
                ViewBag.Error = ex.Message;
                return View("Index", especies);
            }

         }






    }
}

