

namespace MVC.DTOs
{
    public class DTOAmenaza
    {
        public int Id { get; set; }      
        public string Descripcion { get; set; }
        public int Peligrosidad { get; set; }
        public DTOEspecie Especie { get; set; }
        public IEnumerable<DTOAmenaza> amenazas { get; set; }
        public IEnumerable<int> IdsDeLasAmenazas { get; set; }
        public int IdAmenaza { get; set; }
        public int IdEcosistema { get; set; }
        public int IdEspecie { get; set; }
        public IEnumerable<string> Especies { get; set; }
        public IEnumerable<string> Ecosistemas { get; set; }
    }
}
