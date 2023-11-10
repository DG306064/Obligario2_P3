using LogicaNegocio;

namespace MVC.Models
{
    public class AmenazaViewModel
    {

        public IEnumerable<Amenaza> amenazas { get; set; }
        public Amenaza Amenaza { get; set; }
        public Especie Especie { get; set; }
        public int IdEspecie { get; set; }
        public int IdAmenaza { get; set; }
        public int IdEcosistema { get; set; }
        public IEnumerable<int> IdsDeLasAmenazas { get; set; }
        public Ecosistema Ecosistema { get; set; }
    }
}
