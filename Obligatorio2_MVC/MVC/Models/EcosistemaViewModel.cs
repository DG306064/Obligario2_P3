using LogicaNegocio;
using System.ComponentModel.DataAnnotations;
namespace MVC.Models
{
    public class EcosistemaViewModel
    {
        public Ecosistema Ecosistema { get; set; }
        public IEnumerable<Pais> Paises { get; set; }
        public int idPaisSeleccionado { get; set; }
        public int idEstadoConservacion { get; set; }

        public IEnumerable<EstadoConservacion> EstadosDeConservacion { get; set; }

        public IFormFile ImagenEcosistema { get; set; }
        [Display(Name ="Nombre")]
        public string NombreEcosistema { get; set; }
        [Display(Name = "Descripcion")]
        public string DescripcionEcosistema { get; set; }

    }

}
