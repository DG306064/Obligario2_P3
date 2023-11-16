using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using LogicaNegocio.ValueObjects;

namespace LogicaAplicacion.CasosUso
{
    public class CUListadoEcosistema : IListadoEcosistemas
    {
        public IRepositorioEcosistema RepoEcosistema { get; set; }
        public IRepositorioPais RepoPais { get; set; }

        public CUListadoEcosistema( IRepositorioEcosistema repoEco, IRepositorioPais repoPais) 
        {
            RepoEcosistema = repoEco;
            RepoPais = repoPais;
        }




        public IEnumerable<EcosistemaDTO> Listado()
        {
            return RepoEcosistema.FindAll().Select(e => new EcosistemaDTO
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
                Amenazas = ConvertirAmenazas(e.Amenazas),
                NombreImagenEcosistema = e.ImagenEcosistema
            }); ;
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
