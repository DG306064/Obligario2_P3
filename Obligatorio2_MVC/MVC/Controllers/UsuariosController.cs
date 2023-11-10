using ExcepcionesPropias;
using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class UsuariosController : Controller
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





        // GET: UsuariosController
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("rol") != "Admin" ||( HttpContext.Session.GetString("rol") == "Admin" && HttpContext.Session.GetString("nombre") != "admin1"))
            {
                return View("NoAutorizado");
            }

            IEnumerable<Usuario> ListUsuarios = CUListadoUsuario.Listado();
            return View(ListUsuarios);
        }

   

        public ActionResult Create()
        {
            UsuarioViewModel vm = new UsuarioViewModel();   

            return View(vm);
        }



        // POST: UsuariosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel vm)
        {
            vm.Usuario.FechaIngreso = DateTime.Today;

            try
            {
                if (vm.Usuario.Password != vm.ContraseñaAConfirmar) throw new UsuarioException("ERROR EN LA CONFIRMACION DE LA CONTRASEÑA");

                vm.Usuario.Validate();

                bool usuarioExiste = CUVerSiExisteUsuario.VerSiExisteUsuario(vm.Usuario.Alias);

                if (usuarioExiste == true) throw new UsuarioException("YA EXISTE UN USUARIO CON ESE ALIAS");


                string hashedPassword = HashPassword(vm.Usuario.Password);

                vm.Usuario.HashedPassword = hashedPassword;
                CUAltaUsuario.AltaUsuario(vm.Usuario,vm.Usuario.Alias);

                return RedirectToAction("Login");

            }
            catch (UsuarioException ex)
            {
                ViewBag.Error = ex.Message;
                return View(vm);

            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ocurrió un error al hacer el alta del usuario";
                //ViewBag.Error2 = ex.Message;
                return View(vm);
            }


        }

        // GET: UsuariosController/Edit/5
        public ActionResult Edit(int id)
        {
            UsuarioViewModel vm = null;
            Usuario usuario = CUBuscarUsuarioPorId.BuscarPorId(id);
          
            if (usuario == null)
            {
                ViewBag.Error = "El usuario con el id " + id + " no existe";
            }
            else
            {

                vm = new UsuarioViewModel()
                {
                    Usuario = usuario
                };
            }
            return View(vm);
        }
    

        // POST: UsuariosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioViewModel vm)
        {
            try
            {
                vm.Usuario.Validate();

                string NombreUsuario = HttpContext.Session.GetString("nombre");
                CUModificarUsuario.Modificar(vm.Usuario, NombreUsuario);

                return RedirectToAction(nameof(Index));
            }
            catch (UsuarioException ex)
            {
                ViewBag.Error = ex.Message;
                return View(vm);
            }
            catch (Exception ex)
            {

                ViewBag.Error = "Ocurrió un problema al intentar la modificación del usuario";
                return View(vm);
            }

        }

        // GET: UsuariosController/Delete/5
        public ActionResult Delete(int id)
        {
            Usuario usuario = CUBuscarUsuarioPorId.BuscarPorId(id);
          
            if (usuario == null)
            {
                ViewBag.Error = "El usuario con el id " + id + " no existe";
            }
            return View(usuario);
        }



        // POST: UsuariosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Usuario obj)
        {
            try
            {
                string NombreUsuario = HttpContext.Session.GetString("nombre");
                CUBajaUsuario.BajaUsuario(obj, NombreUsuario);              
                return RedirectToAction(nameof(Index));
            }
            catch (UsuarioException ex)
            {
                ViewBag.Error = ex.Message;
                return View(obj);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Ocurrió un error al intentar eliminar el ecosistema";
                return View(obj);
            }
        }













        public ActionResult Login()
        {
            UsuarioLoginViewModel vm = new UsuarioLoginViewModel();

            return View(vm);
        }

        [HttpPost]
         public ActionResult Login(UsuarioLoginViewModel vm)
         {
            try
            {
                IEnumerable<Usuario> usuario = CUObtenerUsuarioParaLogear.ObtenerUsuarioParaLogear(vm.alias, vm.password);
                if (usuario.Count() == 1)
                {
                    Usuario usu = usuario.First();

                    HttpContext.Session.SetString("nombre", usu.Alias);
                    HttpContext.Session.SetString("rol", usu.Rol);

                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    throw new Exception( "DATOS INCORRECTOS. ingrese datos válidos");
                }

            }
           catch(Exception ex)   
            {
                ViewBag.Error = "DATOS INCORRECTOS. ingrese datos válidos";
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
