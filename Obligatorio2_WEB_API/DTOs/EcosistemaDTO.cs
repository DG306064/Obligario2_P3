using LogicaNegocio.Dominio;
using LogicaNegocio.ValueObjects;

namespace DTOs
{
    public class EcosistemaDTO
    {
        public int Id { get; set; }
        public NombreDTO Nombre { get; set; }

        public double Latitud { get; set; }

        public double Longitud { get; set; }

        public int Area { get; set; }

        public DescripcionDTO Descripcion { get; set; }


        public string Pais { get; set; }

        public string EstadoConservacion { get; set; }

        public IEnumerable<AmenazaDTO> Amenazas { get; set; }

        public string[] NombreAmenazas { get; set; }

        public string ImagenEcosistema { get; set; }
    }
}