using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace LogicaAplicacion.CasosUso
{
    public class CUEcosistemasQueNoPuedeHabitarUnaEspecie : IEcosistemasQueNoPuedeHabitarUnaEspecie
    {
        IRepositorioEcosistema RepositorioEcosistema { get; set; }

        public CUEcosistemasQueNoPuedeHabitarUnaEspecie(IRepositorioEcosistema repositorio)
        {
            RepositorioEcosistema = repositorio;
        }
        public IEnumerable<EcosistemaDTO> EcosistemasQueNoPuedeHabitarUnaEspecie(string nombreEspecie)
        {
            var ecosistemas = RepositorioEcosistema.EcosistemasQueNoPuedeHabitarUnaEspecie(nombreEspecie);

            var ecosistemasDTO = ecosistemas.Select(e => new EcosistemaDTO()
            {
                Id = e.Id,
                Nombre = e.Nombre,
                Latitud = e.Latitud,
                Longitud = e.Longitud,
                Area = e.Area,
                Descripcion = e.Descripcion,
                Pais = e.Pais,
                EstadoConservacion = e.EstadoConservacion,
                Amenazas = ConvertirAmenazas(e.Amenazas),
                ImagenEcosistema = e.ImagenEcosistema
            });

            return ecosistemasDTO; 
        }

        public IEnumerable<AmenazaDTO> ConvertirAmenazas(IEnumerable<Amenaza> amenazas)
        {
            return amenazas.Select(a => new AmenazaDTO()
            {
                Id = a.Id,
                Descripcion = a.Descripcion.Value,
                Peligrosidad = a.Peligrosidad
            });
        }
    }
}
