using ExcepcionesPropias;
using Microsoft.AspNetCore.Authorization;
//using LogicaAplicacion.CasosUso;
//using LogicaAplicacion.InterfacesCU;
//using LogicaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.DTOs;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MVC.Controllers
{
    public class UsuariosController : Controller
    {
        public UsuariosController(){}





        // GET: UsuariosController
        public ActionResult Index()
        {
            //if (HttpContext.Session.GetString("rol") != "Admin" ||( HttpContext.Session.GetString("rol") == "Admin" && HttpContext.Session.GetString("nombre") != "admin1"))
            //{
            //    return View("NoAutorizado");
            //}

            //IEnumerable<Usuario> ListUsuarios = CUListadoUsuario.Listado();
            return View();
        }

   

        public ActionResult Create()
        {
            DTOUsuario vm = new DTOUsuario();   

            return View(vm);
        }



        // POST: UsuariosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DTOUsuario vm)
        {
            return View();
            //vm.Usuario.FechaIngreso = DateTime.Today;

            //try
            //{
            //    if (vm.Usuario.Password != vm.ContraseñaAConfirmar) throw new UsuarioException("ERROR EN LA CONFIRMACION DE LA CONTRASEÑA");

            //    vm.Usuario.Validate();

            //    bool usuarioExiste = CUVerSiExisteUsuario.VerSiExisteUsuario(vm.Usuario.Alias);

            //    if (usuarioExiste == true) throw new UsuarioException("YA EXISTE UN USUARIO CON ESE ALIAS");


            //    string hashedPassword = HashPassword(vm.Usuario.Password);

            //    vm.Usuario.HashedPassword = hashedPassword;
            //    CUAltaUsuario.AltaUsuario(vm.Usuario,vm.Usuario.Alias);

            //    return RedirectToAction("Login");

            //}
            //catch (UsuarioException ex)
            //{
            //    ViewBag.Error = ex.Message;
            //    return View(vm);

            //}
            //catch (Exception ex)
            //{
            //    ViewBag.Error = "Ocurrió un error al hacer el alta del usuario";
            //    //ViewBag.Error2 = ex.Message;
            //    return View(vm);
            //}


        }

        // GET: UsuariosController/Edit/5
        public ActionResult Edit(int id)
        {
            //UsuarioViewModel vm = null;
            //Usuario usuario = CUBuscarUsuarioPorId.BuscarPorId(id);
          
            //if (usuario == null)
            //{
            //    ViewBag.Error = "El usuario con el id " + id + " no existe";
            //}
            //else
            //{

            //    vm = new UsuarioViewModel()
            //    {
            //        Usuario = usuario
            //    };
            //}
            return View();
        }
    

        // POST: UsuariosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DTOUsuario vm)
        {
            return View(vm);
            //try
            //{
            //    vm.Usuario.Validate();

            //    string NombreUsuario = HttpContext.Session.GetString("nombre");
            //    CUModificarUsuario.Modificar(vm.Usuario, NombreUsuario);

            //    return RedirectToAction(nameof(Index));
            //}
            //catch (UsuarioException ex)
            //{
            //    ViewBag.Error = ex.Message;
            //    return View(vm);
            //}
            //catch (Exception ex)
            //{

            //    ViewBag.Error = "Ocurrió un problema al intentar la modificación del usuario";
            //    return View(vm);
            //}

        }

        // GET: UsuariosController/Delete/5
        public ActionResult Delete(int id)
        {
            //Usuario usuario = CUBuscarUsuarioPorId.BuscarPorId(id);
          
            //if (usuario == null)
            //{
            //    ViewBag.Error = "El usuario con el id " + id + " no existe";
            //}
            return View();
        }



        // POST: UsuariosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(DTOUsuario obj)
        {
            return View();
            //try
            //{
            //    string NombreUsuario = HttpContext.Session.GetString("nombre");
            //    CUBajaUsuario.BajaUsuario(obj, NombreUsuario);              
            //    return RedirectToAction(nameof(Index));
            //}
            //catch (UsuarioException ex)
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

        public ActionResult Login()
        {
            DTOUsuario vm = new DTOUsuario();

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(DTOUsuario usu)
         {
            try
            {
                HttpClient cliente = new HttpClient();
                string url = $"http://localhost:5285/api/Usuarios/login";
                Task<HttpResponseMessage> tarea1 = cliente.PostAsJsonAsync(url, usu);
                tarea1.Wait();

                HttpResponseMessage respuesta = tarea1.Result;
                HttpContent contenido = respuesta.Content;
                Task<string> tarea2 = contenido.ReadAsStringAsync();
                tarea2.Wait();

                string body = tarea2.Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //OBTENGO EL TOKEN Y EL ROL
                    var login = JsonConvert.DeserializeObject<DTOLogin>(body);
                    string rol = login.Rol;
                    string token = login.TokenJWT;
                    string nombre = login.Nombre;

                    //LOS GUARDO EN SESSION
                    HttpContext.Session.SetString("token", token);
                    HttpContext.Session.SetString("rol", rol);
                    HttpContext.Session.SetString("nombre", nombre);

                    //REDIRIJO A ALGUNA ACCIÓN
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = body;
                    return View(usu);
                }
            }
            catch
            {
                ViewBag.Error("Ocurrió un error inesperado");
                return View(usu);
            }
        }

        [HttpGet]
        [Route("Usuarios/ActualizarPaises")]
        [ValidateAntiForgeryToken]
        public ActionResult ActualizarPaises()
        {
            try
            {

                HttpClient cliente = new HttpClient();
                string token = HttpContext.Session.GetString("token");
                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                string url = $"http://localhost:5285/api/WebAPI";
                Task<HttpResponseMessage> tarea1 = cliente.GetAsync(url);
                tarea1.Wait();

                HttpResponseMessage respuesta = tarea1.Result;
                HttpContent contenido = respuesta.Content;
                Task<string> tarea2 = contenido.ReadAsStringAsync();
                tarea2.Wait();

                string body = tarea2.Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //OBTENGO EL TOKEN Y EL ROL
                    var mensaje = JsonConvert.DeserializeObject<string>(body);

                    //REDIRIJO A ALGUNA ACCIÓN
                    return View("Paises actualizados");
                }
                else
                {
                    ViewBag.Error = body;
                    return View();
                }
            }
            catch
            {
                ViewBag.Error("Ocurrió un error inesperado");
                return View();
            }
        }




        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }

        public string HashPassword(string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return hashedPassword;
        }

        public bool VerificarPassword(string inputPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(inputPassword, hashedPassword);
        }
    }
}
