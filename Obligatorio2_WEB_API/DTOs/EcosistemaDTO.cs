using LogicaNegocio.Dominio;
using LogicaNegocio.ValueObjects;

namespace DTOs
{
    public class EcosistemaDTO
    {
        public int Id { get; set; }
        public Nombre Nombre { get; set; }
        public string TextoNombre { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public int Area { get; set; }
        public Descripcion Descripcion { get; set; }
        public string TextoDescripcion { get; set; }
        public Pais Pais { get; set; }
        public EstadoConservacion EstadoConservacion { get; set; }
        public IEnumerable<AmenazaDTO> Amenazas { get; set; }
        public string[] NombreAmenazas { get; set; }
        public string ImagenEcosistema { get; set; }
    }




}