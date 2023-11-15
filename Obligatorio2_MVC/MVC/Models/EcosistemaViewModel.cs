using MVC.DTOs;
using System.ComponentModel.DataAnnotations;


namespace MVC.Models
{
    public class EcosistemaViewModel
    {
        public DTOEcosistema Ecosistema { get; set; }
        public IEnumerable<DTOPais> Paises { get; set; }
        public int IdPaisSeleccionado { get; set; }
        public int IdEstadoConservacion { get; set; }

        public IEnumerable<DTOEstadoConservacion> EstadosDeConservacion { get; set; }

        public IFormFile ImagenEcosistema { get; set; }
        [Display(Name ="Nombre")]
        public string NombreEcosistema { get; set; }
        [Display(Name = "Descripcion")]
        public string DescripcionEcosistema { get; set; }

    }

}
