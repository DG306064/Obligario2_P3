using DTOs;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUBuscarEcosistemaPorId : IBuscarEcosistemaPorId
    {
        public IRepositorioEcosistema RepoEco { get; set; }
        public IRepositorioAmenaza RepoAmenaza { get; set; }

        public CUBuscarEcosistemaPorId(IRepositorioEcosistema repoEco, IRepositorioAmenaza repoAmenaza)
        {
            RepoEco = repoEco;
            RepoAmenaza = repoAmenaza;
        }

        
        public EcosistemaDTO BuscarEcoPorId(int id)
        {
            var e = RepoEco.FindById(id);
            var ecosistema = new EcosistemaDTO()
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
            };

            return ecosistema;
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
