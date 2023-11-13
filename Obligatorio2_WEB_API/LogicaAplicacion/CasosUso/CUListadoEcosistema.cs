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
                TextoNombre = e.Nombre.Value,
                Latitud = e.Latitud,
                Longitud = e.Longitud,
                Area = e.Area,
                TextoDescripcion = e.Descripcion.Value,
                Pais = e.Pais,
                EstadoConservacion = e.EstadoConservacion,
                Amenazas = ConvertirAmenazas(e.Amenazas),
                ImagenEcosistema = e.ImagenEcosistema
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
