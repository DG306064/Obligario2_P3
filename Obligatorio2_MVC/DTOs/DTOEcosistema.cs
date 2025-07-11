﻿using LogicaNegocio.Dominio;
using LogicaNegocio.ValueObjects;

namespace DTOs
{
    public class DTOEcosistema
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? TextoNombre { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public int Area { get; set; }
        public string Descripcion { get; set; }
        public string? TextoDescripcion { get; set; }
        public DTOPais Pais { get; set; }
        public DTOEstadoConservacion EstadoConservacion { get; set; }
        public int IdEstadoConservacion { get; set; }
        public IEnumerable<DTOAmenaza>? Amenazas { get; set; }
        public string[]? NombreAmenazas { get; set; }
        public string ImagenEcosistema { get; set; }
    }




}