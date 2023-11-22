using LogicaNegocio.Dominio;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DTOs
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
        public EstadoConservacionDTO? EstadoCons { get; set; }
        public int IdEstadoCons { get; set; }
        public IEnumerable<AmenazaDTO>? Amenazas { get; set; }
        public IEnumerable<HabitatDTO>? Habitats { get; set; }
        public string? NombreUsuario { get; set; }
    }
}
