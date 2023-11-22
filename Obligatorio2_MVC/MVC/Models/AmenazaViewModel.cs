using MVC.DTOs;

namespace MVC.Models
{
    public class AmenazaViewModel
    {

        public IEnumerable<AmenazaDTO> amenazas { get; set; }
        public AmenazaDTO Amenaza { get; set; }
        public EspecieDTO Especie { get; set; }
        public int IdEspecie { get; set; }
        public int IdAmenaza { get; set; }
        public int IdEcosistema { get; set; }
        public IEnumerable<int> IdsDeLasAmenazas { get; set; }
        public EcosistemaDTO Ecosistema { get; set; }
    }
}
