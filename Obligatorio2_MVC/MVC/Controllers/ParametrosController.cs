using Microsoft.AspNetCore.Mvc;
using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.ValueObjects;
using ExcepcionesPropias;
namespace MVC.Controllers
{
    public class ParametrosController : Controller
    {
        public IModificarMinLargoDescripcion CUModificarMinLargoDescripcion { get; set; }
        public IModificarMaxLargoDescripcion CUModificarMaxLargoDescripcion { get; set; }

        public IModificarMinLargoNombre CUModificarMinLargoNombre { get; set; }
        public IModificarMaxLargoNombre CUModificarMaxLargoNombre { get; set; }

        public IBuscarValorParametroPorNombre CUBuscarValorParametroPorNombre { get; set; }

        public IVOModificarMaxLargoNombre CUVOModificarMaxLargoNombre { get; set; }
        public IVOModificarMinLargoNombre CUVOModificarMinLargoNombre { get; set; }
        public IVOModificarMaxLargoDescripcion CUVOModificarMaxLargoDescripcion { get; set; }
        public IVOModificarMinLargoDescripcion CUVOModificarMinLargoDescripcion { get; set; }



        public ParametrosController(IModificarMinLargoDescripcion cuModificarMinLargoDescripcion, IModificarMaxLargoDescripcion
                                        cuModificarMaxLargoDescripcion, IBuscarValorParametroPorNombre cuBuscarValorParametroPorNombre,
                                        IModificarMinLargoNombre cuModificarMinLargoNombre, IModificarMaxLargoNombre cuModificarMaxLargoNombre
                                        ,IVOModificarMaxLargoNombre cuVOModificarMaxLargoNombre, IVOModificarMinLargoNombre cuVOModificarMinLargoNombre,
                                         IVOModificarMaxLargoDescripcion cuVOModificarMaxLargoDescripcion,
                                        IVOModificarMinLargoDescripcion cuVOModificarMinLargoDescripcion)
        {

            CUModificarMinLargoDescripcion = cuModificarMinLargoDescripcion;
            CUModificarMaxLargoDescripcion = cuModificarMaxLargoDescripcion;
            CUBuscarValorParametroPorNombre = cuBuscarValorParametroPorNombre;
            CUModificarMinLargoNombre = cuModificarMinLargoNombre;
            CUModificarMaxLargoNombre = cuModificarMaxLargoNombre;
            CUVOModificarMaxLargoNombre = cuVOModificarMaxLargoNombre;
            CUVOModificarMinLargoNombre = cuVOModificarMinLargoNombre;
            CUVOModificarMaxLargoDescripcion = cuVOModificarMaxLargoDescripcion;
            CUVOModificarMinLargoDescripcion = cuVOModificarMinLargoDescripcion;
        }







        public IActionResult ModificarParametros()
        {
            if (HttpContext.Session.GetString("nombre") == null || HttpContext.Session.GetString("rol") != "Admin")
            {
                return View("NoAutorizado");
            }

            return View();
        }

