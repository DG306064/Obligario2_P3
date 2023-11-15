using MVC.DTOs;

namespace MVC.Models
{
    public class AmenazaViewModel
    {

        public IEnumerable<DTOAmenaza> amenazas { get; set; }
        public DTOAmenaza Amenaza { get; set; }
        public DTOEspecie Especie { get; set; }
        public int IdEspecie { get; set; }
        public int IdAmenaza { get; set; }
        public int IdEcosistema { get; set; }
        public IEnumerable<int> IdsDeLasAmenazas { get; set; }
        public DTOEcosistema Ecosistema { get; set; }
    }
}
