

namespace MVC.DTOs
{
    public class AmenazaDTO
    {
        public int Id { get; set; }      
        public string Descripcion { get; set; }
        public int Peligrosidad { get; set; }
        public EspecieDTO Especie { get; set; }
        public IEnumerable<AmenazaDTO> amenazas { get; set; }
        public IEnumerable<int> IdsDeLasAmenazas { get; set; }
        public int IdAmenaza { get; set; }
        public int IdEcosistema { get; set; }
        public int IdEspecie { get; set; }
        public IEnumerable<string> Especies { get; set; }
        public IEnumerable<string> Ecosistemas { get; set; }
    }
}
