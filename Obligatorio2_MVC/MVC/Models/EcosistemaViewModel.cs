using MVC.DTOs;
using System.ComponentModel.DataAnnotations;


namespace MVC.Models
{
    public class EcosistemaViewModel
    {
        public EcosistemaDTO Ecosistema { get; set; }
        public IEnumerable<PaisDTO> Paises { get; set; }
        public int IdPaisSeleccionado { get; set; }
        public int IdEstadoConservacion { get; set; }

        public IEnumerable<EstadoConservacionDTO> EstadosDeConservacion { get; set; }

        public IFormFile ImagenEcosistema { get; set; }
        [Display(Name ="Nombre")]
        public string NombreEcosistema { get; set; }
        [Display(Name = "Descripcion")]
        public string DescripcionEcosistema { get; set; }

        public string NombreUsuario { get; set; }

    }

}
