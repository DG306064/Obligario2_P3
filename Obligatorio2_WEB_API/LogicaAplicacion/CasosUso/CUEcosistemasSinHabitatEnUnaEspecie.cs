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
                Nombre = e.Nombre.Value,
                Latitud = e.Latitud,
                Longitud = e.Longitud,
                Area = e.Area,
                Descripcion = e.Descripcion.Value,
                Pais = new PaisDTO()
                {
                    Id = e.Pais.Id,
                    CodigoIsoAlpha = e.Pais.CodigoIsoAlpha,
                    Nombre = e.Pais.Nombre.Value,

                },
                EstadoConservacion = new EstadoConservacionDTO()
                {
                    Id = e.EstadoConservacion.Id,
                    Nombre = e.EstadoConservacion.Nombre.Value,
                    Valor = e.EstadoConservacion.Valor
                },
                Amenazas = e.Amenazas.Select(a => new AmenazaDTO()
                {
                    Id = a.Id,
                    Descripcion = a.Descripcion.Value,
                    Peligrosidad = a.Peligrosidad
                }),
                NombreImagenEcosistema = e.ImagenEcosistema
            });

            return ecosistemasDTO;
        }
    }
}