        public IActionResult ModificarElParametro(int value, string valorNuevo)
        {
           

            try
            {
                switch (value)
                {
                    case 0:

                        ViewBag.Error = "ELIGE UNA OPCIÓN";
                        return View("ModificarParametros");
                        break;

                    case 1:

                        // LARGO MAXIMO DE LAS DESCRIPCIONES
                        int valorParseado;
                        int ValorParametRO;

                        if (int.TryParse(valorNuevo, out valorParseado))
                        {
                            if (valorParseado < 0) throw new ParametrosException("Debes ingresar un numero positivo");

                            string valorParametro = CUBuscarValorParametroPorNombre.BuscarValorParametroPorNombre("MinLargoDescripcion");

                            if (int.TryParse(valorParametro, out ValorParametRO))
                            {
                                if (valorParseado < ValorParametRO) throw new ParametrosException("El largo máximo ingresado no puede ser menor a " + CUBuscarValorParametroPorNombre.BuscarValorParametroPorNombre("MinLargoDescripcion"));


                            }


                            if (HttpContext.Session.GetString("nombre") == null) throw new CambiosException("HAY QUE LOGEARSE PRIMERO");

                            string NombreUsuario = HttpContext.Session.GetString("nombre");
                            CUModificarMaxLargoDescripcion.Modificar("MaxLargoDescripcion", valorParseado.ToString(), NombreUsuario);
                            CUVOModificarMaxLargoDescripcion.Modificar(valorParseado);
                            ///////////////////////////////



                            ViewBag.Exito = "Parametro actualizado con éxito";
                            return View("ModificarParametros");

                        }
                        else
                        {
                            ViewBag.Error = "Debes ingresar un numero";
                            return View("ModificarParametros");

                        }

                        break;


                    case 2:
                        //LARGO MÍNIMO DE LAS DESCRIPCIONES
                        int valorParseadO;
                        int ValorParamETRO;

                        if (int.TryParse(valorNuevo, out valorParseadO))
                        {
                            if (valorParseadO < 0) throw new ParametrosException("Debes ingresar un numero positivo");

                            string valorParametro = CUBuscarValorParametroPorNombre.BuscarValorParametroPorNombre("MaxLargoDescripcion");

                            if (int.TryParse(valorParametro, out ValorParamETRO))
                            {
                                if (valorParseadO < ValorParamETRO) throw new ParametrosException("El largo máximo ingresado no puede ser menor a " + CUBuscarValorParametroPorNombre.BuscarValorParametroPorNombre("MaxLargoDescripcion"));


                            }
                            if (HttpContext.Session.GetString("nombre") == null) throw new CambiosException("HAY QUE LOGEARSE PRIMERO");

                            string NombreUsuario = HttpContext.Session.GetString("nombre");
                            CUModificarMinLargoDescripcion.Modificar("MinLargoDescripcion", valorParseadO.ToString(), NombreUsuario);
                            CUVOModificarMinLargoDescripcion.Modificar(valorParseadO);
                            
                            ///////////////////////////////
                            
                            
                            ViewBag.Exito = "Parametro actualizado con éxito";
                            return View("ModificarParametros");

                        }
                        else
                        {
                            ViewBag.Error ="Debes ingresar un numero";
                            return View("ModificarParametros");

                        }

                        break;

                    case 3:
                        //LARGO MAXIMO DE LOS NOMBRES
                        
                        int ValorParseadO;
                        int ValorParametro;

                        if (int.TryParse(valorNuevo, out ValorParseadO))
                        {
                            if (ValorParseadO < 0) throw new ParametroException("DEBES INGRESAR UN NUMERO POSITIVO");

                            string valorParametro = CUBuscarParametroPorNombre.BuscarParametroPorNombre("MinLargoNombre");

                            if(int.TryParse(valorParametro, out ValorParametro))
                            {
                                if(ValorParseadO < ValorParametro) throw new ParametrosException("El largo máximo ingresado no puede ser menor a " + CUBuscarValorParametroPorNombre.BuscarValorParametroPorNombre("MinLargoNombre"));


                            }

                            if (HttpContext.Session.GetString("nombre") == null) throw new CambiosException("HAY QUE LOGEARSE PRIMERO");

                            string NombreUsuario = HttpContext.Session.GetString("nombre");
                            CUModificarMaxLargoNombre.Modificar("MaxLargoNombre", ValorParseadO.ToString(), NombreUsuario);
                            CUVOModificarMaxLargoNombre.Modificar(ValorParseadO);



                            ///////////////////////////////





                            ViewBag.Exito = "Parametro actualizado con éxito";
                            return View("ModificarParametros");

                        }
                        else
                        {
                            ViewBag.Error = "Debes ingresar un numero";
                            return View("ModificarParametros");

                        }

                        break;

                    case 4:
                        //LARGO MÍNIMO DE LOS NOMBRES

                        int ValorPArseadO;
                        int ValorPArametro;


                        if (int.TryParse(valorNuevo, out ValorPArseadO))
                        {

                            if (ValorPArseadO < 0) throw new ParametrosException("DEBES INGRESAR UN NUMERO POSITIVO");

                            string valorParametRo = CUBuscarValorParametroPorNombre.BuscarValorParametroPorNombre("MinLargoNombre");

                            if (int.TryParse(valorParametRo, out ValorPArametro))
                            {
                                if (ValorPArseadO > ValorPArametro) throw new ParametrosException("El largo mínimo ingresado no puede ser mayor a " + CUBuscarValorParametroPorNombre.BuscarValorParametroPorNombre("MaxLargoNombre"));


                            }

                            if (HttpContext.Session.GetString("nombre") == null) throw new CambiosException("HAY QUE LOGEARSE PRIMERO");


                            string NombreUsuario = HttpContext.Session.GetString("nombre");
                            CUModificarMinLargoNombre.Modificar("MINLargoNombre", ValorPArseadO.ToString(), NombreUsuario);
                            CUVOModificarMinLargoNombre.Modificar(ValorPArseadO);
                            ///////////////////////////////




                            ViewBag.Exito = "Parametro actualizado con éxito";
                            return View("ModificarParametros");























                           
                        }
                        else
                        {
                            ViewBag.Error = "Debes ingresar un numero";
                            return View("ModificarParametros");

                        }

                    default:
                        break;

                }



            }
            catch (CambiosException ex)
            {

                ViewBag.Error = ex.Message;
                return View("ModificarParametros");




            }
            catch (ParametrosException ex)
            {

                ViewBag.Error = ex.Message;
                return View("ModificarParametros");




            }
            catch (Exception ex)
            {

                ViewBag.Error = "No se pudo modificar el tope del largo";
                return View("ModificarParametros");




            }



             return View("ModificarParametros");





        }












    }
}

