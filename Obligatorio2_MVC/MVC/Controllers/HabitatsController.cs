using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.DTOs;
using Newtonsoft.Json;
//using LogicaAplicacion.CasosUso;
//using LogicaAplicacion.InterfacesCU;
using ExcepcionesPropias;

namespace MVC.Controllers
{
    public class HabitatsController : Controller
    {


        

        public HabitatsController()
        {
            
        }

        public IActionResult Create(DTOEspecie especie)
        {
           // if (HttpContext.Session.GetString("nombre") == null)
           // {
           //     return View("NoAutorizado");
           // }

           // HabitatViewModel vm = new HabitatViewModel()
           // {
           //    IdEspecie = especie.Id,
           //    Especie = especie,
           //    Ecosistemas = CUEcosistemasSinHabitatEnUnaEspecie.ObtenerEcosistemasSinHabitatEnUnaEspecie(especie.Id)

           //};

            return View(especie);
        }


        
        public IActionResult GenerarHabitat(DTOHabitat vm)
        {
            return View(vm);
            //if (HttpContext.Session.GetString("nombre") == null)
            //{
            //    return View("NoAutorizado");
            //}

            //Ecosistema eco = new Ecosistema() { Id = vm.IdEcosistema };
           

            //vm.Habitat = new Habitat()
            //{
            //    ecosistema = eco,
            //    habita = false
            //};


            //try
            //{
            //    if (HttpContext.Session.GetString("nombre") == null) throw new CambiosException("HAY QUE LOGEARSE PRIMERO");

            //    string NombreUsuario = HttpContext.Session.GetString("nombre");
            //    CUAltaHabitat.Alta(vm.Habitat, NombreUsuario);
            //    vm.IdHabitat = vm.Habitat.Id;

                
            //    Especie especie = CUBuscarEspeciePorId.Buscar(vm.IdEspecie);
            //    vm.Especie = especie;


            //    return RedirectToAction("AgregarHabitatEnLaEspecie", "Habitats", vm);
            //}
            //catch (CambiosException ex)
            //{

            //    vm.Especie = new Especie() { Id = vm.IdEspecie };
            //    ViewBag.Error = ex.Message;
            //    return RedirectToAction("Create", vm.Especie);

            //}
            //catch (HabitatException ex)
            //{

            //    vm.Especie = new Especie() { Id = vm.IdEspecie };
            //    ViewBag.Error = ex.Message;
            //    return RedirectToAction("Create", vm.Especie);

            //}
            //catch (Exception ex)
            //{
            //    vm.Especie = new Especie() { Id = vm.IdEspecie };

            //    ViewBag.Error = "Ocurrió un problema al intentar el alta del cliente";
            //    return RedirectToAction("Create", vm.Especie);

            //}

        }

        public IActionResult AgregarHabitatEnLaEspecie(DTOHabitat vm)
        {
            return View(vm);
            //if (HttpContext.Session.GetString("nombre") == null)
            //{
            //    return View("NoAutorizado");
            //}

            //try
            //{
            //    CUAgregarHabitatEnLaEspecie.AgregarHabitatEnLaEspecie(vm.IdEspecie, vm.IdHabitat);

            //    vm.Especie = new Especie() { Id = vm.IdEspecie };

            //    return RedirectToAction("Create", vm.Especie);

            //}
            //catch (EspecieException ex)
            //{
            //    vm.Ecosistemas = CUEcosistemasSinHabitatEnUnaEspecie.ObtenerEcosistemasSinHabitatEnUnaEspecie(vm.IdEspecie);

            //    vm.Especie = new Especie() { Id = vm.IdEspecie };
            //    ViewBag.Error = ex.Message;
            //    return View("Create", vm);

            //}
            //catch (Exception ex)
            //{
            //    vm.Ecosistemas = CUEcosistemasSinHabitatEnUnaEspecie.ObtenerEcosistemasSinHabitatEnUnaEspecie(vm.IdEspecie);

            //    vm.Especie = new Especie() { Id = vm.IdEspecie };

            //    ViewBag.Error = "Ocurrió un error asignando el ecosistema";
            //    return View("Create", vm);

            //}


        }


       
    }
}
