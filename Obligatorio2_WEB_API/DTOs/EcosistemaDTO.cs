using LogicaNegocio.Dominio;
using LogicaNegocio.ValueObjects;

namespace DTOs
{
    public class EcosistemaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public double Latitud { get; set; }

        public double Longitud { get; set; }

        public int Area { get; set; }

        public string Descripcion { get; set; }


        public Pais Pais { get; set; }

        public EstadoConservacion EstadoConservacion { get; set; }

        public IEnumerable<AmenazaDTO> Amenazas { get; set; }

        public string[] NombreAmenazas { get; set; }

        public string ImagenEcosistema { get; set; }
    }




}