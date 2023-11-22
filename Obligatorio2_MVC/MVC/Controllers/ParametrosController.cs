using Microsoft.AspNetCore.Mvc;
//using LogicaAplicacion.CasosUso;
//using LogicaAplicacion.InterfacesCU;
using ExcepcionesPropias;
using MVC.DTOs;
using Newtonsoft.Json;
using MVC.Models;
using System.Net.Http.Headers;

namespace MVC.Controllers
{
    public class ParametrosController : Controller
    {

        public ParametrosController() { }







        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("nombre") == null || HttpContext.Session.GetString("rol") != "Admin")
            {
                return View("NoAutorizado");
            }

            IEnumerable<ParametroDTO> parametros = null;

            HttpClient cliente = new HttpClient();

            string url = "http://localhost:5285/api/parametros";

            var tarea1 = cliente.GetAsync(url);
            tarea1.Wait();

            var respuesta = tarea1.Result;

            var contenido = respuesta.Content;

            var tarea2 = contenido.ReadAsStringAsync();

            tarea2.Wait();

            string json = tarea2.Result;

            if (respuesta.IsSuccessStatusCode)
            {

                parametros = JsonConvert.DeserializeObject<List<ParametroDTO>>(json);
                return View(parametros);
            }
            else
            {
                ViewBag.Error = json;
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            HttpClient cliente = new HttpClient();

            string url = $"http://localhost:5285/api/parametros/{id}";

            var tarea1 = cliente.GetAsync(url);
            tarea1.Wait();

            var respuesta = tarea1.Result;

            var contenido = respuesta.Content;

            var tarea2 = contenido.ReadAsStringAsync();

            tarea2.Wait();

            string json = tarea2.Result;

            if (respuesta.IsSuccessStatusCode)
            {


                var parametro = JsonConvert.DeserializeObject<ParametroDTO>(json);

                return View(parametro);
            }
            else
            {
                ViewBag.Error = json;
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(ParametroDTO parametro)
        {
            if (HttpContext.Session.GetString("rol") == "Usuario" || HttpContext.Session.GetString("rol") == "Admin")
            {
                try
                {

                    HttpClient cliente = new HttpClient();
                    string url = $"http://localhost:5285/api/parametros/{parametro.Id}";
                    string token = HttpContext.Session.GetString("token");
                    cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    Task<HttpResponseMessage> tarea1 = cliente.PutAsJsonAsync(url, parametro);
                    tarea1.Wait();

                    HttpResponseMessage respuesta = tarea1.Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));

                    }
                    else
                    {
                        HttpContent contenido = tarea1.Result.Content;
                        Task<string> tarea2 = contenido.ReadAsStringAsync();
                        tarea2.Wait();

                        string error = tarea2.Result;
                        ViewBag.Error = error;
                    }
                }
                catch (Exception)
                {
                    ViewBag.Error = "Ocurrió un error inesperado, no se realizó el alta";
                }

                return View(parametro);
            }
            else
            {
                return RedirectToAction("Login", "Usuarios");
            }
        }


            public ActionResult ModificarElParametro(int value, string valorNuevo)
            {

                return View("ModificarParametros");
                //try
                //{
                //    switch (value)
                //    {
                //        case 0:

                //            ViewBag.Error = "ELIGE UNA OPCIÓN";
                //            return View("ModificarParametros");
                //            break;

                //        case 1:

                //            // LARGO MAXIMO DE LAS DESCRIPCIONES
                //            int valorParseado;
                //            int ValorParametRO;

                //            if (int.TryParse(valorNuevo, out valorParseado))
                //            {
                //                if (valorParseado < 0) throw new ParametrosException("Debes ingresar un numero positivo");

                //                string valorParametro = CUBuscarValorParametroPorNombre.BuscarValorParametroPorNombre("MinLargoDescripcion");

                //                if (int.TryParse(valorParametro, out ValorParametRO))
                //                {
                //                    if (valorParseado < ValorParametRO) throw new ParametrosException("El largo máximo ingresado no puede ser menor a " + CUBuscarValorParametroPorNombre.BuscarValorParametroPorNombre("MinLargoDescripcion"));


                //                }


                //                if (HttpContext.Session.GetString("nombre") == null) throw new CambiosException("HAY QUE LOGEARSE PRIMERO");

                //                string NombreUsuario = HttpContext.Session.GetString("nombre");
                //                CUModificarMaxLargoDescripcion.Modificar("MaxLargoDescripcion", valorParseado.ToString(), NombreUsuario);
                //                CUVOModificarMaxLargoDescripcion.Modificar(valorParseado);
                //                ///////////////////////////////



                //                ViewBag.Exito = "Parametro actualizado con éxito";
                //                return View("ModificarParametros");

                //            }
                //            else
                //            {
                //                ViewBag.Error = "Debes ingresar un numero";
                //                return View("ModificarParametros");

                //            }

                //            break;


                //        case 2:
                //            //LARGO MÍNIMO DE LAS DESCRIPCIONES
                //            int valorParseadO;
                //            int ValorParamETRO;

                //            if (int.TryParse(valorNuevo, out valorParseadO))
                //            {
                //                if (valorParseadO < 0) throw new ParametrosException("Debes ingresar un numero positivo");

                //                string valorParametro = CUBuscarValorParametroPorNombre.BuscarValorParametroPorNombre("MaxLargoDescripcion");

                //                if (int.TryParse(valorParametro, out ValorParamETRO))
                //                {
                //                    if (valorParseadO < ValorParamETRO) throw new ParametrosException("El largo máximo ingresado no puede ser menor a " + CUBuscarValorParametroPorNombre.BuscarValorParametroPorNombre("MaxLargoDescripcion"));


                //                }
                //                if (HttpContext.Session.GetString("nombre") == null) throw new CambiosException("HAY QUE LOGEARSE PRIMERO");

                //                string NombreUsuario = HttpContext.Session.GetString("nombre");
                //                CUModificarMinLargoDescripcion.Modificar("MinLargoDescripcion", valorParseadO.ToString(), NombreUsuario);
                //                CUVOModificarMinLargoDescripcion.Modificar(valorParseadO);

                //                ///////////////////////////////


                //                ViewBag.Exito = "Parametro actualizado con éxito";
                //                return View("ModificarParametros");

                //            }
                //            else
                //            {
                //                ViewBag.Error ="Debes ingresar un numero";
                //                return View("ModificarParametros");

                //            }

                //            break;

                //        case 3:
                //            //LARGO MAXIMO DE LOS NOMBRES

                //            int ValorParseadO;
                //            int ValorParametro;

                //            if (int.TryParse(valorNuevo, out ValorParseadO))
                //            {
                //                if (ValorParseadO < 0) throw new ParametroException("DEBES INGRESAR UN NUMERO POSITIVO");

                //                string valorParametro = CUBuscarParametroPorNombre.BuscarParametroPorNombre("MinLargoNombre");

                //                if(int.TryParse(valorParametro, out ValorParametro))
                //                {
                //                    if(ValorParseadO < ValorParametro) throw new ParametrosException("El largo máximo ingresado no puede ser menor a " + CUBuscarValorParametroPorNombre.BuscarValorParametroPorNombre("MinLargoNombre"));


                //                }

                //                if (HttpContext.Session.GetString("nombre") == null) throw new CambiosException("HAY QUE LOGEARSE PRIMERO");

                //                string NombreUsuario = HttpContext.Session.GetString("nombre");
                //                CUModificarMaxLargoNombre.Modificar("MaxLargoNombre", ValorParseadO.ToString(), NombreUsuario);
                //                CUVOModificarMaxLargoNombre.Modificar(ValorParseadO);



                //                ///////////////////////////////





                //                ViewBag.Exito = "Parametro actualizado con éxito";
                //                return View("ModificarParametros");

                //            }
                //            else
                //            {
                //                ViewBag.Error = "Debes ingresar un numero";
                //                return View("ModificarParametros");

                //            }

                //            break;

                //        case 4:
                //            //LARGO MÍNIMO DE LOS NOMBRES

                //            int ValorPArseadO;
                //            int ValorPArametro;


                //            if (int.TryParse(valorNuevo, out ValorPArseadO))
                //            {

                //                if (ValorPArseadO < 0) throw new ParametrosException("DEBES INGRESAR UN NUMERO POSITIVO");

                //                string valorParametRo = CUBuscarValorParametroPorNombre.BuscarValorParametroPorNombre("MinLargoNombre");

                //                if (int.TryParse(valorParametRo, out ValorPArametro))
                //                {
                //                    if (ValorPArseadO > ValorPArametro) throw new ParametrosException("El largo mínimo ingresado no puede ser mayor a " + CUBuscarValorParametroPorNombre.BuscarValorParametroPorNombre("MaxLargoNombre"));


                //                }

                //                if (HttpContext.Session.GetString("nombre") == null) throw new CambiosException("HAY QUE LOGEARSE PRIMERO");


                //                string NombreUsuario = HttpContext.Session.GetString("nombre");
                //                CUModificarMinLargoNombre.Modificar("MINLargoNombre", ValorPArseadO.ToString(), NombreUsuario);
                //                CUVOModificarMinLargoNombre.Modificar(ValorPArseadO);
                //                ///////////////////////////////




                //                ViewBag.Exito = "Parametro actualizado con éxito";
                //                return View("ModificarParametros");

                //            }
                //            else
                //            {
                //                ViewBag.Error = "Debes ingresar un numero";
                //                return View("ModificarParametros");

                //            }

                //        default:
                //            break;

                //    }



                //}
                //catch (CambiosException ex)
                //{

                //    ViewBag.Error = ex.Message;
                //    return View("ModificarParametros");




                //}
                //catch (ParametrosException ex)
                //{

                //    ViewBag.Error = ex.Message;
                //    return View("ModificarParametros");




                //}
                //catch (Exception ex)
                //{

                //    ViewBag.Error = "No se pudo modificar el tope del largo";
                //    return View("ModificarParametros");




                //}

            }
        }
    }

