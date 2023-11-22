using MVC.DTOs;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class EspecieViewModel
    {
        public EspecieDTO Especie {get; set;}
        public int Id { get; set; }
        public string NombreCientifico { get; set; }
        public string NombreComun { get; set; }
        public string TextoNombreComun { get; set; }
        public string Descripcion { get; set; }
        public string TextoDescripcion { get; set; }
        public int PesoMinimo { get; set; }
        public int PesoMaximo { get; set; }
        public int LongitudMinima { get; set; }
        public int LongitudMaxima { get; set; }
        public string NombreImagenEspecie { get; set; }
        public EstadoConservacionDTO EstadoCons { get; set; }
        public int IdEstadoCons { get; set; }
        public IEnumerable<AmenazaDTO>? Amenazas { get; set; }
        public IEnumerable<DTOHabitat>? Habitats { get; set; }
        public IEnumerable<EstadoConservacionDTO> EstadosDeConservacion { get; set; }
        public IFormFile ImagenEspecie { get; set; }
    }
}
