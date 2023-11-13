using DTOs;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosUso
{
    public class CUEcosistemasSinHabitatEnUnaEspecie : IEcosistemasSinHabitatEnUnaEspecie
    {
        public IRepositorioEspecie repoEspecie { get; set; }

        public CUEcosistemasSinHabitatEnUnaEspecie(IRepositorioEspecie RepoEsp)
        {
            repoEspecie = RepoEsp;
        }

        public IEnumerable<EcosistemaDTO> ObtenerEcosistemasSinHabitatEnUnaEspecie(int idEspecie)
        {
            var ecosistemas = repoEspecie.EcosistemasQueAunNoTienenPosibleHabitatConEsaEspecie(idEspecie);
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