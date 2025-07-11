﻿
namespace MVC.DTOs
{
    public class EspecieDTO
    {
        public int Id { get; set; }
        public string NombreCientifico { get; set; }
        public string NombreComun { get; set; }
        public string Descripcion { get; set; }
        public int PesoMinimo { get; set; }
        public int PesoMaximo { get; set; }
        public int LongitudMinima { get; set; }
        public int LongitudMaxima { get; set; }
        public string? ImagenEspecie { get; set; }
        public EstadoConservacionDTO EstadoCons { get; set; }
        public int IdEstadoCons { get; set; }
        public IEnumerable<AmenazaDTO>? Amenazas { get; set; }
        public IEnumerable<DTOHabitat>? Habitats { get; set; }
        public IEnumerable<EstadoConservacionDTO> EstadosDeConservacion { get; set; }
        public string NombreUsuario { get; set; }
    }
}
