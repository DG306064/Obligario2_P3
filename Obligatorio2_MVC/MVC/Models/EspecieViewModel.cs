using LogicaNegocio;
using System.ComponentModel.DataAnnotations;
namespace MVC.Models
{
    public class EspecieViewModel
    {
        public Especie Especie { get; set; }

        public IEnumerable<Ecosistema> Ecosistemas { get; set; }
        public Amenaza Amenaza { get; set; }
        public Habitat Habitat { get; set; }

        public IEnumerable<EstadoConservacion> EstadosDeConservacion { get; set; }
        public int idEstadoConservacion { get; set; }
        public int idEspecie { get; set; }

        //public string NombreCientifico { get; set; }

        //public string NombreVulgar { get; set; }

        //public IEnumerable<Amenaza> Amenazas { get; set; }

        public IFormFile ImagenEspecie { get; set; }
        [Display(Name = "Nombre comun")]
        public string NombreComunEspecie { get; set; }

        [Display(Name ="Descripcion")]
        public string DescripcionEspecie { get; set; }



    }
}
