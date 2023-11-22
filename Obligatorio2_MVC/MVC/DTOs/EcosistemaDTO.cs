


namespace MVC.DTOs
{
    public class EcosistemaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? TextoNombre { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public int Area { get; set; }
        public string Descripcion { get; set; }
        public string? TextoDescripcion { get; set; }
        public PaisDTO Pais { get; set; }
        public IEnumerable<PaisDTO> Paises { get; set; }
        public int IdPaisSeleccionado { get; set; }
        public EstadoConservacionDTO EstadoConservacion { get; set; }
        public IEnumerable<EstadoConservacionDTO> EstadosDeConservacion { get; set; }
        public int IdEstadoConservacion { get; set; }
        public IEnumerable<AmenazaDTO>? Amenazas { get; set; }
        public string[]? NombreAmenazas { get; set; }
        public string? NombreImagenEcosistema { get; set; }
        public IEnumerable<int> IdsDeLasAmenazas { get; set; }
        public IFormFile ImagenEcosistema { get; set; }
        public string NombreUsuario { get; set; }
    }




}